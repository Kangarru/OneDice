/*
 *  Document   : base_forms_wizard.js
 *  Author     : pixelcave
 *  Description: Custom JS code used in Form Wizard Page
 */

var BaseFormWizard = function() {
    // Init simple wizard, for more examples you can check out http://vadimg.com/twitter-bootstrap-wizard-example/
    var initWizardSimple = function(){
        jQuery('.js-wizard-simple').bootstrapWizard({
            'tabClass': '',
            'firstSelector': '.wizard-first',
            'previousSelector': '.wizard-prev',
            'nextSelector': '.wizard-next',
            'lastSelector': '.wizard-last',
            'onTabShow': function($tab, $navigation, $index) {
		var $total      = $navigation.find('li').length;
		var $current    = $index + 1;
		var $percent    = ($current/$total) * 100;

                // Get vital wizard elements
                var $wizard     = $navigation.parents('.block');
                var $progress   = $wizard.find('.wizard-progress > .progress-bar');
                var $btnPrev    = $wizard.find('.wizard-prev');
                var $btnNext    = $wizard.find('.wizard-next');
                var $btnFinish  = $wizard.find('.wizard-finish');

                // Update progress bar if there is one
		if ($progress) {
                    $progress.css({ width: $percent + '%' });
                }

		// If it's the last tab then hide the last button and show the finish instead
		if($current >= $total) {
                    $btnNext.hide();
                    $btnFinish.show();
		} else {
                    $btnNext.show();
                    $btnFinish.hide();
		}
            },
                onTabClick: function($tab, $navigation, $index) {
                    return false;
                },
                'onNext': function ($tab, $navigation, $index) {
                    function IsPowerOfTwo(x) {
                        return (x != 0) && ((x & (x - 1)) == 0);
                    }
                    if ($index == 1) {
                        if (!$("#game-name").val()) {
                            oneDiceNotify("You must enter a name", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                            return false;
                        }
                        if (!$("#game-game").val()) {
                            oneDiceNotify("You must select a game type", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                            return false;
                        }
                        if (!$("#game-description").val()) {
                            oneDiceNotify("Pls add a brief description of your game", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                            return false;
                        }
                        return true;
                    }
                    else if ($index == 2) {
                        var lastId;
                        $("[id^='step-block-']").each(function () {
                            lastId = this.id.split('-')[2];
                        });
                        if (lastId) {
                            if (!$("#competitiontype-" + lastId).val()) {
                                oneDiceNotify("You must select a competition type", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                            if (!$("#egress-" + lastId).val() || $("#egress-" + lastId).val() < 1) {
                                oneDiceNotify("There must be a value in previous egress", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;;
                            }
                            if (parseInt($("#egress-" + lastId).val()) > parseInt($("#ingress-" + lastId).val())) {
                                $("#egress-" + lastId + ", #ingress-" + lastId).addClass('has-error');
                                setTimeout(function () { $("#egress-" + lastId + ", #ingress-" + lastId).removeClass('has-error'); }, 5000);
                                oneDiceNotify("Egress must be less than or equal to Ingress", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                            if ($("#competitiontype-" + lastId).val() == "3") {
                                if (!IsPowerOfTwo($("#ingress-" + lastId).val())) {
                                    oneDiceNotify("Ingress for a single elimination must be a power of 2", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                    return false;
                                }
                            }
                            if (!$("#ingress-" + lastId).val() >= 1) {
                                oneDiceNotify("Ingress must be greater than or equal to 1", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                            $("[id^='step-block-']").each(function () {
                                xId = this.id.split('-')[2];
                                $("#egress-" + xId + ", #ingress-" + xId + ", #competitiontype-" + xId).prop("readonly", true);
                                $("#competitiontype-" + xId).prop("disabled", true);
                            });
                            $("#removestage-" + lastId).hide();
                        }
                        else {
                            oneDiceNotify("You must add at least one stage", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                            return false;
                        }
                    }
                    else if ($index == 3) {
                        if(!$("#score-type").val()){
                            oneDiceNotify("You must select a score type", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                            return false;
                        }
                        if($("#minimum-score").length)
                        {
                            if (!$("#minimum-score").val()) {
                                oneDiceNotify("You must enter a minimum score", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                            if (!$("#maximum-score").val()) {
                                oneDiceNotify("You must enter a maximum score", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                            if($("#minimum-score").val() >= $("#maximum-score").val())
                            {
                                oneDiceNotify("Maximum score should be greater than the minimum", "danger", "top", "center", "fa fa-bomb", "rubberBand");
                                return false;
                            }
                        }
                    }
                    else {

                    }
                }
        });
    };

    // Init wizards with validation, for more examples you can check out http://vadimg.com/twitter-bootstrap-wizard-example/
    var initWizardValidation = function(){
        // Get forms
        var $form1 = jQuery('.js-form1');
        var $form2 = jQuery('.js-form2');

        // Prevent forms from submitting on enter key press
        $form1.add($form2).on('keyup keypress', function (e) {
            var code = e.keyCode || e.which;

            if (code === 13) {
                e.preventDefault();
                return false;
            }
        });

        // Init form validation on classic wizard form
        var $validator1 = $form1.validate({
            errorClass: 'help-block animated fadeInDown',
            errorElement: 'div',
            errorPlacement: function(error, e) {
                jQuery(e).parents('.form-group > div').append(error);
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
                'validation-classic-firstname': {
                    required: true,
                    minlength: 2
                },
                'validation-classic-lastname': {
                    required: true,
                    minlength: 2
                },
                'validation-classic-email': {
                    required: true,
                    email: true
                },
                'validation-classic-details': {
                    required: true,
                    minlength: 5
                },
                'validation-classic-city': {
                    required: true
                },
                'validation-classic-skills': {
                    required: true
                },
                'validation-classic-terms': {
                    required: true
                }
            },
            messages: {
                'validation-classic-firstname': {
                    required: 'Please enter a firstname',
                    minlength: 'Your firtname must consist of at least 2 characters'
                },
                'validation-classic-lastname': {
                    required: 'Please enter a lastname',
                    minlength: 'Your lastname must consist of at least 2 characters'
                },
                'validation-classic-email': 'Please enter a valid email address',
                'validation-classic-details': 'Let us know a few thing about yourself',
                'validation-classic-skills': 'Please select a skill!',
                'validation-classic-terms': 'You must agree to the service terms!'
            }
        });

        // Init form validation on the other wizard form
        var $validator2 = $form2.validate({
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
                'validation-firstname': {
                    required: true,
                    minlength: 2
                },
                'validation-lastname': {
                    required: true,
                    minlength: 2
                },
                'validation-email': {
                    required: true,
                    email: true
                },
                'validation-details': {
                    required: true,
                    minlength: 5
                },
                'validation-city': {
                    required: true
                },
                'validation-skills': {
                    required: true
                },
                'validation-terms': {
                    required: true
                }
            },
            messages: {
                'validation-firstname': {
                    required: 'Please enter a firstname',
                    minlength: 'Your firtname must consist of at least 2 characters'
                },
                'validation-lastname': {
                    required: 'Please enter a lastname',
                    minlength: 'Your lastname must consist of at least 2 characters'
                },
                'validation-email': 'Please enter a valid email address',
                'validation-details': 'Let us know a few thing about yourself',
                'validation-skills': 'Please select a skill!',
                'validation-terms': 'You must agree to the service terms!'
            }
        });

        // Init classic wizard with validation
        jQuery('.js-wizard-classic-validation').bootstrapWizard({
            'tabClass': '',
            'previousSelector': '.wizard-prev',
            'nextSelector': '.wizard-next',
            'onTabShow': function($tab, $nav, $index) {
		var $total      = $nav.find('li').length;
		var $current    = $index + 1;

                // Get vital wizard elements
                var $wizard     = $nav.parents('.block');
                var $btnNext    = $wizard.find('.wizard-next');
                var $btnFinish  = $wizard.find('.wizard-finish');

		// If it's the last tab then hide the last button and show the finish instead
		if($current >= $total) {
                    $btnNext.hide();
                    $btnFinish.show();
		} else {
                    $btnNext.show();
                    $btnFinish.hide();
		}
            },
            'onNext': function($tab, $navigation, $index) {
                var $valid = $form1.valid();

                if(!$valid) {
                    $validator1.focusInvalid();

                    return false;
                }
            },
            onTabClick: function($tab, $navigation, $index) {
		return false;
            }
        });

        // Init wizard with validation
        jQuery('.js-wizard-validation').bootstrapWizard({
            'tabClass': '',
            'previousSelector': '.wizard-prev',
            'nextSelector': '.wizard-next',
            'onTabShow': function($tab, $nav, $index) {
		var $total      = $nav.find('li').length;
		var $current    = $index + 1;

                // Get vital wizard elements
                var $wizard     = $nav.parents('.block');
                var $btnNext    = $wizard.find('.wizard-next');
                var $btnFinish  = $wizard.find('.wizard-finish');

		// If it's the last tab then hide the last button and show the finish instead
		if($current >= $total) {
                    $btnNext.hide();
                    $btnFinish.show();
		} else {
                    $btnNext.show();
                    $btnFinish.hide();
		}
            },
            'onNext': function($tab, $navigation, $index) {
                var $valid = $form2.valid();

                if(!$valid) {
                    $validator2.focusInvalid();

                    return false;
                }
            },
            onTabClick: function($tab, $navigation, $index) {
		return false;
            }
        });
    };

    return {
        init: function () {
            // Init simple wizard
            initWizardSimple();

            // Init wizards with validation
            initWizardValidation();
        }
    };
}();

// Initialize when page loads
jQuery(function(){ BaseFormWizard.init(); });