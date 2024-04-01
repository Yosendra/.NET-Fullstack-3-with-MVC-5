function initGigs() {
    $(".js-toggle-attendance").click(function (e) {
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
    });
}