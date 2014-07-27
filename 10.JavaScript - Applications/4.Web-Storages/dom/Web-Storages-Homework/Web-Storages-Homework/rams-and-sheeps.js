(function($) {

    $.fn.ramsAndSheeps = function() {

        var digitsToGuess = [
            Math.floor(Math.random() * (9 - 1 + 1)) + 1,
            Math.floor(Math.random() * (9 - 0 + 1)) + 0,
            Math.floor(Math.random() * (9 - 0 + 1)) + 0,
            Math.floor(Math.random() * (9 - 0 + 1)) + 0
        ];

        var guessesCount = 0;

        function showScoreBoard(scores) {
            var $scoreBoard = $('<ul/>');
            scores.forEach(function(score) {
                $scoreBoard.append($('<li/>').text(score.name + ': ' + score.score + ' mistakes'));
            });

            $scoreBoard.css({
                'font-size': '28px',
                'font-weight': 'bold',
                'z-index': 999999,
                'background-color': '#9AC6C9',
                position: 'absolute',
                top: '20%',
                left: '5%'
            }).appendTo('body');
        }

        if (localStorage.getItem('SAR-game')) {
            var stored = JSON.parse(localStorage.getItem('SAR-game'));
            showScoreBoard(stored);
        }

        console.log(digitsToGuess);
        var $this = $(this);
        var $game = $this.find('#game');

        var $input = $game.find('#user-input');
        var $log = $game.find('#turns-log');
        var $submit = $game.find('#submit-btn');

        var scoreForm = $this.find('#score-form').hide();

        scoreForm.find('#get-name').on('click', function (ev) {
                var value = scoreForm.find('#name-input').val();
                var engLettersTest = /^[a-zA-Z]*$/;
                var stored;
                if (engLettersTest.test(value)) {
                    if (localStorage.getItem('SAR-game')) {
                        stored = JSON.parse(localStorage.getItem('SAR-game'));
                        stored.push({ name: value, score: guessesCount });
                        stored.sort(function (a, b) { return a['score'] - b['score']; });
                        localStorage.setItem('SAR-game', JSON.stringify(stored));
                    } else {
                        stored = [{ name: value, score: guessesCount }];
                        localStorage.setItem('SAR-game', JSON.stringify(stored));
                    }
                    showScoreBoard(stored);
                } else {
                    alert('Your input must be only english letters (a-z, A-Z)');
                }

            });

        scoreForm.find('#start-new').on('click', function (ev) {
            location.reload();
        });

        $input.find('.input-field')
            .attr({
                maxLength: '1',
            })
            .keydown(function(e) {
                if ((e.keyCode !== 8 && e.keyCode !== 0) && (e.keyCode < 48 || e.keyCode > 57)) {
                    return false;
                }
            })
            .keyup(function(e) {
                if ($(this).val().length == $(this).attr('maxlength')
                    && $(this).next('.input-field').length) {
                    $(this).next('.input-field').focus().select();

                } else if ($(this).val().length == $(this).attr('maxlength')
                    && !$(this).next('.input-field').length) {
                    $(this).parent().find('.input-field:first-of-type').focus().select();
                }

            });

        $submit.on('click', function(e) {

            var guessedNums = [];
            var invalidInput = false;
            $input.find('.input-field').each(function(index) {
                if ($(this).val() == '') {
                    invalidInput = true;
                }
                guessedNums.push(parseInt($(this).val()));
            });
            if (guessedNums.some(function(el) { return (typeof el) !== 'number'; })) {
                invalidInput = true;
            }
            if (invalidInput) {
                $input.find('.input-field').each(function(index) { $(this).val(''); });
                return;
            }

            guessesCount++;

            var digits = guessedNums.map(function(digit) {
                return {
                    digit: digit,
                    checked: false
                };
            });

            var rams = 0;
            var sheeps = 0;

            for (var i = 0; i < guessedNums.length; i++) {
                var digit = digits[i];

                for (var j = 0; j < digitsToGuess.length; j++) {
                    if (digit.checked) {
                        break;
                    }
                    if (digit.digit === digitsToGuess[i]) {
                        digit.checked = true;
                        rams++;
                        break;
                    }
                    if (digits[j].digit === digitsToGuess[j] && digit.digit === digitsToGuess[j]) {
                        break;
                    }
                    if (digit.digit === digitsToGuess[j]) {
                        sheeps++;
                        digit.checked = true;
                        break;
                    }
                }
            }

            $input.find('.input-field').val('').first().focus();

            $log.find('#log-list')
                .append($('<li/>')
                    .addClass('log-item')
                    .append($('<span/>')
                        .addClass('info')
                        .text('You got ' + rams + ' rams and ' + sheeps + ' sheep !'))
                    .append($('<span/>')
                        .addClass('numbers')
                        .text('Your guess was ' + guessedNums.join(', ').trim()))
                );

            if (rams === 4) {
                $input.find('.input-field:focus').blur();
                $game.addClass('disabled');
                scoreForm.find('#score').text(guessesCount);
                scoreForm.show();
                return;
            }
        });


    };

}(jQuery));