$("#addUserForm").submit(function (event) {
    event.preventDefault();
    var fullname = $("#fullName").val();
    var regname = $("#regName").val();
    var rolename = $("#RoleId").val();
    debugger;

    var formValue = (this);
    swal({
        text: "Kullanıcı eklenecek, emin misiniz?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
        confirmButtonClass: 'btn btn-success',
        cancelButtonClass: 'btn btn-danger ml-3',
        buttonsStyling: false,
        closeOnConfirm: false,
        closeOnCancel: true

    }).then(function (willDelete) {
        if (willDelete) {
            var token = $('input[name="__RequestVerificationToken"]').val();
            var formdatas = new FormData(formValue);
            formdatas.append('__RequestVerificationToken', token);
            $.ajax({
                method: "POST",
                url: "/User/AddUser",
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: new FormData(formValue),
                cache: false,
                contentType: false,
                processData: false,
                beforeSend: function () {
                    //$.blockUI({ message: $('#domMessage') });
                }
            }).done(function (d) {
                debugger;
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
                        debugger;
                        toastr.success(d.message, "Başarılı");

                        window.setTimeout(() => {
                            window.location.href = '/User/Index';
                        }, 2000);
                    }

                }

            }).always(function () {
                //$.unblockUI();
            });
        }

    });

});