export const url = (endpoint) => {
    return window.location.origin + endpoint;
}

export function dateBound (el, date) {
    if(!date) el.html('');
    el.html(new Date(date).toLocaleString('en-US'));
}