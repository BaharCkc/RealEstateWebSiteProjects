$("#UpdateAnnouncementForm").submit(function (event) {
    event.preventDefault();
    debugger;
    var formValue = (this);

    swal({
        text: "İlan güncellencek, emin misiniz?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger ml-3',
        buttonsStyling: false,
        closeOnConfirm: false,
        closeOnCancel: true

    }).then(function (result) {
        if (result.value) {
            $.ajax({
                method: "POST",
                url: "/Announcement/UpdateAnnouncement",
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: new FormData(formValue),
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    //$.blockUI({ message: $('#domMessage') });
                }
            }).done(function (d) {
                if (d.failed == true) {
                    toastr.error(d.message, "Hata");
                }
                else {
                    debugger;
                    toastr.success(d.message, "Başarılı");


                    window.setTimeout(() => {
                        window.location.href = '/Announcement/MyAnnouncementList';
                    }, 2000);
                }

            }).fail(function (xhr) {
                toastr.warning("Bağlantı hatası oluştu, lütfen tekrar deneyiniz.", "Hata");

            }).always(function () {
                //$.unblockUI();
            });
        }

    });

});