$(document).ready(function () {
    $('#txtUserName').focus();
    $("#btnSave").click(function () {
        $.ajax({
            url: '/User/IsAuthorized',
            type: 'POST',
            dataType: 'json',
            data: { UserName: $('#txtUserName').val(), Password: $('#txtPassword').val() },
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