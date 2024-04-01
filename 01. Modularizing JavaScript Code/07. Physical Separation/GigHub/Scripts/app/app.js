// Move AttendanceService module to attendanceService.js file
//var AttendanceService = function () {
//    var createAttendance = function (gigId, done, fail) {
//        $.post("/api/attendances", { gigId })
//            .done(done)
//            .fail(fail)
//    };

//    var deleteAttendance = function (gigId, done, fail) {
//        $.ajax({
//            url: "/api/attendances/" + gigId,
//            method: "DELETE",
//        })
//            .done(done)
//            .fail(fail);
//    };

//    return {
//        createAttendance,
//        deleteAttendance
//    };
//}();



// Move GigsController module to gigsController.js file
//var GigsController = function (attendanceService) {
//    var button;
//    var gigId;

//    var init = function () {
//        $(".js-toggle-attendance").click(toggleAttendance);
//    };

//    var toggleAttendance = function (e) {
//        button = $(e.target);
//        gigId = button.data("gig-id");

//        if (button.hasClass("btn-light"))
//            attendanceService.createAttendance(gigId, done, fail);
//        else
//            attendanceService.deleteAttendance(gigId, done, fail);
//    };

//    var done = function () {
//        var text = button.text() == "Going"
//            ? "Going?"
//            : "Going";
//        button
//            .toggleClass("btn-info")
//            .toggleClass("btn-light")
//            .text(text);
//    };

//    var fail = function () {
//        alert("Something failed!");
//    };

//    return { init };
//}(AttendanceService);
