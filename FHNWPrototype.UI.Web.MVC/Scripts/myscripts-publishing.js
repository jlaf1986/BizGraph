﻿function RegisterAutocomplete() {
    var availableTags = [
                   "@Coworkers",
                   "@UpstreamTier1",
                   "@UpstreamTier2",
                   "@DownstreamTier1",
                   "@DownstreamTier1",
                   "#MaterialFlow",
                   "#Contract2013"

    ];

    $("input#newpost").autocomplete({
        source: availableTags,
        minLength:1
    });

};

function RegisterNewPostOrTweet(postUrl, tweetUrl, referenceKey, notifierProxy) {
    $(document).on('keypress', 'input#newpost', function (e) {
        if (e.keyCode == 13) {
            var textRetrieved =$(this).val();
            var parameters = {
                "wallOwnerUserAccountKey": referenceKey,
                "text": textRetrieved
            };
            if (textRetrieved.substr(0,1) == "#")
            {
                $.post(tweetUrl, parameters, function (data) {
                    $(e.target).val('');
                    //alert('a tweet has been sent');
                });
            }
            else
            {

                $.post(postUrl, parameters, function (data) {
                    $(e.target).val('');
                   // alert('a post has been sent');
                });

            }
        }
    });
};



//function RegisterNewPostEvent(url, referenceKey, notifierProxy){
//    $(document).on('keypress', 'input#newpost', function (e) {
//        if (e.keyCode == 13) {
//            var parameters = {
//                "wallOwnerUserAccountKey": referenceKey,
//                "text": $(this).val()
//            };
//            $.post(url, parameters, function (data) {

                
//                //var parms = {
//                //    "group" : 
//                //};

//                //notifierProxy.invoke('SuscribeMe',

//                //clean the previous textbox
//                //$(this).val("");
//                //alert(data);

//                //var pointOfReference = data.indexOf('section_');
//                //var initialPointOfExtraction = pointOfReference + 8;
//                //var guidExtracted = data.substring(initialPointOfExtraction, initialPointOfExtraction + 36); //initial position (8) + GUID (32) + dashes (4)
//                  // alert('notification will be sent as: POST -> ' + referenceKey + ' GUID -> ' + guidExtracted);

//                //var notification = {
//                //    Group: referenceKey,
//                //    Message: guidExtracted
//                //};
          
//                //notifierProxy.invoke('NotifyMyNewPostToEveryone', notification)
//                //     .done(function () {
//                //       //  alert('notification was succesful');
//                //     })
//                //     .fail(function () {
//                //         alert('notification failed');
//                //     });
                
//                //$(data).insertAfter('section#new_post_section');
//                $(e.target).val('');
           
//               // var eventParameters = {
//               //     "postKey": guidExtracted,
//               //     "group" : referenceKey
//               // }
//               // var newEvent = jQuery.Event("custom", eventParameters);

//               //// $("body").trigger('custom', eventParameters);

//               // $("body").trigger(newEvent);
                
//            });

          

//        }
//    });
//}




function RegisterNewCommentEvent(url, referenceKey,notifierProxy) {
    $(document).on('keypress', 'input.new_comment', function (e) {
        if (e.keyCode == 13) {
         
            var postKey = $(this).closest("section").attr("id").substring(8);
            var textRetrieved = $(e.target).val();
           // alert('a comment will be sent: ' + postId + ' ' + textRetrieved);
            var parameters = {
                "postKey": postKey,
                "wallOwnerAccountKey": referenceKey,
                "text": textRetrieved
            }
            $.post(url, parameters, function (data) {
               
                $(e.target).val('');
 
            });
        }
    });
}

function RegisterNewRetweetEvent(url, referenceKey, notifierProxy) {
    $(document).on('click', 'a.retweet_tweet', function (e) {
       
        e.preventDefault();
        var retrievedTweetKey = e.target.id.substring(14);
       // alert('retweet will  be sent as ' + retrievedTweetKey + " at" + url);
            var parameters = {
                "wallOwnerAccountKey": referenceKey,
                "tweetKey": retrievedTweetKey
            };
            $.post(url, parameters, function (data) {
                //alert('retweet has been sent');
            });
    });
};

function RegisterLikePostEvent(url){
    $(document).on('click', 'a.like_post', function (e) {
        e.preventDefault();
        var thisPostKey= e.target.id.substring(10);
        var parameters = { "postKey": thisPostKey };
        $.post(url,parameters, function (data) {
            $('#like_counter_post_' + thisPostKey).text(data.counter + ' Like this');
            //alert('current counter:' + data.counter);
        });
       
        //e.target.attr('id', 'unlike_post_' + thisPostKey);
        $(e.target).attr('class', 'unlike_post');
        $(e.target).text('Unlike');

    });
}

function RegisterLikeCommentEvent(url){
    $(document).on('click', 'a.like_comment', function (e) {
        e.preventDefault();
        var thisCommentKey = e.target.id.substring(13);
        var parameters = { "commentKey": thisCommentKey };
        $.post(url,parameters, function (data) {
            $('#like_counter_comment_' + thisCommentKey).text(data.counter + ' Like this');
           // alert('current counter:' + data.counter);
        });
       
        //e.target.attr('id', 'unlike_comment_' + thisCommentKey);
        $(e.target).attr('class', 'unlike_comment');
        $(e.target).text('Unlike');

    });
}

function RegisterUnLikePostEvent(url) {
    $(document).on('click', 'a.unlike_post', function (e) {
        e.preventDefault();
        var thisPostKey = e.target.id.substring(10);
        var parameters = { "postKey": thisPostKey };
        $.post(url, parameters, function (data) {
            $('#like_counter_post_' + thisPostKey).text(data.counter + ' Like this');
          //  alert('current counter:' + data.counter);
            
        });
        //e.target.attr('id', 'like_post_' + thisPostKey);
        $(e.target).attr('class', 'like_post');
        $(e.target).text('Like');

    });
}

function RegisterUnLikeCommentEvent(url) {
    $(document).on('click', 'a.unlike_comment', function (e) {
        e.preventDefault();
        var thisCommentKey = e.target.id.substring(13);
        var parameters = { "commentKey": thisCommentKey };
        $.post(url, parameters, function (data) {
            $('#like_counter_comment_' + thisCommentKey).text(data.counter + ' Like this');
           // alert('current counter:' + data.counter);
        });
     
        //e.target.attr('id', 'like_comment_' + thisCommentKey);
        $(e.target).attr('class', 'like_comment');
        $(e.target).text('Like');
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


    function RegisterDeleteTweetEvent(url) {
        $(document).on('click', 'a.delete_tweet', function (e) {
            e.preventDefault();
            var parameters = { "tweetKey": e.target.id.substring(13) };
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

function RegisterDeleteRetweetEvent(url) {
    $(document).on('click', 'a.delete_retweet', function (e) {
        e.preventDefault();
        var parameters = { "retweetKey": e.target.id.substring(15) };
        $.post(url, parameters, function (data) {
            $(e.target).closest('article.retweet').remove();
            //alert('you deleted the comment')
        });
    });
}

