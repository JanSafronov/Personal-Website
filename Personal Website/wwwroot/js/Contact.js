
$("select").on("change", function () {
    $("input[Name='Mail']").toggle();
});

/**
 * 
 * @param {HTMLFormElement} form
 */
function HTTPMessageRequest(form) {
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.open("POST", "/Contact");
    xmlhttp.send(new FormData(form));

    xmlhttp.onreadystatechange = function () {
        if (this.status == 1) {
            alert("Message sent");
        }
        else {
            alert("Error in input format, please try again");
        }
    }
}