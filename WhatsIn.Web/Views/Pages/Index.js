(function() {
    $(function() {

        var _upsertCategoryModal = new app.ModalManager({
            viewUrl: abp.appPath + 'Categories/UpsertCategoryModal',
            scriptUrl: abp.appPath + 'Views/Categories/_UpsertCategoryModal.js',
            modalClass: 'UpsertCategoryModal'
        });

        $('#CreateNewCategoryButton').click(function (e) {
            e.preventDefault();
            _upsertCategoryModal.open();
        });

        $('.UpdateCategoryButton').click(function (e) {
            e.preventDefault();
            var categoryid = $(this).prop('id');
            _upsertCategoryModal.open({ id: categoryid });
        });

        var _categoryService = abp.services.app.category;

        $('.DeleteCategoryButton').click(function (e) {
            e.preventDefault();

            var categoryid = $(this).prop('id');

            abp.message.confirm(
                app.localize('AreYouSureToDeleteTheCategory'),
                function (isConfirmed) {
                    if (isConfirmed) {
                         _categoryService.deleteCategory(categoryid).done(function () {
                            abp.notify.info(app.localize('SuccessfullyDeleted'));
                            location.reload();
                        });
                        alert(categoryid);
                    } 
                }
            );
        });
    });

  
})();