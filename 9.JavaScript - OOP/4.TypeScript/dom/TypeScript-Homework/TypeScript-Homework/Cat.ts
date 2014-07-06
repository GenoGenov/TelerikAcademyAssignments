module Animals {
    export class Cat extends Animal {
        constructor(name: string, age: number, phone: ICellPhone) {
            super(AnimalType.Cat, name, age, phone);
        }

        meow() {
            console.log('MEOW!');
        }
    }
}  