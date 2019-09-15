$(document).ready(function () {
    
    $("#BookName").autocomplete({
        source: '/api/book/search'
    })
                .autocomplete('instance')._renderItem = function (ul, item) {
                    return $('<li>')
                        .append('<img class="autoCompleteImg" src=' + '/img/book_img/' + item.imgPath + ' />')
                        .append(item.label)
                        .appendTo(ul);
                };
})