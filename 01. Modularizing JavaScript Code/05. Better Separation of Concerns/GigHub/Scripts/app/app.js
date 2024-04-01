var GigsController = function () {
    var button;
    var gigId;

    var init = function () {
        $(".js-toggle-attendance").click(toggleAttendance);
    };

    // now toggleAttendance function is more concise
    var toggleAttendance = function (e) {
        button = $(e.target);
        gigId = button.data("gig-id");

        if (button.hasClass("btn-light"))
            createAttendance();         // refactor
        else
            deleteAttendance();         // refactor
    };

    var createAttendance = function () {
        $.post("/api/attendances", { gigId })
            .done(done)
            .fail(fail)
    };

    var deleteAttendance = function () {
        $.ajax({
            url: "/api/attendances/" + gigId,
            method: "DELETE",
        })
            .done(done)
            .fail(fail);
    };

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

    return {
        init: init
    }
}();
