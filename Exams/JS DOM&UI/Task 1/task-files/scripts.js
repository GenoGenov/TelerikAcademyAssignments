function createImagesPreviewer(selector, items) {

    var container = document.querySelector(selector);
    var previewBox = document.createElement('div');
    var previewImageHolder = document.createElement('div');
    var previewImgTitle = document.createElement('h1');
    var previewImg = document.createElement('img');
    var imgPicker = document.createElement('div');
    var filterLabel = document.createElement('label');
    var filterInput = document.createElement('input');

    filterInput.type = 'text';
    filterInput.style.display = 'block';
    filterInput.style.width = '100%';
    filterLabel.style.display = 'block';
    filterLabel.style.textAlign = 'center';
    filterLabel.innerHTML = 'Filter';
    previewBox.style.position = 'fixed';

    previewImg.src = items[0].url;
    previewImg.style.width = '100%';
    previewImg.style.height = '100%';
    previewImg.style.borderRadius = 20 + 'px';

    previewImageHolder.style.width = window.innerWidth * 0.6 + 'px';
    previewImageHolder.style.height = window.innerHeight * 0.8 + 'px';

    previewImgTitle.style.textAlign = 'center';
    previewImgTitle.innerHTML = items[0].title;

    imgPicker.style.width = window.innerWidth * 0.2 + 'px';
    imgPicker.style.cssFloat = 'right';

    imgPicker.appendChild(filterLabel);
    imgPicker.appendChild(filterInput);

    previewImageHolder.appendChild(previewImgTitle);
    previewImageHolder.appendChild(previewImg);

    previewBox.appendChild(previewImageHolder);

    container.appendChild(previewBox);
    container.appendChild(imgPicker);

    var pickerImagesHolder = document.createElement('div');
    var imgPickerHolder = document.createElement('div');
    var title = document.createElement('strong');
    title.innerHTML = '';
    title.style.display = 'block';
    title.style.textAlign = 'center';
    title.style.fontSize = 19 + 'px';
    var imgItem = document.createElement('img');
    imgItem.src = '';
    imgItem.style.width = '100%';
    imgItem.style.borderRadius = '15px';
    imgPickerHolder.style.padding = '0 15px 0 15px';
    imgPickerHolder.appendChild(title);
    imgPickerHolder.appendChild(imgItem);
    for (var i = 0; i < items.length; i++) {
        imgItem.src = items[i].url;
        title.innerHTML = items[i].title;
        pickerImagesHolder.appendChild(imgPickerHolder.cloneNode(true));
    }

    
    imgPicker.appendChild(pickerImagesHolder);

    imgPicker.addEventListener('click', function (ev) {
        if (ev.target instanceof HTMLImageElement) {
            var element = ev.target.parentElement;
            var image = element.getElementsByTagName('img');
            previewImg.src = image[0].src;

            var title = element.getElementsByTagName('strong');
            previewImgTitle.innerHTML = title[0].innerHTML;
        }
    });

    imgPicker.addEventListener('mouseover', function (ev) {
        if (ev.target instanceof HTMLImageElement) {
            var element = ev.target.parentElement;
            element.style.backgroundColor = '#ccc';
        }
    });

    imgPicker.addEventListener('mouseout', function (ev) {
        if (ev.target instanceof HTMLImageElement) {
            var element = ev.target.parentElement;
            element.style.backgroundColor = '#fff';
        }
    });

    var oldHtml = pickerImagesHolder.innerHTML;

    filterInput.addEventListener('keyup', function (ev) {
        pickerImagesHolder.innerHTML = '';
        var value = this.value;
        console.log(value);
        if (value.length > 0) {
            for (var i = 0; i < items.length; i++) {
                imgItem.src = items[i].url;
                title.innerHTML = items[i].title;
                if (title.innerHTML.toLowerCase().indexOf(value.toLowerCase())>-1) {
                    pickerImagesHolder.appendChild(imgPickerHolder.cloneNode(true));
                }
            }
        } else {
            pickerImagesHolder.innerHTML = oldHtml;
        }

    });


}