function sendRequest(username, reponame) {
    let address = 'api/commits';

    $.ajax({
        type: "POST",
        dataType: "json",
        url: address,
        data: {user : username, repo : reponame } ,
        success: displayCommits,
        error: errorOnAjax
    })
}
function displayCommits(data) {
    $("#commits").empty();

    $("#commits").append("<h3>Commits<small class='text-muted'></small></h3>")
    $("#commits").append("<div class='table-responsive mt-5'><table class='table table-dark'><thead><tr><th scope='col'>SHA</th><th scope='col'>Timestamp</th><th scope='col'>Committer</th><th scope='col'>Commit Message</th></tr></thead><tbody id='table-body'>");
    $.each(data, function(key, value) {
        var row = '';
        row += "<tr>";
        row += "<td>"+ value.sha.substring(0,6) +"</td>";
        row += "<td>"+ value.whenCommitted.substring(0,10) +"</td>";
        row += "<td>"+ value.committer +"</td>";
        row += "<td>"+ value.commitMessage +"</td>";
        row += "</tr>";
        $("#table-body").append(row);
    })
    $("#commits").append("</tbody></table></div>");
}
function errorOnAjax() {
    console.log("ERROR in ajax request");
}
