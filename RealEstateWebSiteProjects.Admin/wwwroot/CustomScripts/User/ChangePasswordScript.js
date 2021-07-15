$("#changePasswordForm").submit(function (event) {
    event.preventDefault();
    var oldPass = $("#oldPass").val();
    var newPass = $("#newPass").val();
    var confirmPass = $("#confirmPass").val();
    debugger; 
    if (oldPass == "" && newPass == "" && confirmPass == "") {
        toastr.error("Bütün alanları doldurunuz!", "Hata"); }
    else {
        if (newPass != confirmPass) { toastr.error("Yeni şifre ile tekrar eden yeni şifre aynı olmalıdır!", "Hata"); }
        else {
            if (oldPass == newPass) { toastr.error("Yeni şifre ile eski şifre aynı olamaz!", "Hata"); }
            else {
                var formValue = (this);

                swal({
                    text: "Şifre değiştirilecek, emin misiniz?",
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
                            url: "/User/ChangePassword",
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
            }

        }


    }

});