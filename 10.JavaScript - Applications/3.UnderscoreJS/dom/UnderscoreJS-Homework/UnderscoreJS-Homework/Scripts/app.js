(function() {
    require.config({
            paths: {
                'jquery': 'libs/jquery-2.1.1',
                'underscore': 'libs/underscore',
                'student': 'student',
                'animal': 'animal',
                'handlebars': 'libs/handlebars',
                'tabs':'tabs'
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
        }
    );

    require(['task-1', 'task-2', 'task-3', 'task-4', 'task-5', 'task-6', 'task-7', 'jquery','tabs'], function (task1, task2, task3, task4, task5, task6, task7, $, Tabs) {
        var tasks = [
            task1,task2,task3,task4,task5,task6,task7
        ];
        var tabs = Tabs(tasks);
        var template = $("#template").html();
        tabs.compile(template);
        tabs.render('#person-template');
    });
}());