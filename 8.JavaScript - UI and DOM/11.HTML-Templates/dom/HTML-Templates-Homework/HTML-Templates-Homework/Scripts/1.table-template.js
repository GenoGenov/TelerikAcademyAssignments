window.onload = function () {
    var courses = [
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },
        { title: 'Course Introduction', date1: 'Wed, Jul 14 22:30 2014', date2: 'Wed, Jul 14 22:30 2014' },

    ];

    var table = $('#table-template');

    var templateCompiled = Handlebars.compile(table.html());
    table.after(templateCompiled({
        courses: courses
    }));

    table.remove();

    $('body')
        .find('table')
        .css({
            border: '1px solid black',
            'border-collapse': 'collapse'
        })
        .find('thead')
        .css({
            'background-color': '#ccc'
        })
        .parent()
        .find('th,td')
        .css({
            border: '1px solid black'
        })
        .parents('tr:nth-of-type(2n)').css({
            'background-color': '#ccc'
        });
};