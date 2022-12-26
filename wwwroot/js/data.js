
const openTable = (el, tableId) => {
    let tabLinks = document.querySelectorAll('.tabLink');
    let tabContents = document.querySelectorAll('.data-table');
    let table = document.getElementById(tableId);
    
    
    tabLinks.forEach(element => element.classList.remove('active'));
    el.classList.add('active');
    tabContents.forEach(element => element.style.display = 'none');
    table.style.display = 'block';
}

const selectRow = (el) => {
    let selected = document.querySelectorAll('.active-row')
    selected.forEach(element => element.classList.remove('active-row'));
    el.classList.add('active-row');
}