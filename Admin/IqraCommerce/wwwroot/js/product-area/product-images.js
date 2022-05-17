import { url } from "../utils.js";
import params from "../utils/params.js";

const productId = params.id;

let selectedImages = [];

const imagesChangeHandler = (e) => {
    selectedImages = [...selectedImages, ...e.target.files];

    renderPreviews(selectedImages);
}

const renderGallery = (images = []) => {
    if(images.length > 0){
        $('#gallery-container').show();
        $('#no-image-text').hide();
    }
    else{
        $('#gallery-container').hide();
        $('#no-image-text').show();
    }

    $('#gallery .thumbnail').remove();

    const template = $('#template--thumbnail').html();

    images.forEach(image => {
        let thumbnail = template.replace('{{elementId}}', image.Id);
        thumbnail = template.replace('{{AlterText}}', image.Id);
        thumbnail = thumbnail.replace('{{imageURL}}', url(`/images/products/icon/${image.ImageURL}`));

        const $thumbnail = $(thumbnail);
        
        if(image.IsPrimary) $thumbnail.find('.button-primay').show();
        else  $thumbnail.find('.button-set-as-primary').show();
        
        $thumbnail.find('.button-set-as-primary').click(e => setAsPrimary(image));
        $thumbnail.find('.thumbnail__image').click(e => showCase(image));
        $thumbnail.find('.button-remove-image').click(e => remove(image));

        $('#gallery').append($thumbnail);
    });
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
    $('#previews .thumbnail').remove();
}

const save = () => {
    $('upload-loader').show();

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
        getImages();
   })
   .catch(err => console.log(err));
}

const getImages = () => {
    $('gallery-loader').show();

    const formData = new FormData();
    formData.append('id', productId);

    fetch('/Product/GetImages', {
        method: 'POST',
        body: formData,
    }).finally(() => {
        $('gallery-loader').hide();
    }).then(res => res.json())
    .then(data => {
        if(data.IsError)
             throw new Error(data.Msg);
         
        renderGallery(data.Data);
        showCase(data.Data);
    })
    .catch(err => console.log(err));
}

const setAsPrimary = (image) => {
    $('gallery-loader').show();

    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('imageId', image.Id);

    fetch('/Product/MarkImageAsPrimary', {
        method: 'POST',
        body: formData,
    }).finally(() => {
        $('gallery-loader').hide();
    }).then(res => res.json())
    .then(data => {
        if(data.IsError)
             throw new Error(data.Msg);
         
        renderGallery(data.Data);
    })
    .catch(err => console.log(err));
}

const remove = (image) => {
    $('gallery-loader').show();

    const formData = new FormData();
    formData.append('productId', productId);
    formData.append('imageId', image.Id);

    fetch('/Product/RemoveImage', {
        method: 'POST',
        body: formData,
    }).finally(() => {
        $('gallery-loader').hide();
    }).then(res => res.json())
    .then(data => {
        if(data.IsError)
             throw new Error(data.Msg);
         
        renderGallery(data.Data);
    })
    .catch(err => console.log(err));
}

const showCase = (param) => {
    let image;

    if(Array.isArray(param))
        image = param.find(i => i.IsPrimary) ?? param[0];
    else 
        image = param;

    if(!image) return;

    $('.show .thumbnail').show();
    $('#showcase').attr('src', url(`/images/products/original/${image?.ImageURL}`));
    $('#showcase').attr('alt', image?.Id);
}


$(document).ready(getImages);
$('#input-images').change(imagesChangeHandler);
$('#button-save').click(save);
$('#button-cancel').click(cancel);
