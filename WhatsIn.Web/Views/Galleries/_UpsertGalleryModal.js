(function ($) {
    app.modals.UpsertGalleryModal = function () {

        var _modalManager;

        var _appService = abp.services.app.gallery;
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
            _appService.upsertGallery(obj).done(function () {
                _modalManager.close();
                location.reload();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };

        function onUploadImageGallerySuccess() {
            alert("test");
            $('#imgGallery').prop("src", '/Upload/Galleries/GetTempReportingLogo?' + Math.random());
            return false;
        }

        $('#imgReportingLogo').prop("src", '@Url.Action("GetReportingLogo", "OwnerScreen", new { id = "${OwnerId}" })' + '?' + Math.random());
    };


})(jQuery);