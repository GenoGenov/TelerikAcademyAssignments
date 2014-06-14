(function ($) {
    $.fn.listview = function (items) {
        var $this = $(this);

        var templateCompiled = Handlebars.compile($this.html());
        $this.html('');
        $(items).each(function (index, element) {
            $this.append(templateCompiled(element));
        });


        return $this;
    }
}(jQuery));

var students = [
    { number: '1', name: 'name1', mark: 'mark1' },
    { number: '2', name: 'name2', mark: 'mark2' },
    { number: '3', name: 'name3', mark: 'mark3' },
    { number: '4', name: 'name4', mark: 'mark4' },
    { number: '5', name: 'name5', mark: 'mark5' },
];

$('#students-table').listview(students);

$('table').css({
    border: '1px solid black',
    'border-collapse': 'collapse'
}).find('td,th').css({
    border: '1px solid black'
});
