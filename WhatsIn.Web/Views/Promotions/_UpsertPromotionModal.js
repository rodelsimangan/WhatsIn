(function ($) {

    app.modals.UpsertPromotionModal = function () {

        var _modalManager;

        var _appService = abp.services.app.promotion;
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

            _modalManager.setBusy(true);
            _appService.upsertPromotion(obj).done(function () {
                _modalManager.close();
                location.reload();
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    }; 

    $("#UploadImg").change(function () {
        var data = new FormData();
        var files = $("#UploadImg").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
        }

        $.ajax({
            url: "/Promotions/UploadFile",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                $("#txtImg").val(response);
                $("#imgPreview").attr('src', '/Uploads/Promotions/' + response);
                //alert(response); 
            },
            error: function (er) {
                alert(er);
            }

        });
    });


})(jQuery);