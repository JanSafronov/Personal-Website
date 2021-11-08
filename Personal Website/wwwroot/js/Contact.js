
$("select").on("change", function () {
    $("input[Name='Mail']").toggle();
});

/**
 * 
 * @param {HTMLFormElement} form
 */
function HTTPMessageRequest(form) {
    let xmlhttp = new XMLHttpRequest();

    xmlhttp.onreadystatechange = function () {
        alert(this.status);
        if (this.readyState == 4) {
            if (this.status == 1) {
                alert("Message sent");
            }
            if (this.status == 0) {
                alert("Please wait when 1 hour passes since your last message");
            }
            if (this.status == 2) {
                alert("Error in input format, please try again");
            }
        }
    }

    xmlhttp.open("POST", "/Contact");
    xmlhttp.send(new FormData(form));

}

function HTTPMessageDelete() {
    let xmlhttp = new XMLHttpRequest();
    xmlhttp.open("GET", "/Contact");
    xmlhttp.send();

    xmlhttp.onreadystatechange = function () {
        if (this.readyState == 4) {
            if (this.status == 0) {
                alert("No recent message detected");
            }
            if (this.status == 1) {
                alert("Message deleted");
            }
        }
    }
}