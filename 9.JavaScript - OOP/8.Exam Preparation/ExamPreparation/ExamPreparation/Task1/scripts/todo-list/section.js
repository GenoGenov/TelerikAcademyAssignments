define(function() {
    'use strict';
    var Section;
    Section = (function() {
        function Section(title) {
            this._title = title;
            this._items = [];
        }

        Section.prototype = {
            add: function(item) {
                this._items.push(item);
                return this;
            },
            getData: function() {
                var itemData = [];
                for (var i = 0, len = this._items.length; i < len; i++) {
                    var item = this._items[i];
                    itemData.push(item.getData());
                }
                return {
                    title: this._title,
                    items: itemData
                };
            }
        };
        return Section;
    }());
    return Section;
});