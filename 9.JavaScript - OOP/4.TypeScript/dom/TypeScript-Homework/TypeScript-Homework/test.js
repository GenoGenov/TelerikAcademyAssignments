var badger = new Animals.HoneyBadger('Pencho', 13, new Phones.Phone(new Phones.Battery(4, 6), 3 /* GalaxyS4 */, '0399214993'));

var cat = new Animals.Cat('Puss.y', 9, new Phones.Phone(new Phones.Battery(4, 2), 2 /* iPhone5 */, '+44 9923004'));

badger.makeSound();
badger.greet();
badger.giveGiftObject(6);
badger.printPhoneNumber();

cat.meow();
cat.greet();
cat.giveGiftObject('str');
cat.printPhoneNumber();

badger.phone.ring(cat.phone.phoneNumber);

cat.phone.ring(badger.phone.phoneNumber);
//# sourceMappingURL=test.js.map
