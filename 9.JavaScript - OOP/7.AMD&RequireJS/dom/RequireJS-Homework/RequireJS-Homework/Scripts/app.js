(function() {
    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'handlebars': 'libs/handlebars',
        },
        shim: {
        'handlebars': {
                exports: 'Handlebars',
                init: function() {
                    this.Handlebars = Handlebars;
                    return this.Handlebars;
                }
        }
    }

    });

    require(['jquery', 'combo-box'], function($, controls) {
        var people = [
            { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
            { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" }
        ];
        var comboBox = controls.ComboBox(people);
        var template = $("#person-template").html();
        comboBox.compile(template);
        comboBox.render('#person-template');

    });
}());