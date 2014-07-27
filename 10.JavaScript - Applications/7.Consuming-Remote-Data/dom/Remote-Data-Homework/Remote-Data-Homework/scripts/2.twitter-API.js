OAuth.initialize('your-key-here');

var promise = OAuth.popup('twitter');

promise.done(function (result) {
    result.get('https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=DirtyDances')
        .done(function(data) {
            var $tweets = $('#tweets');
        var $tweetsList = $('<ul/>').attr('id', 'tweets-list');
        data.forEach(function(tweet) {
            $tweetsList.append($('<li/>').addClass('tweet').text(tweet.user.screen_name + ': ' + tweet.text));
        });
        $tweets.append($tweetsList);
    });
});

promise.fail(function (error) {
    console.log(error);
});