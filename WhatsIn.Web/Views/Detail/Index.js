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

            var loc = $("#ddlLocations").data("ejDropDownList");
            obj.locationId = loc.option("value")

            var cat = $("#ddlCategories").data("ejDropDownList");
            obj.categoryId = cat.option("value")

            console.log(JSON.stringify(obj));
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

    $("#UploadImg").change(function () {
        var data = new FormData();
        var files = $("#UploadImg").get(0).files;
        if (files.length > 0) {
            data.append("MyImages", files[0]);
        }

        $.ajax({
            url: "/Detail/UploadFile",
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {
                $("#txtImg").val(response);
                $("#imgPreview").attr('src', '/Uploads/Logos/' + response);
                //alert(response); 
            },
            error: function (er) {
                alert(er);
            }

        });
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