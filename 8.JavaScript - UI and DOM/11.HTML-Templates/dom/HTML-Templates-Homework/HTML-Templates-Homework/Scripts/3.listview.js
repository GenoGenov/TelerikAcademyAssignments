(function ($) {
    $.fn.listview = function (items) {
        var $this = $(this);
        var template = $('#' + $this.data('template'));

        var templateCompiled = Handlebars.compile(template.html());
        $(items).each(function (index, element) {
            $this.append(templateCompiled(element));
        });


        template.remove();

        return $this;
    }
}(jQuery));

var books = [
    { id: 1, title: 'title1' },
    { id: 2, title: 'title2' },
    { id: 3, title: 'title3' },
]

var students = [
    { number: '1', name: 'name1', mark: 'mark1' },
    { number: '2', name: 'name2', mark: 'mark2' },
    { number: '3', name: 'name3', mark: 'mark3' },
    { number: '4', name: 'name4', mark: 'mark4' },
    { number: '5', name: 'name5', mark: 'mark5' },
]

//$('#books-list').listview(books);

$('#students-table').listview(students);

$('table').css({
    border: '1px solid black',
    'border-collapse': 'collapse'
}).find('td,th').css({
    border: '1px solid black'
});


