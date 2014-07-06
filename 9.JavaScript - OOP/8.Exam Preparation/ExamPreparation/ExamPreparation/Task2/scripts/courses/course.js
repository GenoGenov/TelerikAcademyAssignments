define(function() {
    var Course;
    Course = (function() {
        function Course(title, formula) {
            this._students = [];
            this._title = title;
            this._formula = formula;
            this._results = [];
        }

        Course.prototype = {
            addStudent: function(student) {
                this._students.push(student);
                return this;
            },
            calculateResults: function() {
                for (var i = 0, len = this._students.length; i < len; i++) {
                    var studentInfo = this._students[i].getData();
                    this._results.push({ name: studentInfo.name, finalScore: this._formula.call(this, studentInfo), exam: studentInfo.exam });
                }
            },
            getTopStudentsByExam: function(count) {
                count = count || this._results.length - 1;
                var data = [];
                var sorted = this._results.sort(function(a, b) {
                    return b.exam - a.exam;
                });
                for (var i = 0; i < count; i++) {
                    data.push({
                        Student: sorted[i].name,
                        Exam:sorted[i].exam
                });
                }
                return data;
            },
            getTopStudentsByTotalScore: function(count) {
                count = count || this._results.length - 1;
                var data = [];
                var sorted = this._results.sort(function(a, b) {
                    return b.finalScore - a.finalScore;
                });
                for (var i = 0; i < count; i++) {
                    data.push({Student:sorted[i].name, "Final Score":sorted[i].finalScore});
                }
                return data;
            }
        };
        return Course;
    }());
    return Course;
})