
function AjaxPost(IsAPI = false, Controller = "", data) {
    var res = "";
    var url = '';
    if (data == undefined || data == null)
        data = {};

    url = window.location.protocol + "//" + window.location.host;
    if (IsAPI) {
        url += ("/api/" + Controller);
    } else {
        url += (window.location.pathname + (/[/]$/.test(window.location.pathname)?"":"/") + Controller);
    }

    $.ajax({
        async: false,
        url: url,
        data: data,
        type: 'POST',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + '/' + xhr.responseText);
            res = "ERR";
        },
        success: function (sdata) {
            res = "OK" + sdata;
        }
    });
    return res;
}


function AjaxPostFile(ajaxMethod, data) {
    var res = "";
    var url = '';
    if (data == undefined || data == null)
        data = {};

    url = window.location.protocol + "//" + window.location.host;
    if (IsAPI) {
        url += ("/api/" + Controller);
    } else {
        url += (window.location.pathname + (/[/]$/.test(window.location.pathname) ? "" : "/") + Controller);
    }

    $.ajax({
        async: false,
        url: url,
        data: data,
        type: 'POST',
        processData: false,
        contentType: false,
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + '/' + xhr.responseText);
            res = "ERR";
        },
        success: function (sdata) {
            res = "OK" + sdata;
        }
    });
    return res;
}