var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columuns": [
            { "data": "name", "width": "10%" },
            { "data": "author", "width": "10%" },
            { "data": "noofcopy", "width": "10%" },
            { "data": "edition", "width": "10%" },
            { "data": "isbn", "width": "10%" },
            { "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                       <a href="/BookList/Edit?id=${data}" class'btn btn-success text-white' style='cursor:pointer;width:40px;'>
                         Edit
                         </a>
                         &nbsp;
                         <a class'btn btn-danger text-white' style='cursor:pointer;width:40px;'>
                         Delete
                         </a>
                         </ div >` ;
                }, " width " : "20%"
            }
        ],
        "language ": {
            "emptyTable" : "no data found"
         },
          "width" : " 100%"
     })
}
