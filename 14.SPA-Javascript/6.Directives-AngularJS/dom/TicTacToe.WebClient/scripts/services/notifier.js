ticTacToe.factory('notifier', function (toastr) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "positionClass": "toast-bottom-left"
    }
    return {
        success: function(msg) {
            toastr.success(msg);
        },
        error: function(msg) {
            toastr.error(msg);
        }
    }
})