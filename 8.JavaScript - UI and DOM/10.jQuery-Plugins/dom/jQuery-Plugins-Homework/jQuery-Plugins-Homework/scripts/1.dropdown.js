window.onload = function () {
    (function ($) {
        $.fn.dropdown = function () {
            var $this = $(this);
            $this.hide();
            var container = $('<div/>')
                .addClass('dropdown-list-container');

            var options = ($('<ul/>')
                .addClass('dropdown-list-options')).appendTo(container);

            $.each($('option', $this), function (index, value) {
                $('<li/>')
                    .addClass('dropdown-list-option')
                    .addClass('data-value-' + index)
                    .html(value.innerHTML)
                    .appendTo(options);
            });
            $this.after(container);
            return $this;
        }
    }(jQuery));

    $('#dropdown').dropdown();
}