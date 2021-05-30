
$("#container-main").removeClass("container");

/*document.body.addEventListener("wheel", function (e) {
    let float = (e.deltaY > 0 && e.clientY > 0 ? -0.1 : 0.1);
    if ($("body").css("width") < "225px")
        $("#image-topcenter").css("opacity", (parseFloat($("#image-topcenter").css("opacity")) + float).toString());
});*/

var pastscroll = 0;

window.addEventListener("scroll", function (e) {
    let float = (this.scrollY > pastscroll ? -0.01 : 0.01);
    pastscroll = this.scrollY;
    //alert("scrolled");
    if ($("body").css("width") < "225px")
        $("#image-topcenter").css("opacity", (parseFloat($("#image-topcenter").css("opacity")) + float).toString());
});