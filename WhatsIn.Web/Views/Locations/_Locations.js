(function() {
    $(function() {

        var _upsertLocationModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Locations/_UpsertLocationModal',
            scriptUrl: abp.appPath + 'Views/Locations/_UpsertLocationModal.js',
            modalClass: '_UpsertLocationModal'
        });

        $('#CreateNewLocationButton').on('click', function (e) {
            alert("test");
            e.preventDefault();
/*            var provinceid = $(this).prop('provinceid');
            _upsertLocationModal.open({ provinceid: provinceid }); */
        });

        /*$('#CreateNewLocationButton').click(function (e) {
            e.preventDefault();
            alert("Add");
            //_upsertLocationModal.open();
        });*/

        $('.UpdateLocationButton').click(function (e) {
            e.preventDefault();
            var locationid = $(this).prop('id');
            _upsertLocationModal.open({ id: locationid });
        });

        var _locationService = abp.services.app.location;

        $('.DeleteLocationButton').click(function (e) {
            e.preventDefault();

            var id = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteTheRecord'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _locationService.deleteLocation(id).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(id);
                    } 
                }
            );
        });

    });

  
})();