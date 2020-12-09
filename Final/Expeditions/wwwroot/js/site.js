// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// This will set up a timer.  It will invoke the execute function every 5 seconds
$(document).ready(function () { window.setInterval(execute, 5000) });

function execute() {
        console.log('Running execute function');
        let address = "/api/stats";

        $.ajax({
                type: "GET",
                dataType: "json",
                url: address,
                success: displayStats,
                error: error
        });
}
function displayStats(data) {
        console.log(data);
        $("#stats").text("Currently tracking " + data.expeditions + " for " + data.peakCount + " peaks, " + data.notClimbed + " of which have never been climbed!");
}
function error() {
        console.log("Error");
}