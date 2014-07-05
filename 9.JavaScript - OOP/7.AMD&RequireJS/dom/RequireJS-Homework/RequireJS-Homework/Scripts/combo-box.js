var controls = controls || {};
define(['jquery', 'handlebars'], function($, Handlebars) {
    controls.ComboBox = (function(items) {
        var compiledHtml;

        (function($) {
            var selecting = false;
            $.fn.ComboBox = function() {
                var $this = $(this);

                if (!$this.find('.current').length) {
                    $this.find('.person-item').first().addClass('current');
                }
                var currentHolder = $('<div/>').attr('id', 'current-shown').prependTo($this);
                var personsList = $this.find('#persons-list');
                personsList.find('.current').appendTo(currentHolder);
                personsList.find('.person-item').hide();
                currentHolder.on('click', 'div', function() {
                    personsList.find('.person-item').show();
                    selecting = true;
                });
                personsList.on('click', 'div', function() {
                    if (selecting) {
                        currentHolder.find('.current').removeClass('current').appendTo(personsList);
                        var $that = $(this);
                        $that.addClass('current').appendTo(currentHolder);
                        personsList.find('.person-item').hide();
                        selecting = false;
                    }
                });
                return $this;
            };
        }($));

        var compile = function(template) {
            var handlebarsTemplate = Handlebars.compile(template);
            var html = handlebarsTemplate({ items: items });
            compiledHtml = html;
            return html;
        };
        return {
            compile: compile,
            render: function(selector) {
                $(selector).remove();
                $('<div/>').attr('id', 'persons-list-combo')
                    .append($('<div/>').attr('id', 'persons-list').html(compiledHtml))
                    .ComboBox().appendTo('body');
            }
        };
    });
    return controls;
});