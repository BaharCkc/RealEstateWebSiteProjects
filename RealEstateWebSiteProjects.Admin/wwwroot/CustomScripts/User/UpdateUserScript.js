$("#updateUserForm").submit(function (event) {
    event.preventDefault();
    var fullname = $("#fullName").val();
    var regname = $("#regName").val();
    //if (fullname == "") { $("#fullNameError").text("Adı Soyadı Boş Geçilemez"); }
    //else {
    //    if (regname == "") { $("#regNameError").text("Kullanıcı Adı Boş Geçilemez"); }
    //    else {
            var formValue = (this);

            swal({
                text: "Kullanıcı güncellencek, emin misiniz?",
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
                    var token = $('input[name="__RequestVerificationToken"]').val();
                    var formdatas = new FormData(formValue);
                    formdatas.append('__RequestVerificationToken', token);
                    $.ajax({
                        method: "POST",
                        url: "/User/UpdateUser",
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
                            if (d.status == '4') {
                                //toastr.error(d.message, "Hata");
                                for (u in d.validationErrors) {
                                    var c = d.validationErrors[u].propertyName,
                                        l = d.validationErrors[u].message;
                                    $('#' + c).text(l);
                                }
                            } else {
                                toastr.success(d.message, "Başarılı");

                                window.setTimeout(() => {
                                    window.location.href = '/User/Index';
                                }, 2000);
                            }                            
                        }

                    }).fail(function (xhr) {
                        toastr.warning("Bağlantı hatası oluştu, lütfen tekrar deneyiniz.", "Hata");

                    }).always(function () {
                        //$.unblockUI();
                    });
                }

            });
    //    }


    //}

});