var Phones;
(function (Phones) {
    var Battery = (function () {
        function Battery(size, power) {
            this.size = size;
            this.power = power;
        }
        return Battery;
    })();
    Phones.Battery = Battery;
})(Phones || (Phones = {}));
//# sourceMappingURL=Battery.js.map
