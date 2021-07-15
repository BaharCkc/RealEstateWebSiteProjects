$("#deleteAnnouncement").click(function () {

    var Id = $(this).attr("data-id");
    var closestTR = $(this).closest("#announcementCard");

    swal({
        text: "İlan silinecek emin misiniz?",
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
                url: '/Announcement/DeleteAnnouncement?Id=' + Id,
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
                },
                error: function (xhr) {
                    if (xhr.status == 403) {
                        window.location.href = "/Account/AccessDenied";
                    }
                }
            });
        }

    });

});