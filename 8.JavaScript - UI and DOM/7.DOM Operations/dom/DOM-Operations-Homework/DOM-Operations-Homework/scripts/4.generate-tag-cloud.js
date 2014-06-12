window.onload = function () {
    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];

    function generateTagCloud(tags, minSize, maxSize) {
        var container = document.createElement('div');
        container.id = 'tag-cloud';
        container.style.width = 350 + 'px';
        var tagsFrequency = [];

        var tagsSorted = [];
        for (var i = 0; i < tags.length; i++) {
            if (tagsFrequency[tags[i].toLowerCase()]) {
                tagsFrequency[tags[i].toLowerCase()].frequency += 1;
            } else {
                tagsFrequency[tags[i].toLowerCase()] = { frequency: 1, name: tags[i].toLowerCase() };
            }
        }

        for (var i in tagsFrequency) {
            tagsSorted.push(tagsFrequency[i]);
        }
        console.log(tagsSorted);
        tagsSorted.sort(function (a, b) {
            return b.frequency - a.frequency;
        });
        var multiplier = (maxSize - minSize) / tagsSorted[0].frequency;
        var span = document.createElement('span');
        for (var i = 0; i < tagsSorted.length; i++) {
            span.innerHTML = tagsSorted[i].name;
            span.style.display = 'inline-block';
            span.style.fontSize = tagsSorted[i].frequency * multiplier + minSize + 'px';
            span.style.margin = '5px';

            container.appendChild(span.cloneNode(true));
        }
        return container;
    }

    var tagCloud = generateTagCloud(tags, 17, 42);

    document.body.appendChild(tagCloud);

}