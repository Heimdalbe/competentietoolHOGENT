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
        if (i === pane.length - 2) {
            $('.nexttab').hide()
        }
    });
}



bootstrapTabControl();



// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0; // For Safari
    document.documentElement.scrollTop = 0; // For Chrome, Firefox, IE and Opera
} 