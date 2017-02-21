(function ($) {
    app.modals.UpsertUserModal = function () {

        var _modalManager;

        var _userService = abp.services.app.user;
        var _$form = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$form = _modalManager.getModal().find('form');
            _$form.validate();
        };

        this.save = function () {

            if (!_$form.valid()) {
                return;
            }

            var user = _$form.serializeFormToObject();
            user.UserName = user.EmailAddress;

            _modalManager.setBusy(true);
            _userService.upsertUser(user).done(function () {
                _modalManager.close();
                location.reload();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);