window.onload = function () {
    var toDoList = document.getElementById('to-do-list');
    var list = document.getElementById('list-items');
    var itemsInfo = document.getElementById('list-count-info');
    var addItemBtn = document.getElementById('add-item-btn');
    var itemContent = document.getElementById('new-item-content');
    var hideBtn = document.getElementById('visibility-toggle-btn');
    hideBtn.addEventListener('click', function () {
        if (list.style.display !== 'none') {
            list.style.display = 'none';
            this.innerHTML = 'Show TO-DO list';
        } else {
            list.style.display = '';
            this.innerHTML = 'Hide TO-DO list';
        }
    });

    var pending = 0,
        completed = 0;

    function notifyInfoDataChanged() {
        itemsInfo.innerHTML = 'Pending: ' + pending + ' , Completed: ' + completed;
    }

    addItemBtn.addEventListener('click', function () {
        var itemValue = itemContent.value;
        if (itemValue.length > 0) {
            var item = document.createElement('li');
            item.className = 'list-style-pending';
            var content = document.createElement('span');
            var deleteBtn = document.createElement('button');
            deleteBtn.classList.add('delete-list-item');
            deleteBtn.title = 'Delete item';
            deleteBtn.addEventListener('click', function () {
                var className = this.parentElement.className;
                list.removeChild(this.parentElement);
                if (className === 'list-style-completed') {
                    completed--;
                } else {
                    pending--;
                }
                notifyInfoDataChanged();
            });
            var markCompleted = document.createElement('button');
            markCompleted.classList.add('mark-completed');
            markCompleted.title = 'Mark as completed';
            markCompleted.addEventListener('click', function () {
                this.parentElement.className = 'list-style-completed';
                pending--;
                completed++;
                notifyInfoDataChanged();
            });
            content.classList.add('list-item-content');
            content.innerHTML = itemValue;
            item.appendChild(content);
            item.appendChild(deleteBtn);
            item.appendChild(markCompleted);

            list.appendChild(item);
            itemContent.value = '';
            pending++;
        } else {
            alert('Item name must be atleast 1 symbol long!');
        }
        notifyInfoDataChanged();
    });
}