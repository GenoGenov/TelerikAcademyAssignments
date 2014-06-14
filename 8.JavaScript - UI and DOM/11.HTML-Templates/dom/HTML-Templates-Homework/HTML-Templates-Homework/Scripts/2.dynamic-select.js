var items = [{
        value: 1,
        text: 'One'
    }, {
        value: 2,
        text: 'Two'
    }, {
        value: 3,
        text: 'Three'
    }
];

var template = $('#dynamic-select');

var templateCompiled = Handlebars.compile(template.html());

function selectTemplate(items) {
    return templateCompiled({
        items: items
    });
}

var selectHTML = selectTemplate(items);

template.after(selectHTML);

template.remove();