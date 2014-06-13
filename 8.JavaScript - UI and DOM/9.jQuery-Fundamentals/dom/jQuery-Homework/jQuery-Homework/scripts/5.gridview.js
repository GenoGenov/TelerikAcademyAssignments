window.onload = function () {
    var container = $('#container');
    container.css({
        position: 'relative'
    })
    var gridIndex = 1;

    function createRowForm(element, colCount, index) {
        element.css({
            position: 'relative'
        })
        var rowForm = $('<form>').attr('class', 'create-row-' + index).css({
            position: 'absolute',
            top: '0',
            left: '0',
            width: '1000px'
        });
        for (var i = 0; i < colCount; i++) {
            rowForm.append($('<input class=input-' + index + '-' + i + ' type="text">').css({
                display: 'inline-block'
            }));
        }

        rowForm.append($('<label>').html('Normal')).append($('<input type="radio" name="rowType" value="normal">'));
        rowForm.append($('<label>').html('Header')).append($('<input class="isHeader" type="radio" name="rowType" value="header">'));
        rowForm.append($('<label>').html('Grid')).append($('<input class="isGrid" type="radio" name="rowType" value="grid">'));

        var confirmBtn = $('<button class="confirm" type="button">').html('Add').appendTo(rowForm);

        confirmBtn.on('click', function () {
            var $this = $(this);
            var parent = $($this.closest('.grid' + index));
            var isHeader = false;
            var isGrid = false;
            var row = $('<tr>');
            if (parent.find('.isHeader').first().is(':checked')) {
                isHeader = true
            } else if (parent.find('.isGrid').first().is(':checked')) {
                isGrid = true;
            }

            if (isGrid) {
                if (parent.find('.grid' + (index + 1)).length) {
                    alert('No more than one nested grid allowed!');
                    return false;
                }
                gridIndex++;
                createGridView(row, colCount, gridIndex);
                parent.last().append(row);
                rowForm.remove();
                createRowForm(parent.last(), colCount, index);
            } else {
                if (isHeader) {
                    if (parent.find('th').first().length) {
                        alert('No more than one header allowed!');
                        return false;
                    }
                    for (var i = 0; i < colCount; i++) {
                        row.append($('<th>').html(parent.find('.input-' + index + '-' + i).first().val()));
                    }
                    parent.find('thead').first().append(row);
                    rowForm.remove();
                    createRowForm(row, colCount, index);
                } else {
                    for (var i = 0; i < colCount; i++) {
                        row.append($('<td>').html(parent.find('.input-' + index + '-' + i).first().val()));
                        console.log(parent.find('.input-' + index + '-' + i).first().val());
                    }
                    parent.find('.add-row-' + index).first().remove();
                    row.append($('<td>').append($('<button class="add-row-' + index + '">').html('Add row').on('click', function () {
                        createRowForm(row, colCount, index);
                    })));
                    parent.last().append(row);

                    rowForm.remove();
                }
            }
        });
        rowForm.appendTo(element);
    }

    function createGridView(element, colCount, index) {
        var grid = $('<table class="grid' + index + '">').append('<thead>');

        createRowForm(grid, colCount, index);
        grid.appendTo(element);
    }
    createGridView(container, 5, gridIndex);
}