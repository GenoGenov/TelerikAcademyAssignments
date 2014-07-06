var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Animals;
(function (Animals) {
    var HoneyBadger = (function (_super) {
        __extends(HoneyBadger, _super);
        function HoneyBadger(name, age, phone) {
            _super.call(this, 6 /* HoneyBadger */, name, age, phone);
        }
        HoneyBadger.prototype.makeSound = function () {
            console.log('WOF!');
        };
        return HoneyBadger;
    })(Animals.Animal);
    Animals.HoneyBadger = HoneyBadger;
})(Animals || (Animals = {}));
//# sourceMappingURL=HBadger.js.map
