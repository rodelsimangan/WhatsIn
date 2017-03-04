(function() {
    $(function() {

        var _upsertProvinceModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Locations/UpsertProvinceModal',
            scriptUrl: abp.appPath + 'Views/Locations/_UpsertProvinceModal.js',
            modalClass: 'UpsertProvinceModal'
        });

/*        var _upsertLocationModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Locations/UpsertLocationModal',
            scriptUrl: abp.appPath + 'Views/Locations/_UpsertLocationModal.js',
            modalClass: 'UpsertLocationModal'
        });

    

        $('#CreateNewLocationButton').click(function (e) {
            e.preventDefault();
            alert("test");
            var provinceid = $(this).prop('provinceid');
            _upsertLocationModal.open({ provinceid: provinceid} );
        });
  */      
        $('.UpdateProvinceButton').click(function (e) {
            e.preventDefault();
            var provinceid = $(this).prop('id');
            _upsertProvinceModal.open({ id: provinceid });
        });

        var _provinceService = abp.services.app.province;

        $('.DeleteProvinceButton').click(function (e) {
            e.preventDefault();

            var provinceid = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteTheRecord'),
                function (isConfirmed) {
                    if (isConfirmed) {
                         _provinceService.deleteProvince(provinceid).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(provinceid);
                    } 
                }
            );
        });

        var expandgrid;
        $(".grid-parent").click(function () {
            
            var provinceid = $(this).prop('id');
            
            $gridparent = $(this);
            //getting the next element
            $gridchild = $gridparent.next();

            $btn = $(".ExpandCollapseButton-" + provinceid);

            if ($gridparent.attr("expandgrid") == "0") {
                expandgrid = true;
                $gridparent.attr("expandgrid", "1");
                $btn.html('<span class="fa fa-chevron-down"></span>')
            } else {
                expandgrid = false;
                $gridparent.attr("expandgrid", "0");
                $btn.html('<span class="fa fa-chevron-right"></span>');
            }

            if (expandgrid == true)
            {
                $.ajax({
                    type: "POST",
                    url: abp.appPath + 'Locations/GetLocations',
                    data: { provinceId: provinceid },
                    success: function (response) {
                        $('#DIV-LOCATIONS').html(response);
                    },
                });

          

                /*$('#btnBack').on('click', function () {
                    alert('test');
                });*/
            }

            //open up the content needed - toggle the slide- if visible, slide up, if not slidedown.
            $gridchild.slideToggle(500, function () {
            }); 
        });
    });

  
})();