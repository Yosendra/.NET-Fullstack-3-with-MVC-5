var GigsController = function () {
    // we seperate logic for handling event to a function "toggleAttendance"
    // then we use it when subscribe the click event -> $(".js-toggle-attendance").click(toggleAttendance);)

    // this is the promoted variable, it like field in C# (private variable in a class)
    var button;
    var gigId;

    // it is like constructor of the class (let us just assume like that)
    var init = function () {
        $(".js-toggle-attendance").click(toggleAttendance);
    };

    var toggleAttendance = function (e) {
        /* promote these to module level,
         * currently it is still local scope for toggleAttendance only
         * meanwhile we want the button & gigId to be used in the other private function
         * like done() function because it needs button element inside it
        */ 
        //var button = $(e.target);
        //var gigId = button.data("gig-id");

        button = $(e.target);
        gigId = button.data("gig-id");

        if (button.hasClass("btn-light")) {
            $.post("/api/attendances", { gigId })
                .done(done)
                .fail(fail)
        } else {
            $.ajax({
                url: "/api/attendances/" + gigId,
                method: "DELETE",
            })
                .done(done)
                .fail(fail);
        }
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
