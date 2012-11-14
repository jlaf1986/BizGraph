
function RegisterRequestPartnershipTo(url) {
    $(document).on('click', 'a.request_partnership_to', function (e) {
        e.preventDefault();
        var parameters = { "key": e.target.id.substring(22) };
        $.post(url, parameters, function (data) {
            //$(e.target).closest('article.comment').remove();
            alert('you requested a partnership');
            //var json = eval(data);
            $(e.target).enabled = false;
            //$(e.target).val(data);
        });
    });
}

function RegisterCancelRequestTo(url) {
    $(document).on('click', 'a.cancel_request_to', function (e) {
        e.preventDefault();
        var parameters = { "key": e.target.id.substring(18) };
        $.post(url, parameters, function (data) {
            //$(e.target).closest('article.comment').remove();
            alert('you cancelled a request');
            //var json = eval(data);
            $(e.target).enabled = false;
            //$(e.target).val(data);
        });
    });
}

function RegisterAcceptRequestFrom(url) {
    $(document).on('click', 'a.accept_request_from', function (e) {
        e.preventDefault();
        var parameters = { "key": e.target.id.substring(20) };
        $.post(url, parameters, function (data) {
            //$(e.target).closest('article.comment').remove();
            alert('you accepted a request');
            //var json = eval(data);
            $(e.target).enabled = false;
            //$(e.target).val(data);
        });
    });
}

function RegisterRejectRequestFrom(url) {
    $(document).on('click', 'a.reject_request_from', function (e) {
        e.preventDefault();
        var parameters = { "key": e.target.id.substring(20) };
        $.post(url, parameters, function (data) {
            //$(e.target).closest('article.comment').remove();
            alert('you rejected a request');
            //var json = eval(data);
            $(e.target).enabled = false;
            //$(e.target).val(data);
        });
    });
}

function RegisterCancelPartnershipWith(url) {
    $(document).on('click', 'a.cancel_partnership_with', function (e) {
        e.preventDefault();
        var parameters = { "key": e.target.id.substring(23) };
        $.post(url, parameters, function (data) {
            //$(e.target).closest('article.comment').remove();
            alert('you cancelled a friendship');
            //var json = eval(data);
            $(e.target).enabled = false;
            //$(e.target).val(data);
        });
    });
}
