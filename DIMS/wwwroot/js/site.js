﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    var placeholder = $('#placeholderHere');
    $('button[data-toggle ="ajax-modal"]').click(function (event)
    {
        var url = $(this).data('url');
        var decodedurl = decodeURIComponent(url);
        $.get(decodedurl).done(function (data) {
            placeholder.html(data);
            placeholder.find('.modal').modal('show');
        })
    })
});

