$(".deleteUser").click(function () {

    var id = $(this).attr("data-id");
    var closestTR = $(this).closest("tr");

    swal({
        text: "Kullanıcı silinecek emin misiniz?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger m-l-5',
        buttonsStyling: false
    }).then(function (willDelete) {
        if (willDelete) {
            $.ajax({
                url: '/User/DeleteUser?Id=' + id,
                type: 'POST',
                success: function (d) {
                    if (d.failed == false) {
                        closestTR.fadeOut(1000, function () {
                            closestTR.remove();
                        });

                        toastr.success(d.message, "Başarılı");
                    }
                    else {

                        toastr.error(d.message, "Hata");
                    }
                }
            });
        }

    });

});