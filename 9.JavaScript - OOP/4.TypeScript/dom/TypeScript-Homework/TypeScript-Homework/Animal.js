var Animals;
(function (Animals) {
    var Animal = (function () {
        function Animal(type, name, age, phone) {
            this.type = type;
            this.name = name;
            this.age = age;
            this.phone = phone;
            Animal._animalsCount.push(this);
            switch (this.type) {
                case 1:
                    this.strType = 'Cat';
                    break;
                case 6:
                    this.strType = 'Honey Badger';
                    break;
            }
        }
        Animal.prototype.greet = function () {
            console.log('Hey, my name is ' + this.name + ' and I am ' + this.strType);
        };

        Animal.getAnimalsCount = function () {
            return this._animalsCount.length;
        };

        Animal.prototype.printPhoneNumber = function () {
            console.log('I am a ' + this.strType + ' and I have the ' + this.phone.toString() + ' how about that! Btw my number is ' + this.phone.phoneNumber);
        };

        Animal.prototype.giveGiftObject = function (obj) {
            console.log(this.name + ' of type ' + this.strType + ' received gift of type ' + typeof obj);
        };
        Animal._animalsCount = [];
        return Animal;
    })();
    Animals.Animal = Animal;
})(Animals || (Animals = {}));
//# sourceMappingURL=Animal.js.map
