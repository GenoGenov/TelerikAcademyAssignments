window.onload = function () {

    Array.prototype.contains = function (element) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] === element) {
                return true;
            }
        }
        return false;
    }

    //var familyMembers = [{
    //    mother: 'Maria Petrova',
    //    father: 'Georgi Petrov',
    //    children: ['Teodora Petrova', 'Peter Petrov']
    //}, {
    //    mother: 'Petra Stamatova',
    //    father: 'Todor Stamatov',
    //    children: ['Maria Petrova']
    //}
    //];


    var familyMembers = [
    {
        mother: 'Maria Petrova',
        father: 'Georgi Petrov',
        children: ['Teodora Petrova', 'Peter Petrov']
    },
    {
        mother: 'Boriana Stamatova',
        father: 'Teodor Stamatov',
        children: ['Martin Stamatov', 'Albena Dimitrova']
    },
    {
        mother: 'Albena Dimitrova',
        father: 'Ivan Dimitrov',
        children: ['Doncho Dimitrov', 'Ivaylo Dimitrov']
    },
    {
        mother: 'Donika Dimitrova',
        father: 'Doncho Dimitrov',
        children: ['Vladimir Dimitrov', 'Iliana Dobreva']
    },
    {
        mother: 'Juliana Petrova',
        father: 'Peter Petrov',
        children: ['Dimitar Petrov', 'Galina Opanova']
    },
    {
        mother: 'Iliana Dobreva',
        father: 'Delian Dobrev',
        children: ['Dimitar Dobrev', 'Galina Pundiova']
    },
    {
        mother: 'Galina Pundiova',
        father: 'Martin Pundiov',
        children: ['Dimitar Pundiov', 'Todor Pundiov']
    },
    {
        mother: 'Maria Pundiova',
        father: 'Dimitar Pundiov',
        children: ['Georgi Pundiov', 'Stoian Pundiov']
    },
    {
        mother: 'Dobrinka Pundiova',
        father: 'Georgi Pundiov',
        children: ['Pavel Pundiov', 'Marian Pundiov']
    },
    {
        mother: 'Elena Pundiova',
        father: 'Marian Pundiov',
        children: ['Kamen Pundiov', 'Hristina Ivancheva']
    },
    {
        mother: 'Petra Stamatova',
        father: 'Todor Stamatov',
        children: ['Teodor Stamatov', 'Boris Opanov', 'Maria Petrova']
    },
    {
        mother: 'Hristina Ivancheva',
        father: 'Martin Ivanchev',
        children: ['Kamen Ivanchev', 'Evgeny Ivanchev']
    },
    {
        mother: 'Maria Ivancheva',
        father: 'Kamen Ivanchev',
        children: ['Ivo Ivanchev', 'Delian Ivanchev']
    },
    {
        mother: 'Nadejda Ivancheva',
        father: 'Ivo Ivanchev',
        children: ['Petio Ivanchev', 'Marin Ivanchev']
    },
    {
        mother: 'Natalia Ivancheva',
        father: 'Delian Ivanchev',
        children: ['Galina Hristova']
    },
    {
        mother: 'Galina Opanova',
        father: 'Boian Opanov',
        children: ['Maria Opanova', 'Patar Opanov']
    },
    {
        mother: 'Galina Hristova',
        father: 'Marin Hristov',
        children: ['Petar Hristov', 'Kamen Hristov', 'Ivan Hristov']
    },
    {
        mother: 'Simona Hristova',
        father: 'Kamen Hristov',
        children: ['Elena Hristova', 'Valeria Hristova']
    }
    ];


    var mothers = [];
    var fathers = [];
    var children = [];
    var root = {
        mother: undefined,
        father: undefined
    };

    function divideFamilyMembers() {
        for (var i = 0; i < familyMembers.length; i++) {
            if (!mothers.contains(familyMembers[i].mother)) {
                var mother = {
                    name: familyMembers[i].mother,
                    partner: familyMembers[i].father,
                };
                mothers.push(mother);
            }
            if (!fathers.contains(familyMembers[i].father)) {
                var father = {
                    name: familyMembers[i].father,
                    partner: familyMembers[i].mother,
                };
                fathers.push(father);
            }
            for (var j = 0; j < familyMembers[i].children.length; j++) {
                if (!children.contains(familyMembers[i].children[j])) {
                    children.push(familyMembers[i].children[j]);
                }
            }
        }
    }

    function findRoot() {
        for (var i = 0; i < mothers.length; i++) {
            if (!children.contains(mothers[i].name)) {
                if (!children.contains(mothers[i].partner)) {
                    root.mother = mothers[i].name;
                    root.father = mothers[i].partner;
                    break;
                }
            }
        }
    }
    var personsLayered = [];
    function assignLayersRecursive(rootMember, layerStart) {
        personsLayered[layerStart] = personsLayered[layerStart] || [];
        var match = false;
        for (var i = 0; i < familyMembers.length; i++) {
            var family = familyMembers[i];
            if (family.mother === rootMember || family.father === rootMember) {
                match = true;
                personsLayered[layerStart].push(familyMembers[i].mother);
                personsLayered[layerStart].push(familyMembers[i].father);
                for (var j = 0; j < family.children.length; j++) {
                    assignLayersRecursive(family.children[j], layerStart + 1);
                }
            }

        }
        if (!match) {
            personsLayered[layerStart].push(rootMember);
        }
        return;
    }

    function printPersons(array) {
        var stage = new Kinetic.Stage({
            container: 'container',
            width: 2000,
            height: 2000
        });

        var layer = new Kinetic.Layer();

        layer.add(new Kinetic.Rect({
            x: 50,
            y: 50,
            width: 160,
            height: 50,
            stroke: 'yellowgreen',
            cornerRadius: 20
        }));
        layer.add(new Kinetic.Text({
                                       x: 50 + 20,
                                       y: 50 + 16,
                                       text: array[0][0],
                                       fontFamily: 'Calibri',
                                       fontSize:17,
                                       fill: 'black',
                                       tension:1
        }));
        layer.add(new Kinetic.Rect({
            x: 50 + 220,
            y: 50,
            width: 160,
            height: 50,
            stroke: 'yellowgreen',
            cornerRadius:20
        }));
        layer.add(new Kinetic.Text({
            x: 50 + 220 + 20,
            y: 50 + 16,
            text: array[0][1],
            fontFamily: 'Calibri',
            fontSize: 17,
            fill: 'black',
            tension:1
        }));

        for (var i = 1; i < array.length; i++) {
            for (var j = 0; j < array[i].length; j++) {
                layer.add(new Kinetic.Rect({
                    x: 50 + 220 * j,
                    y: 50 + 130 * i,
                    width: 160,
                    height: 50,
                    stroke: 'yellowgreen',
                    cornerRadius:20
                }));
                layer.add(new Kinetic.Text({
                    x: 50 + 220 * j + 20,
                    y: 50 + 130 * i +16,
                    text: array[i][j],
                    fontFamily: 'Calibri',
                    fontSize: 17,
                    fill: 'black'
                }));
                for (var k = 0; k < familyMembers.length; k++) {
                    for (var l = 0; l < array[i - 1].length; l++) {
                        if (familyMembers[k].mother === array[i - 1][l] || familyMembers[k].father === array[i - 1][l]) {
                            if (familyMembers[k].children.contains(array[i][j])) {
                                var startX = 50 + 220 * l + 80,
                                    startY = 50 + 130 * (i - 1) + 50,
                                    endX = 50 + 220 * j + 80,
                                    endY = 50 + 130 * i;
                                layer.add(new Kinetic.Line({
                                    points: [startX, startY, endX , endY],
                                    stroke: 'yellowgreen',
                                    lineCap:'round',
                                    tension: 0.2,
                                }));
                            }
                        }
                    }

                }

            }
        }
        stage.add(layer);
    }


    console.log(personsLayered);

    divideFamilyMembers();
    findRoot();
    assignLayersRecursive(root.mother, 0);
    printPersons(personsLayered);
}