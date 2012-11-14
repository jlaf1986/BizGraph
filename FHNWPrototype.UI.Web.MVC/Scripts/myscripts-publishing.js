
function RegisterNewPostEvent(url, referenceKey){
    $(document).on('keypress', 'input#newpost', function (e) {
        if (e.keyCode == 13) {
            var parameters = {
                "wallOwnerUserAccountKey" : referenceKey,
                "text" : $(this).val()
            }
            $.post(url, parameters, function (data){
                //clean the previous textbox
                //$(this).val("");
                //alert(data);
                $(data).insertAfter('section#new_post_section');
                $(e.target).val('');
                //  Html.RenderPartial("_partial_post",
                //  var newElement = "<article id='post_" + data + "' class='post'" 
                // $('').insertBefore(this);

            });
        }
    });
}

function RegisterNewCommentEvent(url){
    $(document).on('keypress', 'input.new_comment', function (e) {
        if (e.keyCode == 13) {
            var postId = $(this).closest("section").attr("id");
            var parameters = {
                "postKey": postId.substring(8),
                "text": $(e.target).val()
            }
            $.post(url, parameters, function (data) {
                var closestArticle = $(e.target).closest("article");
                $(data).insertBefore(closestArticle);
                $(e.target).val('');
                //alert(data);
                //alert(closestArticle.toString());
            });
        }
    });
}

function RegisterLikePostEvent(url){
    $(document).on('click', 'a.like_post', function (e) {
        e.preventDefault();
        var parameters = { "postKey": e.target.id.substring(10) };
        $.post(url,parameters, function (data) {
            alert('you liked the post')
        });
    });
}

function RegisterLikeCommentEvent(url){
    $(document).on('click', 'a.like_comment', function (e) {
        e.preventDefault();
        var parameters = { "commentKey": e.target.id.substring(13) };
        $.post(url,parameters, function (data) {
            alert('you liked the comment')
        });
    });
}
    function RegisterDeletePostEvent(url){
        $(document).on('click', 'a.delete_post', function (e) {
            e.preventDefault();
            var parameters = { "postKey": e.target.id.substring(12) };
            $.post(url, parameters, function (data) {
                $(e.target).closest('section').remove();
                //alert('you deleted the post')
            });
        });
    }

function RegisterDeleteCommentEvent(url) {
    $(document).on('click', 'a.delete_comment', function (e) {
        e.preventDefault();
        var parameters = { "commentKey": e.target.id.substring(15) };
        $.post(url, parameters, function (data) {
            $(e.target).closest('article.comment').remove();
            //alert('you deleted the comment')
        });
    });    
}

