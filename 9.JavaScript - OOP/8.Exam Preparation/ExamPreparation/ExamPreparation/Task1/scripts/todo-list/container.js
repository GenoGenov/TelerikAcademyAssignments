define(function() {
  'use strict';
  var Container;
  Container = (function() {
      function Container() {
          this._sections = [];
      }

      Container.prototype = {
          add:function(section) {
              this._sections.push(section);
              return this;
          },
          getData:function() {
              var data = [];
              for (var i = 0, len=this._sections.length; i < len; i++) {
                  var section = this._sections[i];
                  data.push(section.getData());
              }
              return data;
          }
  }
   return Container;
  }());
  return Container;
});