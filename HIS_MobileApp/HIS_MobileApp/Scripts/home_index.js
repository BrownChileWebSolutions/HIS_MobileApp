$(document).ready(function () {
    $('#txtUserName').focus();
    $("#btnSave").click(function () {
        var user = new Object();
        user.UserName = $('#txtUserName').val();
        user.Password = $('#txtPassword').val();
        $.ajax({
            url: '/User/IsAuthorized',
            type: 'POST',
            dataType: 'json',
            data: user,
            success: function (data) {
                if (data.result == "Success") {
                    var url = '/Map';
                    window.location.href = url;
                }
                else {
                    $('label[for=Name]').html(data.result);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                //console.log("jqXHR= " + jqXHR.responseText + ", status code= " + jqXHR.statusCode + ", errorThrown= " + errorThrown);                        
                console.log(jqXHR.responseText);
            }
        });
    });
});