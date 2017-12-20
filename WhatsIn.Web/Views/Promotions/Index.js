(function () {
    $(function () {

        var _upsertPromotionModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Promotions/UpsertPromotionModal',
            scriptUrl: abp.appPath + 'Views/Promotions/_UpsertPromotionModal.js',
            modalClass: 'UpsertPromotionModal'
        });

        $('#CreateNewPromotionButton').click(function (e) {
            e.preventDefault();
            _upsertPromotionModal.open();
        });

        $('.UpdatePromotionButton').click(function (e) {
            e.preventDefault();
            var promotionid = $(this).prop('id');
            _upsertPromotionModal.open({ id: promotionid });
        });

        var _promotionService = abp.services.app.promotion;

        $('.DeletePromotionButton').click(function (e) {
            e.preventDefault();

            var promotionid = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteThePromotion'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _promotionService.deletePromotion(promotionid).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(promotionid);
                    }
                }
            );
        });

      
    });


})();