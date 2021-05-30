
$("header > nav").removeClass("mb-3");
$("#container-main").removeClass("container");

var pastscroll = 0;

window.addEventListener("scroll", function (e) {
    let float = (this.scrollY > pastscroll ? -0.01 : 0.01);
    pastscroll = this.scrollY;
    if ($("body").css("width") < "225px")
        $("#image-topcenter").css("opacity", (parseFloat($("#image-topcenter").css("opacity")) + float).toString());
});