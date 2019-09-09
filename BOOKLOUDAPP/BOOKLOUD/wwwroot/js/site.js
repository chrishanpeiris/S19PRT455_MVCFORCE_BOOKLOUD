$(document).ready(function () {
    $("#bookName").autocomplete({
        source: '/api/book/search'
    });
})