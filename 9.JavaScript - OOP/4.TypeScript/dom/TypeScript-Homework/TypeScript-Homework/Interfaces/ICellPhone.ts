interface ICellPhone {
    battery: IBattery;
    model: PhoneModel;
    phoneNumber: string;
    ring:(num:string)=>void;
}