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

        var _userService = abp.services.app.user;

        $('.DeleteUserButton').click(function (e) {
            e.preventDefault();

            var userid = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteThePerson'),
                function (isConfirmed) {
                    if (isConfirmed) {
                         _userService.deleteUser(userid).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(userid);
                    } 
                }
            );
        });
    });

  
})();