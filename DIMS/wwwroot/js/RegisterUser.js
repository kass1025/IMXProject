$(function () {
    $("#UserRegistrationModal input[name='AcceptUserAgreement']").click(OnAcceptUserAgreementClick);
    $("#UserRegistrationModal button[name='register']").prop("disabled", true);
    function OnAcceptUserAgreementClick() {
        if ($(this).is(":checked")) {
            $("#UserRegistrationModal button[name='register']").prop("disabled", false);
        }
        else {
            $("#UserRegistrationModal button[name='register']").prop("disabled", true);
        }
    };

    var userRegisterButton = $("#UserRegistrationModal button[name='register']").click(OnRegisterUserClick);
    function OnRegisterUserClick() {
        var url = "UserAuthentication/RegisterUser";
        var antiForgeryToken = $("#UserRegistrationModal input[name='__RequestVerificationToken']").val();

        var email = $("#UserRegistrationModal input[name='Email']").val();
        var password = $("#UserRegistrationModal input[name='Password']").val();
        var confirmPassword = $("#UserRegistrationModal input[name='ConfirmPassword']").val();
        var firstName = $("#UserRegistrationModal input[name='FirstName']").val();
        var middleName = $("#UserRegistrationModal input[name='MiddleName']").val();
        //var titleName = $("#UserRegistrationModal input[name='TitleName']").val();
        //var genderName = $("#UserRegistrationModal input[name='GenderName']").val();
        var pID = $("#UserRegistrationModal input[name='PID']").val();
        var phoneNumber = $("#UserRegistrationModal input[name='PhoneNumber']").val();
        //var clinicId = $("#UserRegistrationModal input[name='ClinicId']").val();
        alert(email + password + confirmPassword + firstName + middleName + pID + phoneNumber )
        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            MiddleName: middleName,
            //TitleName: titleName,
            //GenderName: genderName,
            PID: pID,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement: true
        };
        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {
                var parsed = $.parseHTML(data);
                var hasError = $(parsed).find("input[name='RegistrationInValid']").val() == "true";
                if (hasError) {
                    $("#UserRegistrationModal").html(data);
                    userRegisterButton = $("#UserRegistrationModal button[name='register']").click(OnRegisterUserClick);

                    $("#UserRegistrationModal").removeData("validator");
                    $("#UserRegistrationModal").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationModal");
                }
                else {
                    location.href = 'Home/Index';
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }

        });
    };
});