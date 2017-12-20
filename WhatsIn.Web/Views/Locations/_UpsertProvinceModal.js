(function ($) {
    app.modals.UpsertProvinceModal = function () {

        var _modalManager;

        var _appService = abp.services.app.province;
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

            var obj = _$form.serializeFormToObject();
            //user.UserName = user.EmailAddress;

            _modalManager.setBusy(true);
            _appService.upsertProvince(obj).done(function () {
                _modalManager.close();
                location.reload();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);