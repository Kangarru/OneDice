
var OneDicePagelet = function () {
    var AnchorLeafs = function () {
        $(".leaf").click(function () {
            $.ajax({
                url: $(this).attr('data-url'),
                success: function (result) {
                    $("#onedice-content").empty();
                    $("#onedice-content").html(result);
                },
                beforeSend: function (xhr) {
                    $("#onedice-content").empty();
                    $("#onedice-content").html("<br/><h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='si si-settings fa-spin'></i> Loading...</h2>");
                },
                error: function (xhr, status, error) {
                    $("#onedice-content").empty();
                    $("#onedice-content").html("<br/><h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-warning'></i> Couldn't fetch the page, pls try again</h2>");
                }
            });
        });
    };
    return {
        init: function () {
            AnchorLeafs();
        }
    }
}();

var OneDice = function () {
    var LoadDashBoard = function () {
        $.ajax({
            url: 'templates/dashboard',
            success: function (result) {
                $("#onedice-content").empty();
                $("#onedice-content").html(result);
            },
            beforeSend: function (xhr) {
                $("#onedice-content").empty();
                $("#onedice-content").html("<h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='si si-settings fa-spin'></i> Loading...</h2>");
            },
            error: function (xhr, status, error) {
                $("#onedice-content").empty();
                $("#onedice-content").html("<h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-warning'></i> Couldn't fetch the page, pls try again</h2>");
            }
        });
    }
    return {
        init: function () {
            LoadDashBoard();
        }
    }
}();

var OnBegin = function () {
    SmartUnLoad();
    $.SmartMessageBox({ title: "<i class='si si-settings fa-spin'></i> Processing...", content: "", sound: "0" });
};

var PleaseWait = function () {
    SmartUnLoad();
    $.SmartMessageBox({ title: "<i class='si si-settings fa-spin'></i> Please wait...", content: "", sound: "0" });
};
var OnSuccessUnload = function () {
    SmartUnLoad();
};

var OnSuccessDisplay = function (s) {
    SmartUnLoad();
    $.SmartMessageBox({
        title: "<i class='fa fa-clock-o'></i>Successful!",
        content: s,
        buttons: '[Ok]'
    });
    e.preventDefault();
};

var OnSuccess = function () {
    SmartUnLoad();
    $.smallBox({
        title: "Successful",
        content: "<i class='fa fa-thumbs-o-up'></i> <i>Operation completed successfully</i>",
        color: "#34a263",
        iconSmall: "fa fa-check fa-2x fadeInRight animated",
        timeout: 3000
    });
}

var OnFail = function () {
    SmartUnLoad();
    $.smallBox({
        title: "Error",
        content: "<i class='fa fa-warning'></i> <i>Operation failed!</i>",
        color: "#c54736",
        iconSmall: "fa fa-times fa-2x fadeInRight animated",
        timeout: 4000
    });
};

var oneDiceNotify = function (msg, type, from, align, icon, anim, url) {
    var $notifyMsg = msg;
    var $notifyType = type ? type : 'info';
    var $notifyFrom = from ? from : 'top';
    var $notifyAlign = align ? align : 'right';
    var $notifyIcon = icon ? icon : '';
    var $notifyUrl = url ? url : '';
    var $anim = anim ? anim : 'fadeIn';

    jQuery.notify({
        icon: $notifyIcon,
        message: $notifyMsg,
        url: $notifyUrl
    },
        {
            element: 'body',
            type: $notifyType,
            allow_dismiss: true,
            newest_on_top: true,
            showProgressbar: false,
            placement: {
                from: $notifyFrom,
                align: $notifyAlign
            },
            offset: 20,
            spacing: 10,
            z_index: 1031,
            delay: 5000,
            timer: 1000,
            animate: {
                enter: 'animated ' + $anim,
                exit: 'animated fadeOutDown'
            }
        });
}

// Initialize when page loads
jQuery(function () {
    OneDice.init();
    OneDicePagelet.init();
});
