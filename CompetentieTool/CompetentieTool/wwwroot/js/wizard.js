function bootstrapTabControl() {
    var i, pane = $('.tab-pane');
    // next
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