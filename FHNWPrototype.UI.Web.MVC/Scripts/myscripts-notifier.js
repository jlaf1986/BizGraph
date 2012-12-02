
function RegisterNewMessengerPostEvent(url, chatRoom, notifierProxy) {
    $(document).on('keypress', 'input#new_messenger_post', function (e) {
        if (e.keyCode == 13) {
            var text =  $(this).val();
            var parameters = {
                "chatRoom": chatRoom,
                "text": text
            };
          //  alert('attempting to post: ' + chatRoom + ' '  + text );
            $.post(url, parameters, function (data) {
              //  alert('success posting the message');
                $(e.target).val('');

            });



        }
    });
}