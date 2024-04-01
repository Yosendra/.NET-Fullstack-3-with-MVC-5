// Notice this
var AttendanceService = function () {
    // notice we define gigId parameter here
    var createAttendance = function (gigId, done, fail) {
        $.post("/api/attendances", { gigId })
            .done(done)
            .fail(fail)
    };

    // notice we define gigId parameter here
    var deleteAttendance = function (gigId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + gigId,
            method: "DELETE",
        })
            .done(done)
            .fail(fail);
    };

    return {
        createAttendance,
        deleteAttendance
    };
}();

// notice, we define parameter here
var GigsController = function (attendanceService) {
    var button;
    var gigId;

    var init = function () {
        $(".js-toggle-attendance").click(toggleAttendance);
    };

    var toggleAttendance = function (e) {
        button = $(e.target);
        gigId = button.data("gig-id");

        if (button.hasClass("btn-light"))
            //createAttendance();
            attendanceService.createAttendance(gigId, done, fail);       // call through service object
        else
            //deleteAttendance();
            attendanceService.deleteAttendance(gigId, done, fail);       // call through service object
    };

    // Move both of these to AttendanceService module
    //var createAttendance = function () {
    //    $.post("/api/attendances", { gigId })
    //        .done(done)
    //        .fail(fail)
    //};

    //var deleteAttendance = function () {
    //    $.ajax({
    //        url: "/api/attendances/" + gigId,
    //        method: "DELETE",
    //    })
    //        .done(done)
    //        .fail(fail);
    //};

    var done = function () {
        var text = button.text() == "Going"
            ? "Going?"
            : "Going";
        button
            .toggleClass("btn-info")
            .toggleClass("btn-light")
            .text(text);
    };

    var fail = function () {
        alert("Something failed!");
    };

    return { init };
}(AttendanceService);   // notice this, we pass it as argument of IIFE
