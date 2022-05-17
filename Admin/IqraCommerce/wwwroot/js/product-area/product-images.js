import params from "../utils/params.js";

const productId = params.id;

let selectedImages = [];

const imagesChangeHandler = (e) => {
    selectedImages = [...selectedImages, ...e.target.files];

    renderPreviews(selectedImages);
}

const removeSelectedImage = (e, images) => {
    const index = +e.target.dataset.id;

    selectedImages = images.filter((image, i) => i !== index);

    renderPreviews(selectedImages);
}

const renderPreviews = (images = []) => {
    let templateHTML = $('#template--preview-thumbnail').html();

    $('#previews .thumbnail').remove();

    images.forEach((image, i) => {
        let previewHTML = templateHTML.replace('{{imageURL}}', URL.createObjectURL(image));
        previewHTML = previewHTML.replace('{{element-id}}', i);

        const previewsContainerHTML = $('#previews').html() + previewHTML;

        $('#previews').html(previewsContainerHTML);
    });

    $('.preview-remove').click(e => removeSelectedImage(e, images));
}

const cancel = () => {
    selectedImages = [];
}

const save = () => {
    console.log(selectedImages);

    const formData = new FormData();
    formData.append('id', productId);
    selectedImages.forEach(image =>  formData.append('images', image));

    $('upload-loader').hide();

   fetch('/Product/UploadImages', {
    body: formData,
    method: 'POST',
   }).finally(() => {
       $('upload-loader').hide();
   }).then(res => res.json())
   .then(data => {
       if(data.IsError)
            throw new Error(data.Msg);
        
        cancel();
   })
   .catch(err => console.log(err));
}

const getImages = () => {
    
}


$('#input-images').change(imagesChangeHandler);
$('#button-save').click(save);
$('#button-cancel').click(cancel);