var GigsController = function () {
    // we seperate logic for handling event to a function "toggleAttendance"

    var init = function () {
        $(".js-toggle-attendance").click(toggleAttendance);
    };

    var toggleAttendance = function (e) {
        let button = $(e.target);
        let gigId = button.data("gig-id");

        if (button.hasClass("btn-light")) {
            $.post("/api/attendances", { gigId })
                .done(function () {
                    button.removeClass("btn-light")
                        .addClass("btn-info")
                        .text("Going");
                })
                .fail(function () {
                    alert("Something failed!");
                })
        } else {
            $.ajax({
                url: "/api/attendances/" + gigId,
                method: "DELETE",
            })
                .done(function () {
                    button.removeClass("btn-info")
                        .addClass("btn-light")
                        .text("Going?")
                })
                .fail(function () {
                    alert("Something failed!");
                });
        }
    };

    return {
        init: init
    }
}();
