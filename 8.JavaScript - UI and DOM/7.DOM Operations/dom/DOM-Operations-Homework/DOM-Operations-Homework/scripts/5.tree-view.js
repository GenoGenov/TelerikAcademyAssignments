window.onload = function () {
    document.getElementById('root-list').addEventListener('click', function (ev) {
        if (ev.target instanceof HTMLLIElement && ev.target.firstElementChild instanceof HTMLUListElement) {
            if (ev.target.className.indexOf('expanded') > -1) {
                ev.target.classList.remove('expanded');
            } else {
                ev.target.classList.add('expanded');
            }
        }
    });
}
