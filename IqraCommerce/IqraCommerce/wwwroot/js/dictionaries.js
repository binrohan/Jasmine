export const bannerType = {
    mainBanner: 0,
    offerBanner: 1
}

export const offerType = {
    cashback: 0,  delivery: 1
}

export const complainType =
{
    website: 0, delivery: 1, agentBehaviors: 2, products: 3, others: 4
}

export const complainStatus = 
{
    new: 0, seen: 1, onHold: 2
}

export const dictionaryBound = (td, checkValue, dict) => {
    for(const [key, value] of Object.entries(dict)){
        if(this.ComplainType == value){
            td.html(key);
            break;
        }
    }
}

const textify = (text) => {
    let output = "";
    text = text[0].toUpperCase();

    for(let i = 0; i < text.length; ++i){
        if(text[i] == text[i].toUpperCase()){
            text[i] = " " + text[i];
        }
    }

    return text;
}

