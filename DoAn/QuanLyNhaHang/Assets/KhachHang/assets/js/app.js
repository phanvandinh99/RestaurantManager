(function($) {
    'use strict';

// FOR NAVBAR FIXED WHEN SCROLL
$(window).on("scroll", function() {
    var scrolling = $(this).scrollTop();
    if (scrolling > 10) {
        $(".header").addClass("navbar-fixed");
    } else {
        $(".header").removeClass("navbar-fixed");
    }
});

// meanmenu
$('#header-menu').meanmenu({
	meanMenuContainer: '.cf-header-menu',
	meanScreenWidth: "991"
});

//mobile side menu
$('.side-toggle').on('click', function () {
	$('.side-info').addClass('info-open');
	$('.offcanvas-overlay').addClass('overlay-open');
})

$('.side-info-close,.offcanvas-overlay').on('click', function () {
	$('.side-info').removeClass('info-open');
	$('.offcanvas-overlay').removeClass('overlay-open');
})

// menu-last class
$('.header-menu nav > ul > li').slice(-4).addClass('menu-lasts');

// Nice Select 
$('.size-qty select, .shop-notice-select select').niceSelect();

// =====search bar toggle======

var search = document.getElementById('search');
search.addEventListener('click', searchFunction);

function searchFunction() {
    var element = document.getElementById("searchForm");
    element.classList.toggle("active");
}
// ========search end =======
// =======video popup=========
$('.play-video').on('click', function(e) {
    e.preventDefault();
    $('#video-overlay').addClass('open');
    $('#video-overlay').append('<iframe width="996" height="560" src="https://www.youtube.com/embed/yeREIXAKXRQ" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>');
});
$('video-overlay, .video-overlay-close').on('click', function(e) {
    e.preventDefault();
    close_video();
});
$(document).keyup(function(e) {
    if (e.kayCode === 27) {
        close_video();
    }
});

function close_video() {
    $('.video-overlay.open').removeClass('open').find('iframe').remove();
};

// data background
$("[data-background]").each(function(){
	$(this).css("background-image","url("+$(this).attr("data-background") + ") ")
})
// data width
$("[data-width]").each(function(){
	$(this).css("width",$(this).attr("data-width"))
})
// data background color
$("[data-bg-color]").each(function(){
	$(this).css("background-color",$(this).attr("data-bg-color"))
})

// =========banner slider ==
var bannerSlider = new Swiper(".bannerSlider", {
    pagination: {
        el: ".banner-pagination",
        clickable: true,
    },
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    autoplay: false,
    speed: 1000,
});

// =========Review slider ==
var swiper = new Swiper(".customer-review", {
    pagination: {
        el: ".review-pagination",
        clickable: true,
    },
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    autoplay: false,
    speed: 1000,
});

// =======================customer review home 2 ============
var swiper = new Swiper(".customer-review-second", {
    pagination: {
        el: ".review-pagination",
        dynamicBullets: true,
        clickable: true,
    },
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    autoplay: false,
    speed: 1000,
});

// =======================customer review home 2 ============
var swiper = new Swiper(".productSlider", {
    pagination: {
        el: ".review-pagination",
        dynamicBullets: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    autoplay: false,
    speed: 1000,
});

// =======================Partner Slider ============

var partnerActive = new Swiper(".partner-active", {
    slidesPerView: 4,
    spaceBetween: 0,
    loop: true,
    autoplay: true,
    speed: 1000,
    breakpoints: {
        "320": {
          slidesPerView: 1,
        },
        "480": {
          slidesPerView: 2,
        },
        "767": {
          slidesPerView: 3,
        },
        "991": {
          slidesPerView: 4,
        },
        "1199": {
          slidesPerView: 4,
        },
    },
});

// Blog slider 
var blogSliderActive = new Swiper(".blog-slider-active", {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    autoplay: true,
    speed: 1000,
    navigation: {
        nextEl: ".blog-slider-next",
        prevEl: ".blog-slider-prev",
      },
});


// Category Slider Active
var blogSliderActive = new Swiper(".cb-category-active", {
    slidesPerView: 5,
    spaceBetween: 35,
    loop: true,
    autoplay: true,
    speed: 1000,
    breakpoints: {
        "320": {
          slidesPerView: 1,
        },
        "500": {
          slidesPerView: 2,
        },
        "767": {
          slidesPerView: 2,
        },
        "991": {
          slidesPerView: 2,
        },
        "1199": {
          slidesPerView: 3,
        },
        "1399": {
            slidesPerView: 4,
        },
        "1599": {
            slidesPerView: 5,
        },
    },
});

// ===============================faq============
// FOR FAQ SECTION ACCORDION
$(function($) {
    var panels = $(".faq__ans").hide();
    panels.first().show();

    $(".faq__que").click(function() {
        var $this = $(this);
        panels.slideUp();
        $this.next().slideDown();
    });
});

$(".faq__que").click(function() {
    $(".faq__que i").addClass("icofont-plus");
    $(this.children[1]).removeClass("icofont-plus");
    $(this.children[1]).addClass("icofont-minus");
});


// ======================some animation add this page==========
AOS.init({
        once: true
    })
    // =======================quantity input ================
    // quantity=========input=============
$(function($) {
    $('.quantity').on('click', '.plus', function(e) {
        let $input = $(this).prev('input.qty');
        let val = parseInt($input.val());
        $input.val(val + 1).change();
    });

    $('.quantity').on('click', '.minus',
        function(e) {
            let $input = $(this).next('input.qty');
            var val = parseInt($input.val());
            if (val > 0) {
                $input.val(val - 1).change();
            }
        });
});
// =============subscription model =======
// ======preloader=======
setTimeout(function() {
        document.getElementById("preloader").style.opacity = "0";
        document.getElementById("preloader").style.visibility = "hidden";
    }, 2000)
    // ============product mixitup init===

// ========pricing section hover effect =============
$(document).ready(function() {
    $(".pricing-row div .pricing-card").mouseover(function() {
        $(".pricing-row div .pricing-card").removeClass('active');
        $(this).addClass('active');
    });
    $(".pricing-row div .pricing-card").mouseout(function() {
        $(".pricing-row div .pricing-card").removeClass('active');
        $(".pricing-row div:nth-child(2) .pricing-card").addClass('active');
    });
});

// =====
$(document).ready(function() {
    $(".pricing-row div").mouseover(function() {
        $(".pricing-row div").removeClass('z-1');
        $(this).addClass('z-1');
    });
    $(".pricing-row div").mouseout(function() {
        $(".pricing-row div").removeClass('z-1');
        $(".pricing-row div:nth-child(2)").addClass('z-1');
    });
});

/*---------------------------
Price Range Slider
---------------------------*/
if (jQuery("#priceFilter").length > 0) {
var html5Slider = document.getElementById('priceFilter');
noUiSlider.create(html5Slider, {
    start: [100, 600],
    connect: true,
    step: 1,
    range: {
        'min': 20,
        'max': 1000
    }
});
var inputNumber = document.getElementById('minNumber');
var inputNumber2 = document.getElementById('maxNumber');
html5Slider.noUiSlider.on('update', function (values, handle) {

    var value = values[handle];

    if (handle) {
        inputNumber.value = Math.round(value);
    } else {
        inputNumber2.value = Math.round(value);
    }
});
inputNumber2.addEventListener('change', function () {
    html5Slider.noUiSlider.set([this.value, null]);
});
inputNumber.addEventListener('change', function () {
    html5Slider.noUiSlider.set([null, this.value]);
});
$("#filterPrice").on('click', function(){
    console.log('Between $' + inputNumber2.value + ' - ' + '$' + inputNumber.value + ' Products Are Showing');
});
}

//  MenuBook Tabs
$('.tabs .tab-links').on('click', '.item-link', function () {
    var tab_id = $(this).attr('data-tab');
    $('.tabs .tab-links .item-link').removeClass('current');
    $(this).addClass('current');
    $('.tab-content').slideUp();
    $("#" + tab_id).slideDown();
});
$('.tabs-fade .tab-links').on('click', '.item-link', function () {
    var tab2_id = $(this).attr('data-tab');
    $('.tabs-fade .tab-links .item-link').removeClass('current');
    $(this).addClass('current');
    $('.tab-content').fadeOut();
    $("#" + tab2_id).fadeIn();
});
//  MenuBook Accordion
$(".accordion").on("click", ".title", function () {
    $(this).next().slideDown();
    $(".accordion-info").not($(this).next()).slideUp();
});
$(".accordion").on("click", ".item", function () {
    $(this).addClass("active").siblings().removeClass("active");
});

// ==========message sent ========
$("#alert").click(function() {
    alert("Your Message Has Been Sent!");
});

})(jQuery);