define(function () {
    var Animal = (function () {

        Animal.SPECIES_TYPES = ['mammal', 'insect', 'reptile', 'fish'];

        function validateLegs(number) {
            if ((typeof number !== 'number') || number < 0) {
                throw new Error('Animal legs count cannot be less than 0');
            }
        }

        function validateSpecies(name) {
            if ((typeof name !== 'string') || Animal.SPECIES_TYPES.indexOf(name)<0) {
                throw new Error('The animal species type is invalid !');
            }
        }

        function species(name) {
            if (name) {
                validateSpecies(name);
                this._species = name;
            } else {
                return this._species;
            }
        }


        function numberOfLegs(number) {
            if (number) {
                validateLegs(number);
                this._numberOfLegs = number;
            } else {
                return this._numberOfLegs;
            }
        }

        function Animal(type, legs) {
            species.call(this, type);
            numberOfLegs.call(this, legs);
        }

        Animal.prototype = {
            species: species,
            legs: numberOfLegs,
            toSimple:function() {
                return {
                    species: this.species(),
                    legs:this.legs()
                }
            }
        };
        return Animal;
    }());
    return Animal;
});