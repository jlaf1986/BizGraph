function CheckRecentNotifications(countingUrl, retrieverUrl) {
    //var parameters = {
    //    "requestorReferenceKey": referenceKey
    //};
  
    var counter = 0;

    $.post(countingUrl, null, function (data) {
        counter = parseInt(data);
        $("#counter_notifications_newsfeed").text(counter);
    
    });

   // alert('notifications: ' + counter);

    if (counter > 0) {
        
        $.post(retrieverUrl, null, function (data) {
           // alert('results' + data);
            $("#counter_notifications_newsfeed").removeAttr('class');
            
            $("#notification_details").html(data);
            //
        });
    }
    else
    {
        $("#counter_notifications_newsfeed").attr('class', 'hide');
        
    }
}


function CheckCounterRecentNotifications(url) {
    var counter = 0;

    $.post(url, null, function (data) {

        counter = parseInt(data);
        $("#counter_notifications_newsfeed").text(counter);
        //  alert('notifications: ' + counter);
        if (counter > 0) {
            $("#counter_notifications_newsfeed").removeAttr('class');
        }
    });


    return counter;
}