(function () {

    $(function () {
        $('#SearchButton').click(function (e) {
            e.preventDefault();

            var loc = $("#ddlLocations").data("ejDropDownList");
            var locationId = loc.option("value")

            var cat = $("#ddlCategories").data("ejDropDownList");
            var categoryId = cat.option("value")

            var prov = $("#ddlProvinces").data("ejDropDownList");
            var provinceId = prov.option("value")

            abp.ui.setBusy(
                $('#HomeArea'),
                abp.ajax({
                    url: abp.appPath + 'Home/Index',
                    type: 'POST',
                    data: JSON.stringify({
                        categoryValue: categoryId,
                        provinceValue: provinceId,
                        locationValue: locationId
                    })
                })
            );
        });
       
    });

})();