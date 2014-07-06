module Phones {
    export class Phone implements ICellPhone {
        private static _phones: Array<Phone> = [];
        private strType: string;

        constructor(public battery: IBattery, public model: PhoneModel, public phoneNumber: string) {
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

        ring(phoneNumber) {
            for (var i = 0; i < Phone._phones.length; i++) {
                if (Phone._phones[i].phoneNumber === phoneNumber) {
                    console.log(this.toString() + ' with number' + this.phoneNumber + ' is calling ' + Phone._phones[i].toString() + ' with number ' + Phone._phones[i].phoneNumber);
                }
            }
        }

        toString() {
            return this.strType;
        }
    }
}