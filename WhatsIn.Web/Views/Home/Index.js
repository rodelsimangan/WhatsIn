(function () {

    abp.ui.setBusy(
             $('#sidebar'),
             abp.ajax({
                 url: abp.appPath + 'Home/GetSidebarCategories',
                 type: 'GET',
                 datatype: "JSON ",
                 success: function (response) {
                     $('#sidebar').empty();
                     var rows = "";
                     //$.each(response.stores, function (i, item) {
                     rows = rows + "<a href=\"#\" class=\"list-group-item sidebarlink active\">"
                                 + "<i class=\"icon-dashboard\"></i> Filter</a>"
                                 + "<a href=\"#categories\" class=\"list-group-item sidebarlink\" data-parent=\"#sidebar\">"
                                 + "<i class=\"icon-group\"></i> Categories</a>"                        
                                 + "<div id=\"categories\" class=\"list-group subitem collapse\"></div>"

                     for (var i = 0; i < response.length; i++) {
                         var item = response[i];

                         rows = rows + "<a href=\"#\" class=\"list-group-item\">"
                                     + " <i class=\"icon-caret-right\"></i> " + item.name
                                     + "</a>";
                        
                     };
                     console.log(rows);
                     $('#sidebar').append(rows);
                 },
             })
         );

   /* $('#sidebar > a').on('click', function (e) {
        e.preventDefault();

        if (!$(this).hasClass("active")) {
            var lastActive = $(this).closest("#sidebar").children(".active");
            lastActive.removeClass("active");
            lastActive.next('div').collapse('hide');
            $(this).addClass("active");
            $(this).next('div').collapse('show');

        }
    }); */

    abp.ui.setBusy(
              $('#SearchHomeArea'),
              abp.ajax({
                  url: abp.appPath + 'Home/Result',
                  type: 'GET',
                  datatype: "JSON ",
                  success: function (response) {
                      $('#SearchResult').empty();
                      var rows = "";
                      //$.each(response.stores, function (i, item) {
                      for (var i = 0; i < response.stores.length; i++) {
                          var item = response.stores[i];
                            var ctr = i % 5;
                            
                            if (ctr == 0)
                            {
                                rows = rows + "<div class=\"row\">";
                            }

                            rows = rows + "<div class=\"col-xs-2\">"
                                        + "<a href=\"" + "http://localhost:10179/Home/?storename=" + item.name + "\" target=\"_blank\">"
                                        + "<img class=\"img-responsive\" alt=\"No Image\" src=\"" + "/Uploads/Logos/" + item.logoPath + "\" />"
                                        + "</a></div>";
                         

                            if ((ctr == response.stores.length - 1) || (ctr == 2))
                            {
                             rows = rows + "</div><div class=\"row\">&nbsp;</div>";
                            }                            
                      };
                      $('#SearchResult').append(rows);
                  },
              })
          );

   


})   
();
$('.sidebarlink').on('click', function (e) {
    e.preventDefault();

    if (!$(this).hasClass("active")) {
        var lastActive = $(this).closest("#sidebar").children(".active");
        lastActive.removeClass("active");
        lastActive.next('div').collapse('hide');
        $(this).addClass("active");
        $(this).next('div').collapse('show');

    }
});
/*
$(document).on('click', '.sidebarlink', function (e) {
    
    e.preventDefault();
    alert("1");
    if (!$(this).hasClass("active")) {
        var lastActive = $(this).closest("#sidebar").children(".active");
        lastActive.removeClass("active");
        lastActive.next('div').collapse('hide');
        $(this).addClass("active");
        $(this).next('div').collapse('show');

    }
}); */



