(function () {
    $(function () {

        var _upsertGalleryModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Galleries/UpsertGalleryModal',
            scriptUrl: abp.appPath + 'Views/Galleries/_UpsertGalleryModal.js',
            modalClass: 'UpsertGalleryModal'
        });

        $('#CreateNewGalleryButton').click(function (e) {
            e.preventDefault();
            _upsertGalleryModal.open();
        });

        $('.UpdateGalleryButton').click(function (e) {
            e.preventDefault();
            var galleryid = $(this).prop('id');
            _upsertGalleryModal.open({ id: galleryid });
        });

        var _galleryService = abp.services.app.gallery;

        $('.DeleteGalleryButton').click(function (e) {
            e.preventDefault();

            var galleryid = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteTheGallery'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _galleryService.deleteGallery(galleryid).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(galleryid);
                    }
                }
            );
        });

      
    });


})();