import { data } from "jquery";

var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/product/GetAll"
        },
        "colums": [
            { "data": "Title", "width": "15%" },
            { "data": "ISBN" , "width": "15%" },
            { "data": "Price", "width": "15%" },

        ]
    });
}