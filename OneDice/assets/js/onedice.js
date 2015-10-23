
var OneDicePagelet = function () {
    var AnchorLeafs = function () {
        $(".leaf").click(function () {
            $.ajax({
                url: $(this).attr('data-url'),
                success: function (result) {
                    $("#onedice-content").html(result);
                },
                beforeSend: function (xhr) {
                    $("#onedice-content").html("<br/><h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-cog fa-spin'></i> Loading...</h2>");
                },
                error: function (xhr, status, error) {
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
                $("#onedice-content").html(result);
            },
            beforeSend: function (xhr) {
                $("#onedice-content").html("<h2>&nbsp;&nbsp;&nbsp;&nbsp;<i class='fa fa-cog fa-spin'></i> Loading...</h2>");
            },
            error: function (xhr, status, error) {
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

// Initialize when page loads
jQuery(function () {
    OneDice.init();
    OneDicePagelet.init();
});