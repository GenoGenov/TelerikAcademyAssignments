var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var Cat = (function (_super) {
        __extends(Cat, _super);
        function Cat(name, age, phone) {
            _super.call(this, 1 /* Cat */, name, age, phone);
        }
        Cat.prototype.meow = function () {
            console.log('MEOW!');
        };
        return Cat;
    })(Animals.Animal);
    Animals.Cat = Cat;
})(Animals || (Animals = {}));
//# sourceMappingURL=Cat.js.map
