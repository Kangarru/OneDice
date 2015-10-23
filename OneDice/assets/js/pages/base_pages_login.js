/*
 *  Document   : base_pages_login.js
 *  Author     : pixelcave
 *  Description: Custom JS code used in Login Page
 */

var BasePagesLogin = function() {
    // Init Login Form Validation, for more examples you can check out https://github.com/jzaefferer/jquery-validation
    var initValidationLogin = function(){
        jQuery('.js-validation-login').validate({
            errorClass: 'help-block text-right animated fadeInDown',
            errorElement: 'div',
            errorPlacement: function(error, e) {
                jQuery(e).parents('.form-group .form-material').append(error);
            },
            highlight: function(e) {
                jQuery(e).closest('.form-group').removeClass('has-error').addClass('has-error');
                jQuery(e).closest('.help-block').remove();
            },
            success: function(e) {
                jQuery(e).closest('.form-group').removeClass('has-error');
                jQuery(e).closest('.help-block').remove();
            },
            rules: {
                'login-email': {
                    required: true,
                    minlength: 3,
                    email: true,
                },
                'login-password': {
                    required: true,
                    minlength: 5
                }
            },
            messages: {
                'login-email': {
                    required: 'Please enter a username',
                    minlength: 'Your username must consist of at least 3 characters',
                    email: 'Please enter a valid e-mail address',
                },
                'login-password': {
                    required: 'Please provide a password',
                    minlength: 'Your password must be at least 5 characters long'
                }
            }
        });
    };

    return {
        init: function () {
            // Init Login Form Validation
            initValidationLogin();
        }
    };
}();

// Initialize when page loads
jQuery(function () {
    BasePagesLogin.init();

    function loginSuccess(data, textStatus, jqXHR) {
        if(!data.action){
            $("#error_msg").html("OneDice does not recognize these credentials").removeClass("slideInDown").addClass("slideInDown");
            $("#login-password").removeClass('has-error').addClass('has-error');
            $("#login-email").removeClass('has-error').addClass('has-error');
        }
        else {
            window.location = data.action;
        }
    }
    function loginFail(jqXHR, textStatus, errorThrown) {
        window.location = window.location.href;
    }
});

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    var id_token = googleUser.getAuthResponse().id_token;
    
    var user = { id_token: id_token, Name: profile.getName(), ImageURL: profile.getImageUrl(), Email: profile.getEmail() };
    $.ajax({
        type: 'POST',
        url: "/register",
        data: user,
        dataType: 'json',
        success: function (data) {
            if (!data.action) {
                $("#error_msg").html(data.error).removeClass("slideInDown").addClass("slideInDown");
            }
            else {
                window.location = data.action;
            }
        }
    });
}
