
$(document).ready(function () {


    var chatInput = $("#txtInput");
    var userName = prompt("İsminizi Girin");

    function isNullOrWhitespace(input) {

        if (typeof input === 'undefined' || input == null) return true;
        return input.replace(/\s/g, '').length < 1;
    }

    if (isNullOrWhitespace(userName)) {
        userName = "Bilinmeyen Kullanıcı"
    }

    var chat = $.connection.chatHub;

    

    chat.connection.qs = { 'username': userName };

    chat.client.messageReceived = function (username, message) {
        $(".messageContainer").append(
            '<div class="row message-bubble form-group">' +
            '<b><span style="color:green">' + username + '</span><br /></b>' +
            '<b><i><span>' + message + '</span></i></b>' +
            '</div>');

        var objDiv = document.getElementById("messageContainer");
        objDiv.scrollTop = objDiv.scrollHeight;

    };

    chat.client.userReceived = function (userList) {

        $(".userContainer").empty();

        $.map(userList, function (item) {

            $(".userContainer").append(
                '<div class="row message-bubble form-group">' +
                '<b><span style="color:blue">' + item.UserName + '</span></b>' +
                '</div>');

        });
    };

 
    $.connection.hub.start().done(function () {
        chatInput.keydown(function (e) {
            if (e.which === 13) {
                var text = chatInput.val();

                function isNullOrWhitespace(input) {

                    if (typeof input === 'undefined' || input == null) return true;
                    return input.replace(/\s/g, '').length < 1;
                }

                if (!isNullOrWhitespace(text)) {
                    chat.server.sendMessage(userName, text);
                    chatInput.val("");

                    self.focus();
                } else {
                    chatInput.val("");
                    self.focus();
                }

            }
        });

        $("body").on('click', "#Send", function () {
            var text = chatInput.val();

            function isNullOrWhitespace(input) {

                if (typeof input === 'undefined' || input == null) return true;
                return input.replace(/\s/g, '').length < 1;
            }

            if (!isNullOrWhitespace(text)) {
                chat.server.sendMessage(userName, text);
                chatInput.val("");
                
                $("#txtInput").focus();

            } else {
                chatInput.val("");
                $("#txtInput").focus();
            }

        });

    });

    chatInput.focus();
});
