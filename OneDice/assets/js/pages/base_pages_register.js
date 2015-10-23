/*
 *  Document   : base_pages_register.js
 *  Author     : pixelcave
 *  Description: Custom JS code used in Register Page
 */

var BasePagesRegister = function() {
    // Init Register Form Validation, for more examples you can check out https://github.com/jzaefferer/jquery-validation
    var initValidationRegister = function(){
        jQuery('.js-validation-register').validate({
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
                'register-username': {
                    required: true,
                    minlength: 3
                },
                'register-email': {
                    required: true,
                    email: true,
                    remote: {
                        url: "validate/email",
                        type: "post",
                        data: {
                            email: function () {
                                return $("#register-email").val();
                            }
                        }
                    }
                },
                'register-password': {
                    required: true,
                    minlength: 5
                },
                'register-password2': {
                    required: true,
                    equalTo: '#register-password'
                }
            },
            messages: {
                'register-username': {
                    required: 'Please enter a username',
                    minlength: 'Your username must consist of at least 3 characters'
                },
                'register-email': {
                    required: 'Please enter a valid email address',
                    email: 'Please enter a valid email address',
                    remote: 'Email address already taken',
                },
                'register-password': {
                    required: 'Please provide a password',
                    minlength: 'Your password must be at least 5 characters long'
                },
                'register-password2': {
                    required: 'Please provide a password',
                    minlength: 'Your password must be at least 5 characters long',
                    equalTo: 'Please enter the same password as above'
                }
            }
        });
    };

    return {
        init: function () {
            // Init Register Form Validation
            initValidationRegister();
        }
    };
}();

// Initialize when page loads
jQuery(function () {
    BasePagesRegister.init();

    function registerSuccess(data, textStatus, jqXHR) {
        if (!data.action) {
            $("#error_msg").html("OneDice could not validate these credentials").removeClass("slideInDown").addClass("slideInDown");
            $("#register-username").removeClass('has-error').addClass('has-error');
            $("#register-email").removeClass('has-error').addClass('has-error');
            $("#register-password").removeClass('has-error').addClass('has-error');
            $("#register-password2").removeClass('has-error').addClass('has-error');
        }
        else {
            window.location = data.action;
        }
    }
    function registerFail(jqXHR, textStatus, errorThrown) {
        window.location = window.location.href;
    }
});