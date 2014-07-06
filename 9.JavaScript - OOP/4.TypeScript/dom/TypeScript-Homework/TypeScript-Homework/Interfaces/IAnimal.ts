interface IAnimal {
    type: AnimalType;
    name: string;
    age: number;
    phone:ICellPhone;
    greet: () => void;
}