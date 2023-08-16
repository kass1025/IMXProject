$(function () {
    var userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

    function onUserLoginClick() {
        var url = "/UserAuthentication/Login";
        var antiForgeryToken = $("#UserLoginModal input[name='__RequestVerificationToken']").val();


        var email = $("#UserLoginModal input[name='Email']").val();
        var password = $("#UserLoginModal input[name='Password']").val();
        var rememberMe = $("#UserLoginModal input[name='RememberMe']").prop('checked');

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            RememberMe: rememberMe
        };
        alert(email);
        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasError = $(parsed).find("input[name='LoginInValid']").val() == "true";
                if (hasError == true) {
                    $("#UserLoginModal").html(data);
                    userLoginButton = $("#UserLoginModal button[name='login']").click(onUserLoginClick);

                    $("#UserLoginModal").removeData("validator");
                    $("#UserLoginModal").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserLoginModal");
                }
                else {
                    location.href = 'Home/Index';

                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);

            }

        });
    }
});