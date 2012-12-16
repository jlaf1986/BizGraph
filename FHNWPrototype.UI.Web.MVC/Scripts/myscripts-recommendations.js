function GetWorkFriendshipRecommendation(postUrl, referenceKey) {
    var parameters = {
        "requestorReferenceKey": referenceKey
    };
    
        $.post(postUrl, parameters, function (data) {
            $("section#coworker_recommendation").append(data);
            //alert('a tweet has been sent');
        });
 
}

function GetPartnershipRecommendation(postUrl, referenceKey) {
    var parameters = {
        "requestorReferenceKey": referenceKey
    };

    $.post(postUrl, parameters, function (data) {
        $("section#partner_recommendation").append(data);
        //alert('a tweet has been sent');
    });
}

function GetGroupRecommendation(postUrl, referenceKey) {
    var parameters = {
        "requestorReferenceKey": referenceKey
    };

    $.post(postUrl, parameters, function (data) {
        $("section#group_recommendation").append(data);
        //alert('a tweet has been sent');
    });
}