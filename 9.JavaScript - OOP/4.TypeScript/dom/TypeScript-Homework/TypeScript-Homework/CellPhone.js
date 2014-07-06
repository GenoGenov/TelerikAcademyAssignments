var Phones;
(function (Phones) {
    var Phone = (function () {
        function Phone(battery, model, phoneNumber) {
            this.battery = battery;
            this.model = model;
            this.phoneNumber = phoneNumber;
            Phone._phones.push(this);
            switch (this.model) {
                case 2:
                    this.strType = 'iPhone5S';
                    break;
                case 3:
                    this.strType = 'Galaxy S4';
                    break;
                default:
            }
        }
        Phone.prototype.ring = function (phoneNumber) {
            for (var i = 0; i < Phone._phones.length; i++) {
                if (Phone._phones[i].phoneNumber === phoneNumber) {
                    console.log(this.toString() + ' with number' + this.phoneNumber + ' is calling ' + Phone._phones[i].toString() + ' with number ' + Phone._phones[i].phoneNumber);
                }
            }
        };

        Phone.prototype.toString = function () {
            return this.strType;
        };
        Phone._phones = [];
        return Phone;
    })();
    Phones.Phone = Phone;
})(Phones || (Phones = {}));
//# sourceMappingURL=CellPhone.js.map
