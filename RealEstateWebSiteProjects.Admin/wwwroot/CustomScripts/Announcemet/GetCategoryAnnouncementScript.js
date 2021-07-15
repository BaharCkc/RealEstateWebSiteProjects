$(".GetCategory").click(function () {

    var Id = $(this).attr("data-id");
    debugger;

    $.ajax({
        method: "POST",
        url: "/Announcement/GetAnnoucementByCategoryId?Id=" + Id,
        beforeSend: function () {

        }
    }).done(function (d) {
        if (d.failed == true) {
            toastr.error(d.message, "Hata");
        }
        else {

            toastr.success("Seçilen kategoriye aite ilanlar getirildi.", "Başarılı");
            setTimeout(function () {
                debugger;
                $('#partialAnnouncementList').html(d);
            }, 500);
        }

    }).fail(function (xhr) {
        if (xhr.status == 403) {
            window.location.href = "/Home/NotFoundPage";
        }
    }).always(function () {

    });


});
$(".GetType").click(function () {

    var Id = $(this).attr("data-id");
    debugger;

    $.ajax({
        method: "POST",
        url: "/Announcement/GetAnnoucementByTypeId?Id=" + Id,
        beforeSend: function () {

        }
    }).done(function (d) {
        if (d.failed == true) {
            toastr.error(d.message, "Hata");
        }
        else {

            toastr.success("Seçilen tipe aite ilanlar getirildi.", "Başarılı");
            setTimeout(function () {
                debugger;
                $('#partialAnnouncementList').html(d);
            }, 500);
        }

    }).fail(function (xhr) {
        if (xhr.status == 403) {
            window.location.href = "/Home/NotFoundPage";
        }
    }).always(function () {

    });


});
function changeFunc() {
    var selectBox = document.getElementById("selectBox");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    //alert(selectedValue);
    debugger;
    $.ajax({
        method: "POST",
        url: "/Announcement/GetAnnoucementByDate?dateValue=" + selectedValue,
        beforeSend: function () {

        }
    }).done(function (d) {
        if (d.failed == true) {
            toastr.error(d.message, "Hata");
        }
        else {

            toastr.success("İlanlar getirildi.", "Başarılı");
            setTimeout(function () {
                debugger;
                $('#partialAnnouncementList').html(d);
            }, 500);
        }

    }).fail(function (xhr) {
        if (xhr.status == 403) {
            window.location.href = "/Home/NotFoundPage";
        }
    }).always(function () {

    });
}