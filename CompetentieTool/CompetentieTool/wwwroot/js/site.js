// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function bootstrapTabControl() {
    var i, pane = $('.tab-pane');
    $('.nexttab').on('click', function () {
        for (i = 0; i < pane.length; i++) {
            if ($(pane[i]).hasClass('active') == true) {
                break;
            }
        }
        if (i < pane.length - 1) {
            $(pane[i]).removeClass('active');
            $(pane[i + 1]).addClass('active');
        }
    });
}

bootstrapTabControl();