function createCalendar(selector, events) {
    var DAYS_IN_MONTH = 30;

    var calendar = document.querySelector(selector);
    var dayBox = document.createElement('div');
    var date = document.createElement('span');
    date.style.display = 'inline-block';
    date.style.backgroundColor = '#ccc';
    date.style.width = '100%';
    dayBox.style.width = window.innerWidth / 7.5 + 'px';
    dayBox.style.height = window.innerWidth / 7.5 + 'px';
    dayBox.style.display = 'inline-block';
    dayBox.style.border = '1px solid black';
    dayBox.style.margin = '0';
    dayBox.appendChild(date);
    dayBox.innerHTML+='&nbsp;'
    dayBox.className = 'day-item';
    var selected = null;

    for (var i = 0; i < DAYS_IN_MONTH; i++) {
        var dayOfWeek = new Date(2014, 6, (i + 1)).toDateString().substr(0, 3);
        dayBox.firstElementChild.innerHTML = dayOfWeek + ' ' + (i + 1) + ' June 2014';
        calendar.appendChild(dayBox.cloneNode(true));
    }

    for (var i = 0; i < events.length; i++) {
        var event = events[i];
        calendar.childNodes[event.date].innerHTML += event.title;
    }

    calendar.addEventListener('click', function (ev) {
        if (ev.target instanceof HTMLDivElement) {

            if (selected) {
                selected.style.backgroundColor = '';
                selected.firstElementChild.style.backgroundColor = '#ccc';
                selected.className=selected.className.replace('selected', '');
            }

            var date = ev.target.firstElementChild;
            date.style.backgroundColor = '';
            ev.target.style.backgroundColor = 'silver';
            selected = ev.target;
            selected.className += ' selected';
        }
    });

    calendar.addEventListener('mouseover', function (ev) {
        if (ev.target instanceof HTMLDivElement &&
            ev.target.className.indexOf('day-item') > -1 &&
            ev.target.className.indexOf('selected') < 0) {

            var date = ev.target.firstElementChild;
            date.style.backgroundColor = 'purple';
        }
    });

    calendar.addEventListener('mouseout', function (ev) {
        if (ev.target instanceof HTMLDivElement &&
            ev.target.className.indexOf('day-item') > -1 &&
            ev.target.className.indexOf('selected') < 0) {

            var date = ev.target.firstElementChild;
            date.style.backgroundColor = '#ccc';
        }
    });
}