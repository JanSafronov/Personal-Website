
$("select").on("change", function () {
    $("input[Name='Mail']").toggle();
});

setInterval(function () {
    document.getElementById("cookie").innerText = document.cookie;
}, 10);