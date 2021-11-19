"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/duongHub").build();

connection.on("ReceiveMessage", function (message) {
    var template = $('#announcement-template').html();
    var html = Mustache.render(template, {
        Content: message.content,
        Id: message.id,
        Title: message.title,
        FullName: message.fullName,
        Avatar: message.avatar
    });
    $('#annoncementList').prepend(html);

    var totalAnnounce = parseInt($('#totalAnnouncement').text()) + 1;

    $('#totalAnnouncement').text(totalAnnounce);
});

connection.start().catch (err => console.error(err.toString()));