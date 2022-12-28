/*
Template Name: Bigon;
Description: Ecommerce Bootstrap Template;
Template URI:;
Author Name:Md Bayazid Hasan;
Author URI:;
Version: 1.0;

NOTE: main.js, All custom script and plugin activation script in this file. 
*/

/*================================================
[  Table of contents  ]
==================================================
 1. Newsletter Popup
 2. Mobile Menu Activation
 3. Tooltip Activation
 4. Menu
 4.1 Vertical - Menu Activation
 4.2 Checkout Page Activation
 5. NivoSlider Activation
 6. Best Seller Two & Recent Post Two Activation
 7. New Products Activation
 8. Deal Product Activation
 9. Deal Product Activation
 10. Brand Banner Activation
 11. Brand Banner Activation
 12. Random Product Activation
 13. Countdown Js Activation
 14. WOW Js Activation
 15. ScrollUp Activation
 16. Sticky-Menu Activation
 17. Price Slider Activation
 18. Testimonial Slick Carousel
 19. Testimonial Slick Carousel As Nav
 20. home-2-new-pro-active
 21. Best Seller Activation
 22. Deal Products Three Activation
 23. Deal Product Activation
 24. Thumbnail Product activation
 25. Blog Realted Post activation
 26. Sidebar Best Seller Activation
================================================*/

(function ($) {
    "use Strict";
    /*--------------------------
    1. Newsletter Popup
    ---------------------------*/
    // setTimeout(function () {
    //     $('.popup_wrapper').css({
    //         "opacity": "1",
    //         "visibility": "visible"
    //     });
    //     $('.popup_off').on('click', function () {
    //         $(".popup_wrapper").fadeOut(500);
    //         $('.popup_wrapper').css({
    //             "opacity": "0",
    //             "visibility": "hidden"
    //         });
    //     })
        


    // }, 2500);

    /*----------------------------
    2. Mobile Menu Activation
    -----------------------------*/
    jQuery('.mobile-menu nav').meanmenu({
        meanScreenWidth: "767",
    });

    /*----------------------------
    3. Tooltip Activation
    ------------------------------ */
    // $('[data-bs-toggle="tooltip"]').tooltip({
    //     animated: 'fade',
    //     placement: 'top',
    //     container: 'body'
    // });

    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
      return new bootstrap.Tooltip(tooltipTriggerEl)
    })
    


    /*----------------------------
    4.1 Vertical-Menu Activation
    -----------------------------*/
    $('.categorie-title').on('click', function () {
        $('.vertical-menu-list').slideToggle();
    });

    /*----------------------------
    4.2 Checkout Page Activation
    -----------------------------*/
    $('#showlogin').on('click', function () {
        $('#checkout-login').slideToggle();
    });
    $('#showcoupon').on('click', function () {
        $('#checkout_coupon').slideToggle();
    });
    $('#cbox').on('click', function () {
        $('#cbox_info').slideToggle();
    });
    $('#ship-box').on('click', function () {
        $('#ship-box-info').slideToggle();
    });

    /*----------------------------
    5. NivoSlider Activation
    -----------------------------*/
    $('#slider').nivoSlider({
        effect: 'random',
        animSpeed: 300,
        pauseTime: 5000,
        directionNav: false,
        manualAdvance: false,
        controlNavThumbs: false,
        pauseOnHover: true,
        controlNav: true,
        prevText: "<i class='zmdi zmdi-chevron-left'></i>",
        nextText: "<i class='zmdi zmdi-chevron-right'></i>"
    });

    /*----------------------------------------------------
    6. Best Seller Two & Recent Post Two Activation
    -----------------------------------------------------*/
    $('.main-multi-product')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1000,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 1,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                768: {
                    items: 2
                },
                1000: {
                    items: 1
                },
                1200: {
                    items: 2
                }
            }
        })

    /*----------------------------------------------------
    7. New Products Activation
    -----------------------------------------------------*/
    $('.new-pro-active')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1000,
            addClassActive: true,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 0,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                480: {
                    items: 2
                },
                768: {
                    items: 3
                },
                1000: {
                    items: 4
                },
                1200: {
                    items: 5
                }
            }

        })

    /*----------------------------------------------------
    8. Deal Product Activation
    -----------------------------------------------------*/
    $('.deal-pro-active')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1500,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 1,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                768: {
                    items: 1
                },
                1000: {
                    items: 1
                }
            }
        })

    /*----------------------------------------------------
    9. Deal Product Activation
    -----------------------------------------------------*/
    $('.best-selling-pro')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1200,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 1,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                480: {
                    items: 2
                },
                768: {
                    items: 3
                },
                992: {
                    items: 2
                },
                1200: {
                    items: 3
                }
            }
        })

    /*----------------------------------------------------
    10. Brand Banner Activation
    -----------------------------------------------------*/
    $('.brand-banner').owlCarousel({
        loop: false,
        nav: false,
        dots: false,
        smartSpeed: 1200,
        margin: 1,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            480: {
                items: 2
            },
            768: {
                items: 3
            },
            1000: {
                items: 4
            }
        }
    })

    /*----------------------------------------------------
    11. Brand Banner Activation
    -----------------------------------------------------*/
    $('.popular-cat-active').owlCarousel({
        loop: false,
        nav: true,
        dots: false,
        smartSpeed: 1000,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        margin: 0,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            768: {
                items: 2
            },
            1000: {
                items: 1
            }
        }
    })

    /*----------------------------------------------------
    12. Random Product Activation
    -----------------------------------------------------*/
    $('.random-pro-active').owlCarousel({
        loop: false,
        nav: true,
        dots: false,
        smartSpeed: 1000,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        margin: 0,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            768: {
                items: 2
            },
            992: {
                items: 3
            },
            1200: {
                items: 4
            }
        }
    })

    /*----------------------------
    13. Countdown Js Activation
    -----------------------------*/
    $('[data-countdown]').each(function () {
        var $this = $(this),
            finalDate = $(this).data('countdown');
        $this.countdown(finalDate, function (event) {
            $this.html(event.strftime('<div class="count"><p>%D</p> <span>Days</span></div><div class="count"><p>%H</p> <span>Hrs</span></div><div class="count"><p>%M</p> <span>Min</span></div><div class="count"> <p>%S</p> <span>Secs</span></div>'));
        });
    });

    /*----------------------------
    14. WOW Js Activation
    -----------------------------*/
    new WOW().init();

    /*----------------------------
    15. ScrollUp Activation
    -----------------------------*/
    $.scrollUp({
        scrollName: 'scrollUp', // Element ID
        topDistance: '550', // Distance from top before showing element (px)
        topSpeed: 1000, // Speed back to top (ms)
        animation: 'fade', // Fade, slide, none
        scrollSpeed: 900,
        animationInSpeed: 1000, // Animation in speed (ms)
        animationOutSpeed: 1000, // Animation out speed (ms)
        scrollText: '<i class="fa fa-angle-up"></i>', // Text for element
        activeOverlay: false // Set CSS color to display scrollUp active point, e.g '#00FFFF'
    });

    /*----------------------------
    16. Sticky-Menu Activation
    ------------------------------ */
    $(window).scroll(function () {
        if ($(this).scrollTop() > 150) {
            $('.header-sticky').addClass("sticky");
        } else {
            $('.header-sticky').removeClass("sticky");
        }
    });

    /*----------------------------
    17. Price Slider Activation
    -----------------------------*/
    $("#slider-range").slider({
        range: true,
        min: 0,
        max: 80,
        values: [0, 74],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + "  $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider-range").slider("values", 0) +
        "  $" + $("#slider-range").slider("values", 1));

    /*--------------------------------
    18. Testimonial Slick Carousel
    -----------------------------------*/
    $('.testext_active').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
        draggable: false,
        prevArrow: '<button class="dcare-arrow dacre-prev"><i class="fa fa-angle-left"></i></button>',
        nextArrow: '<button class="dcare-arrow dcare-next"><i class="fa fa-angle-right"></i></button>',
        dots: false,
        asNavFor: '.thumb_active'
    });

    /*---------------------------------------
    19. Testimonial Slick Carousel As Nav
    -----------------------------------------*/
    $('.thumb_active').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.testext_active',
        dots: false,
        arrows: false,
        centerMode: true,
        focusOnSelect: true,
        centerPadding: '0',
        responsive: [
            {
                breakpoint: 479,
                settings: {
                    dots: false,
                    slidesToShow: 3,
                    centerPadding: '0px',
                }
            }
        ]
    });

    /*----------------------------------------------------
    20. home-2-new-pro-active
    -----------------------------------------------------*/
    $('.home-2-new-pro-active')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1000,
            addClassActive: true,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 0,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                480: {
                    items: 2
                },
                768: {
                    items: 3
                },
                992: {
                    items: 3
                },
                1200: {
                    items: 4
                }
            }

        })

    /*----------------------------------------------------
    21. Best Seller Activation
    -----------------------------------------------------*/
    $('.best-seller-pro').on('changed.owl.carousel initialized.owl.carousel', function (event) {
        $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
        loop: false,
        nav: true,
        dots: false,
        smartSpeed: 1000,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        margin: 0,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            480: {
                items: 2
            },
            768: {
                items: 2
            },
            992: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*----------------------------------------------------
    22. Deal Products Three Activation
    -----------------------------------------------------*/
    $('.deal-pro-three-active')
        .on('changed.owl.carousel initialized.owl.carousel', function (event) {
            $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
            loop: false,
            nav: true,
            dots: false,
            smartSpeed: 1500,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            margin: 0,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                768: {
                    items: 1
                },
                992: {
                    items: 2
                },
                1200: {
                    items: 2
                }
            }
        })

    /*----------------------------------------------------
    23. Deal Product Activation
    -----------------------------------------------------*/
    $('.best-seller-pro-two')
        .owlCarousel({
            loop: false,
            nav: false,
            dots: false,
            smartSpeed: 1200,
            margin: 0,
            responsive: {
                0: {
                    items: 1,
                    autoplay:true
                },
                768: {
                    items: 3
                },
                1000: {
                    items: 1
                }
            }
        })
    
    /*-------------------------------------
    24. Thumbnail Product activation
    --------------------------------------*/
    $('.thumb-menu').owlCarousel({
        loop: false,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        margin: 15,
        smartSpeed: 1000,
        nav: true,
        dots: false,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 4
            },
            1000: {
                items: 5
            }
        }
    })
    
    /*-------------------------------------
    25. Blog Realted Post activation
    --------------------------------------*/
    $('.blog-related-post-active').owlCarousel({
        loop: false,
        margin: 30,
        smartSpeed: 1000,
        nav: false,
        dots: false,
        items: 2,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            480: {
                items: 1
            },
            768: {
                items: 2
            },
            992:{
                margin: 29,
                items: 2
            },
            1200: {
                items: 2
            }
        }
    })
    
    /*----------------------------------------------------
    26. Sidebar Best Seller Activation
    -----------------------------------------------------*/
    $('.best-seller-unique').on('changed.owl.carousel initialized.owl.carousel', function (event) {
        $(event.target)
                .find('.owl-item').removeClass('last')
                .eq(event.item.index + event.page.size - 1).addClass('last');
        }).owlCarousel({
        loop: false,
        nav: true,
        dots: false,
        smartSpeed: 1000,
        navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
        margin: 0,
        responsive: {
            0: {
                items: 1,
                autoplay:true
            },
            768: {
                items: 2
            },
            992: {
                items: 1
            },

            1000: {
                items: 1
            }
        }
    })
     
    
})(jQuery);