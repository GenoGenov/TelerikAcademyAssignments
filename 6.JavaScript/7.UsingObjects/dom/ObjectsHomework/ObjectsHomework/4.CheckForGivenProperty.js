function hasProperty(obj, prop) {
    return obj.hasOwnProperty(prop);
}

var obj = 'ssss';
console.log(hasProperty(obj, 'length'));
obj = 2;
console.log(hasProperty(obj, 'length'));