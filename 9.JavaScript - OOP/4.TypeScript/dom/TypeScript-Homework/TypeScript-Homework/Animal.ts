module Animals {
    export class Animal implements IAnimal {
        private static _animalsCount: Array<Animal> = [];
        private strType: string;

        constructor(public type: AnimalType, public name: string, public age: number, public phone: ICellPhone) {
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

        greet(): void {
            console.log('Hey, my name is ' + this.name + ' and I am ' + this.strType);
        }

        static getAnimalsCount() {
            return this._animalsCount.length;
        }

        printPhoneNumber() {
            console.log('I am a ' + this.strType + ' and I have the ' + this.phone.toString() + ' how about that! Btw my number is ' + this.phone.phoneNumber);
        }

        giveGiftObject<T>(obj: T): void {
            console.log(this.name + ' of type ' + this.strType + ' received gift of type ' + typeof obj);
        }
    }
}