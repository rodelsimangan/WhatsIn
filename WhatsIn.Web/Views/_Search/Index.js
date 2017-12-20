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
                    url: abp.appPath + 'Search/Result',
                    type: 'POST',
                    data: JSON.stringify({
                        categoryValue: categoryId,
                        provinceValue: provinceId,
                        locationValue: locationId
                    }),
                    datatype: "JSON ",
                    success: function (response) {
                         console.log(response);

                        $('#SearchResult').empty();

                        $.each(response.stores, function (i, item) {
                            var rows = "<div id=" + item.id + " class=\"rTable grid-parent\" expandgrid=\"0\" >"
                                        + "<div class=\"rTableCell text-left\" style=\"width:40%;\">"
                                        + "<img id=\"imgOwnerLogo\" alt=\"No Image\" style=\"height:150px; width:150px;\" src=\"" + "/Uploads/Logos/" + item.logoPath + "\" />"
                                        + "</div>"
                                        + "<div class=\"rTableCell text-left\" style=\"vertical-align: top;\">"
                                            + "<h3>" + item.name + "</h3>"
                                            + "<i class=\"fa fa-address-card\"></i><span>&nbsp;" + item.address1 + " " + item.address2 + "</span><br/>"
                                            + "<i class=\"fa fa-phone\"></i><span>&nbsp;" + item.contactNum + "</span><br/>"
                                            + "<i class=\"fa fa-envelope-o\"></i><span>&nbsp;" + item.email + "</span><br/>"
                                            + "<i class=\"fa fa-clock-o\"></i><span>&nbsp;" + item.schedule + "</span><br/>"
                                            + "<a href=\"" + "http://www.facebook.com/" + item.facebookPage + "\"><i class=\"fa fa-facebook\"></i></a>&nbsp;&nbsp;"
                                            + "<a href=\"" + "http://www.twitter.com/" + item.twitterPage + "\"><i class=\"fa fa-twitter\"></i></a>&nbsp;&nbsp;"
                                            + "<a href=\"" + "http://www.instagram.com/" + item.instagramPage + "\"><i class=\"fa fa-instagram\"></i></a>&nbsp;&nbsp;<br/>"
                                           // + "<i class=\"fa fa-link\"></i><a href=\"" + "http://localhost:61759/" + item.name + "\" target=\"_blank\">&nbsp;Click to view more..</a><br/>"
                                            + "<i class=\"fa fa-link\"></i><a href=\"" + "http://localhost:10179//Pages/\" target=\"_blank\">&nbsp;Click to view more..</a><br/>"
                                        + "</div>"
                                        + "<div class=\"rTableCell\"><input type=\"hidden\" class=\"userId\" />&nbsp;</div>"
                                     + "</div>";
                            console.log(rows);
                            $('#SearchResult').append(rows);
                        });
                    },


                })
            );

        });
    });

    /*     @foreach (var item in response.Stores)
                        {
                            
                                <div id="@item.Id" class="rTableRow" expandgrid="0">
                                    <div class="rTableCell text-left" style="width:40%;">
                                        <img id="imgOwnerLogo" alt="No Image" style="height:150px; width:150px;" src="@Url.Content(string.Concat("/Uploads/Logos/",item.LogoPath))" />
                                    </div>
                                    <div class="rTableCell"><input type="hidden" class="userId" /></div>
                                    <div class="rTableCell text-right">
                                        <i class="fa fa-address-card-o"></i><span>@string.Concat(item.Address1, " ", item.Address2)</span>
                                        <i class="fa fa-phone"></i><span>@item.ContactNum</span>
                                        <i class="fa fa-clock-o"></i><span>@item.Email</span>
                                        <i class="fa fa-envelope-o"></i><span>@item.Schedule</span>
                                        <i class="fa fa-facebook"></i><a href="@string.Concat("www.facebook.com/",item.FacebookPage)">Facebook Page</a>
                                        <i class="fa fa-twitter"></i><a href="@string.Concat("www.twitter.com/", item.TwitterPage)">Facebook Page</a>
                                        <i class="fa fa-instagram"></i><a href="@string.Concat("www.instagram.com/", item.InstagramPage)">Facebook Page</a>
                                        <i class="fa fa-link"></i><a href="@string.Concat("www.whatsin.ph/", item.Name)">Click to view more..</a>
                                    </div>
                                </div>
                            </div>
                        } */
                        
            

})();