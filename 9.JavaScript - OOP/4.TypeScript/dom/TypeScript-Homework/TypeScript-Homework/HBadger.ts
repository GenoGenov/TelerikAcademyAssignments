module Animals {
    export class HoneyBadger extends Animal {
        constructor(name: string, age: number, phone:ICellPhone) {
            super(AnimalType.HoneyBadger, name, age, phone);
        }

        makeSound() {
            console.log('WOF!');
        }
    }
} 