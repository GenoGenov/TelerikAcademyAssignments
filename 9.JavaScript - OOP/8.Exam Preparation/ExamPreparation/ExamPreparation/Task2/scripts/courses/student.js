define(function() {
    var Student;
    Student = (function() {
        function Student(params) {
            this._name = params.name;
            this._exam = params.exam;
            this._homework = params.homework;
            this._attendance = params.attendance;
            this._teamwork = params.teamwork;
            this._bonus = params.bonus;
        }

        Student.prototype = {
            getData: function() {
                return {
                    name: this._name,
                    exam: this._exam,
                    homework: this._homework,
                    attendance: this._attendance,
                    teamwork: this._teamwork,
                    bonus: this._bonus
                };
            }
        };
        return Student;
    }());
    return Student;
})