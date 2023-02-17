
document.addEventListener("keydown", e => {console.log(e);});

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
    let selected = document.querySelectorAll('.active-row');
    selected.forEach(element => element.classList.remove('active-row'));
    el.classList.add('active-row');
}
const GetSelectedItemJson = () => {
    let table = document.querySelectorAll('.data-table.active');    
    let selectedItem = document.querySelector('.active-row');    
    let item = {};
    
    for(let i = 0; i < selectedItem.children.length; i++)
    {
        item[selectedItem.children[i].className.replace('-column', '')] = selectedItem.children[i].innerHTML;
    }
        
    return JSON.stringify(item);
}

const addButton = () => {
    let table = document.querySelector ('table.data-table.active');
    var row = table.insertRow(0);
}

const add = (jsonData) => {
    const xhttp = new XMLHttpRequest();
    xhttp.open("POST", "/Data/Create/");
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(jsonData);
}

const remove = (jsonData) => {
    const xhttp = new XMLHttpRequest();
    xhttp.open("POST", "/Data/Remove/");
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send(jsonData);
}

const edit = () => {
    
}