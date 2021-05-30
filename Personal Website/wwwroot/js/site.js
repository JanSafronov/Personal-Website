// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function openSelection() {
    $("#item-select").toggle();

}

function closeSelection() {
    $("#item-select").css("display", "none");
}

document.body.addEventListener("click", (e) => { 
    let target = document.getElementById(e.target.id);
    let op = $("#nav-item-o > *").get();
    op.push(...$("#item-select > *").get());
        
    if (op.findIndex(t => t == target) == -1) { 
        closeSelection();
    } 
});
