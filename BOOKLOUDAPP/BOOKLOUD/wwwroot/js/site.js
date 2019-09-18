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

    $("#UniversityId").change(function() {
        var url = "AddBook/getcoursebyid";
        var ddlsource = "#UniversityId";
        $.getJSON(url,
            { id: $(ddlsource).val() },
            function(data) {
                var items = '';
                $("#CourseId").empty();
                $.each(data,
                    function(i, row) {
                        items += "<option value='" + row.value + "' >" + row.text + "</option>"
                    });
                $("#CourseId").html(items);
            });
    });

    $("#CourseId").change(function () {
        var url = "AddBook/getunitbyid";
        var ddlsource = "#CourseId";
        $.getJSON(url,
            { id: $(ddlsource).val() },
            function (data) {
                var items = '';
                $("#UnitName").empty();
                $.each(data,
                    function (i, row) {
                        items += "<option value='" + row.value + "' >" + row.text + "</option>"
                    });
                $("#UnitName").html(items);
            });
    });
})