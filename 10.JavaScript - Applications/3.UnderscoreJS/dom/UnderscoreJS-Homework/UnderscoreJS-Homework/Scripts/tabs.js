define(['jquery', 'handlebars'], function($, Handlebars) {
    var Tabs = (function(items) {
        var compiledHtml;

        (function($) {
            $.fn.tabs = function() {
                var $this = this,
                    $parentNode = $this;
                $this.addClass('tabs-container');
                $this.find('.tab-item').css('width', 100/$this.find('.tab-item').length+'%');
                $this.find('.tab-item-content')
                    .hide();

                $this.find('.tab-item-title')
                    .on('click', function(ev) {
                        var $this = $(this);
                        $parentNode.find('.current')
                            .removeClass('current');
                        $parentNode.find('.tab-item-content')
                            .hide();
                        $this.parent()
                            .addClass('current')
                            .find('.tab-item-content')
                            .show();
                    });
                $this.find('.current .tab-item-title')
                    .click();

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
                $('<div/>').attr('id', 'tabs-controll')
                    .html(compiledHtml)
                    .tabs().appendTo('body');
            }
        };
    });
    return Tabs;
});