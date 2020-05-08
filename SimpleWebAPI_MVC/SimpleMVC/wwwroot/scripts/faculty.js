var faculty_script = (function () {
    return {
        Initialize: function () {
            this.LoadDateTimePickers();
            this.LoadDataTables();
            this.LoadDropdowns();
        },
        LoadDateTimePickers: function () {
            $('#dtp_faculty_resigned').datetimepicker({
                format: 'L'
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

            $('#cf_details_faculty_designation_tbldesignation').DataTable({
                "pagingType": "first_last_numbers",
                "ordering": false,
                "lengthChange": false,
                "pageLength": 5,
                "searching": false,
                "info": false
            });

            $('#cf_details_faculty_schedule_tblschedules').DataTable({
                "pagingType": "first_last_numbers",
                "ordering": false,
                "lengthChange": false,
                "pageLength": 10,
                "language": {
                    "search": "",
                    "searchPlaceholder": "Search Schedule..."
                },
            });
        }
    }
}());