(function () {
    $(function () {

        var _appService = abp.services.app.store;

        $('#SaveDetails').click(function (e) {
            e.preventDefault();
            var _$form = null;
            _$form = $('#DetailForm');
//            _$form.validate();

 //           if (!_$form.valid()) {
 //               return;
 //           }
 //           alert("SaveDetails");

            var obj = _$form.serializeFormToObject();
            var dropdown = $("#ddlLocations").data("ejDropDownList");
            obj.locationId = dropdown.option("value")
            console.log(JSON.stringify( obj));
            //_modalManager.setBusy(true);
             _appService.upsertStore(obj).done(function () {
                //_modalManager.close();
                location.reload();
            }).always(function () {
                abp.ui.setBusy('#DetailForm');
            }); 
        });

      
      /*   var _upsertGalleryModal = new app.ModalManager({
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
        }); */
       

      
    });

  
   
})();

function onProvinceChange(args) {
    $.ajax({
        type: "POST",
        url: DetailsUrlSettings.LocationsUrl,
        data: { provinceId: args.value },   // <== change is here
        success: function (response) {
            console.log(response);
            console.log(DetailsUrlSettings.LocationsDataSource);
            var dropdown = $("#ddlLocations").data("ejDropDownList");
            dropdown.option("dataSource", DetailsUrlSettings.LocationsDataSource);
            $('#DIV-LOCATIONS').html(response);
        },
    });
}