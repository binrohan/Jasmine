export const operationType = {
    equal: 0
}

export const trashRecord = { "field": "IsDeleted", "value": 1, Operation: 0 };

export const liveRecord = { "field": "IsDeleted", "value": 0, Operation: 0 };

export const visibleRecord = { "field": "IsVisible", "value": 1 , Operation: 0 };

export const hiddenRecord = { "field": "IsVisible", "value": 0 , Operation: 0 };

export const filter = (key, value, operation = operationType.equal) => {
    return { "field": key, "value": value , Operation: operation };
}