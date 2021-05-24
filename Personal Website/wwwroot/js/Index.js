
$("#container-main").removeClass("container");

document.body.addEventListener("wheel", function (e) {
    let float = (e.deltaY > 0 && e.clientY > 0 ? -0.1 : 0.1);
    if ($("body").css("width") < "225px")
        $("#image-topcenter").css("opacity", (parseFloat($("#image-topcenter").css("opacity")) + float).toString());
});