// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// When the user scrolls the page, execute myFunction
window.onscroll = function () { myFunction() };

// Get the header
var header = document.getElementById("myHeader");

// Get the offset position of the navbar
var sticky = header.offsetTop;

// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
function myFunction() {
    if (window.pageYOffset > sticky) {
        header.classList.add("sticky");
    } else {
        header.classList.remove("sticky");
        
    }
   
}
/*
* Fix sidebar at some point and remove
* fixed position at content bottom
*/
$(window).scroll(function () {
    var headerHeight = $('.site-header').innerHeight();
    var contentHeight = $('.site-main').innerHeight();
    var sidebarHeight = $('.side-navigation').height();
    var sidebarBottomPos = contentHeight - sidebarHeight;
    var trigger = $(window).scrollTop() - headerHeight;

    if ($(window).scrollTop() >= headerHeight) {
        $('.side-navigation').addClass('fixed');
    } else {
        $('.side-navigation').removeClass('fixed');
    }

    if (trigger >= sidebarBottomPos) {
        $('.side-navigation').addClass('bottom');
    } else {
        $('.side-navigation').removeClass('bottom');
    }
});