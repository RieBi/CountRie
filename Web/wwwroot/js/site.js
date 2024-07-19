// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))

document.querySelectorAll('textarea').forEach(area => {
    area.style.overflowY = "hidden";
    area.style.height = 0;
    area.oninput = function () {
        area.style.height = 0;
        area.style.height = (this.scrollHeight) + "px";
    }
});