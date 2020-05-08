

var appcommon_scipt = (function () {
    return {
        Initialize: function () {
            "use strict";
            var fullHeight = function () {

                $('.sbcontainer').css('height', $(window).height());
                $(window).resize(function () {
                    $('.sbcontainer').css('height', $(window).height());
                });

            };
            fullHeight();
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
                $('#content').toggleClass('contentactive');
            });
        },
        LoadDataTables: function () {
            $('#cf_list_tblfaculty').DataTable({
                "pagingType": "first_last_numbers",
                "ordering": false,
                "lengthChange": false,
                "language": {
                    "search": "",
                    "searchPlaceholder": "Search Faculty Name..."
                },
                "pageLength": 10
            });
        }
    }
}());

//DATATABLES UPDATE
//$.extend(true, DataTable.defaults, {
//    dom:
//        "<'row'<'col-sm-12 col-md-6'f>>" +
//        "<'row'<'col-sm-12'tr>>" +
//        "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
//    renderer: 'bootstrap'
//});

$(document).ready(function () {
    $('#ddtest').selectpicker();
    
    appcommon_scipt.Initialize();
    faculty_script.Initialize();
});