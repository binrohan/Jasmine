
const generateBrandName = (ascii) => {
    return ;
}

const postBrand = (ascii) => {
    if(ascii > 90) return;

     fetch('http://localhost:56700/Brand/Create', {
        method: 'POST',
        headers: {
            "content-type": "text/json"
        },
        body: JSON.stringify({
            "Name": generateBrandName(ascii),
            "Description": "Desription For" + generateBrandName(ascii)
        })
    }).then(()=>{
        console.log("success!!");
    }).catch(() => {
        console.log("failed" + generateBrandName(ascii));
    }).finally(() => {
        postBrand(++ascii);
    });
}

postBrand(65);