// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    $("#IzqSidebar").mCustomScrollbar({
         theme: "minimal"
    });
    $('#IzqSidebarCollapse').on('click', function () {
        // open or close navbar
        $('#IzqSidebar').toggleClass('active');
        // close dropdowns
        $('.collapse.in').toggleClass('in');
        // and also adjust aria-expanded attributes we use for the open/closed arrows
        // in our CSS
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
    $("#DerSidebar").mCustomScrollbar({
        theme: "minimal"
   });
   $('#DerSidebarCollapse').on('click', function () {
       // open or close navbar
       $('#DerSidebar').toggleClass('active');
       // close dropdowns
       $('.collapse.in').toggleClass('in');
       // and also adjust aria-expanded attributes we use for the open/closed arrows
       // in our CSS
       $('a[aria-expanded=true]').attr('aria-expanded', 'false');
   });

   
   



});