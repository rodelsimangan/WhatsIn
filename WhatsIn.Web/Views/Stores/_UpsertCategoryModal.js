(function ($) {
    app.modals.UpsertCategoryModal = function () {

        var _modalManager;

        var _appService = abp.services.app.category;
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
            _appService.upsertCategory(obj).done(function () {
                _modalManager.close();
                location.reload();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);