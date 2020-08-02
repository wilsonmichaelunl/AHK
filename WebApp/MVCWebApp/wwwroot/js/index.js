$(document).ready(function () {
    var keys = {};
    var readKeys = false;

    $("#scriptSelectDropdown").change(function () {
        var selectedID = parseInt($(this).val());

        switch (selectedID) {
            case 0:
                $('#partialPlaceHolder').hide();
                break;
            case 1:
                $.get('/Home/HotKeyScript', function (data) {
                    $('#partialPlaceHolder').html(data);
                    $('#partialPlaceHolder').fadeIn('fast');
                });
                break;
            case 2:
                $.get('/Home/Preset', function (data) {
                    $('#partialPlaceHolder').html(data);
                    $('#partialPlaceHolder').fadeIn('fast');
                });
                break;
            case 3:
                $.get('/Home/Favorite', function (data) {
                    $('#partialPlaceHolder').html(data);
                    $('#partialPlaceHolder').fadeIn('fast');
                });
            default:
                //TODO
        }
    })

    $(".key-input").keydown(function (e) {
        readKeys = true;
        keys[e.which] = true;
    });

    $(".key-input").keyup(function (e) {
        if (readKeys = false) {
            console.log(keys);
        }
        readKeys = false;
        delete keys[e.which];
    });
});

