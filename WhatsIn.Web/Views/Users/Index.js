(function() {
    $(function() {

        var _upsertUserModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Users/UpsertUserModal',
            scriptUrl: abp.appPath + 'Views/Users/_UpsertUserModal.js',
            modalClass: 'UpsertUserModal'
        });

        $('#CreateNewUserButton').click(function (e) {
            e.preventDefault();
            _upsertUserModal.open();
        });

        $('.UpdateUserButton').click(function (e) {
            e.preventDefault();
            var userid = $(this).prop('id');
            _upsertUserModal.open({ id: userid });
        });

    });
})();