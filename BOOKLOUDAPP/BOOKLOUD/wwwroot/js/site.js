// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function() {
    $("#BookName").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "/SearchBook/AutoComplete",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function(data) {
                    response($.map(data,
                        function(item) {
                            return { label: item.BookName, value: BookName };
                        }))
                }
            })
        },
        messages: {
            noResults: "",
            results: ""
        }
    });
})