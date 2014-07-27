define(function() {
    var Student = (function() {

        function validateName(name) {
            if ((typeof name !== 'string') || name.length < 3) {
                throw new Error('Student first/last name cannot be less than 3 symbols long or different from String');
            }
        }


        function validateYears(years) {
            if ((typeof years !== 'number') || years < 1) {
                throw new Error('Person years cannot be less than 1');
            }
        }

        function validateGrades(grades) {
            if (!(grades instanceof Array) ||
                !grades.every(function(grade) { return typeof grade === 'number'; })) {
                throw new Error('Grades must be an array which contains only numbers !');
            }
        }

        function fName(name) {
            if (name) {
                validateName(name);
                this._fname = name;
            } else {
                return this._fname;
            }
        }

        function lName(name) {
            if (name) {
                validateName(name);
                this._lname = name;
            } else {
                return this._lname;
            }
        }


        function age(years) {
            if (years) {
                validateYears(years);
                this._years = years;
            } else {
                return this._years;
            }
        }

        function marks(grades) {
            if (grades) {
                validateGrades(grades);
                this._marks = grades;
            } else {
                return this._marks;
            }
        }

        function Student(firstName, secondName, years, grades) {
            fName.call(this, firstName);
            lName.call(this, secondName);
            age.call(this, years);
            marks.call(this, grades);
        }

        Student.prototype = {
            fName: fName,
            lName: lName,
            age: age,
            marks:marks,
            fullName: function() {
                return this.fName() + ' ' + this.lName();
            },
            toSimple:function() {
                return {
                    name: this.fullName(),
                    age: this.age(),
                    marks: this.marks(),
                }
            }
        };
        return Student;
    }());
    return Student;
});