

$(document).ready(function(){

	$(".peb-owl-project.owl-carousel").owlCarousel({
		autoplay:true,
		items:1,
		loop: true,
		dots: false,
		nav: true,
	});
	$(".peb-owl-slider.owl-carousel").owlCarousel({
		items:1,
		nav: true,
		dots: true,
	});
	$(".peb-owl-clients.owl-carousel").owlCarousel({
		autoplay:true,
		items: 4,
		loop: true,
		margin: 15,
	});

	$(window).on('scroll', function(event) {
	    var scrollValue = $(window).scrollTop();
	    var settings = $('nav.navbar').height();
	    $('nav.navbar').removeClass('affix fixed-top');
	    if (scrollValue == settings.scrollTopPx || scrollValue > 170) {
	    	$('.scroll_to_top').show();
	         $('nav.navbar').addClass('affix fixed-top');
	    }
	    if (scrollValue < 170) {
	    	$('.scroll_to_top').hide();
	    }
	});

	$('.scroll_to_top').click(function(){
		jQuery('html,body').animate({scrollTop:0},800);
	})


	if ($(window).width() >= 992) {
		$('ul.navbar-nav li.nav-item.dropdown').hover(function() {
			$(this).addClass('show');
			$(this).find('.dropdown-menu').addClass('show');
		}, function() {
			$(this).removeClass('show');
			$(this).find('.dropdown-menu').removeClass('show');
		});
	}
	
})
