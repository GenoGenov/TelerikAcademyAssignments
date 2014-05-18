Object.prototype.deepCopy = function (objToCopy) {
    for (var i in objToCopy) {
        if (objToCopy.hasOwnProperty(i) && (this[i] == undefined || this[i] !== objToCopy[i] || objToCopy.propertyIsEnumerable(i))) {
            this[i] = objToCopy[i];
            deepCopy(objToCopy[i], this[i]);
        }
        else {
            return objToCopy;
        }
    }
}

var a = {
    name: "sample",
    arr: [1, 2, 3],
    s: {
        d: 2,
        k: { 'm': 3, 'p': 4 }
    }
};

var obj = {};

obj.deepCopy(a);
a.arr = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
console.log(obj);
console.log(a);
console.log();

a = 3;
obj = 5;
obj = Object.deepCopy(a);
console.log('a: ' + a + ' obj: ' + obj);