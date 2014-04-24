DURATION = 300;

$(document).ready(function () {
    TopGallery();
});

TopGallery = function () {
    //choose all gallery items
    $items = $('.top-gallery-item');
    $switchers = $('.gal-sw');
    counter = 0;  

    $items.hide();
    $items.eq(0).show();

    $switchers.removeClass('gal-sw-current');
    $switchers.eq(0).addClass('gal-sw-current');
    
    MoveLeft();
    MoveRight();
    Switch();
}

MoveLeft = function () {
    $('.gallery-left-arrow').mousedown(function () {
        if (counter < 0) {
            $switchers.eq(counter).removeClass('gal-sw-current');
            $items.eq(counter).hide();
            counter = $items.length - 1;
        }

        if (counter >= 0) {
            $switchers.eq(counter).removeClass('gal-sw-current');
            $items.eq(counter).hide();
            counter--;
        }

        $items.eq(counter).fadeIn(DURATION);
        $switchers.eq(counter).addClass('gal-sw-current');
    });
}

MoveRight = function() {
    $('.gallery-right-arrow').mousedown(function () {
        if (counter < $items.length) {
            $switchers.eq(counter).removeClass('gal-sw-current');
            $items.eq(counter).hide();
            counter++;
        }

        if (counter == $items.length) {
            $switchers.eq(counter).removeClass('gal-sw-current');
            $items.eq(counter).hide();
            counter = 0;
        }

        $items.eq(counter).fadeIn(DURATION);
        $switchers.eq(counter).addClass('gal-sw-current');
    });
}

Switch = function () {
    $switchers.mousedown(function () {
        $switchers.eq(counter).removeClass('gal-sw-current');
        $items.eq(counter).hide();

        counter = $switchers.index($(this));

        $items.eq(counter).fadeIn(DURATION);
        $switchers.eq(counter).addClass('gal-sw-current');
    });
}