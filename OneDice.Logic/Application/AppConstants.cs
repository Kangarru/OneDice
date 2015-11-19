using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Logic
{
    public class AppConstants
    {
        public static string ErrorBigBox(string message)
        {
            return @"<script type='text/javascript'>SmartUnLoad();$.bigBox({title : 'Failed',content : '" + message.Replace("'", "\"") + @"',color : '#C46A69',icon : 'fa fa-warning shake animated',number : '1',});</script>";
        }
        public static string ErrorBigBox(string message, string redirectUrl)
        {
            return @"<script type='text/javascript'>SmartUnLoad();$.bigBox({title : 'Failed',content : '" + message.Replace("'", "\"") + @"',color : '#C46A69',icon : 'fa fa-warning shake animated',number : '1',});$('[id*=\'botClose\']').click(function(){$('[data-dismiss=modal]').trigger({ type: 'click' });$('.modal-backdrop').hide();$.ajax({url: '" + redirectUrl + @"',success: function (result) {$('#onedice-content').html(result);},beforeSend: function (xhr) {$('#onedice-content').html('<h2><i class=\'si si-settings fa-spin\'></i> Loading...</h2>');},error: function (xhr, status, error) {$('#onedice-content').html('<h2><i class=\'fa fa-warning\'></i> Couldn\'t fetch the page, pls try again</h2>');}});});</script>";
        }
        public static string SuccessBigBox(string message)
        {
            return @"<script type='text/javascript'>SmartUnLoad();$.bigBox({title : 'Successful',content : '" + message.Replace("'", "\"") + @"',color : '#659265',icon : 'fa fa-warning shake animated',number : '1',});</script>";
        }
        public static string SuccessBigBox(string message, string redirectUrl)
        {
            return @"<script type='text/javascript'>SmartUnLoad();$.bigBox({title : 'Successful',content : '" + message.Replace("'", "\"") + @"',color : '#659265',icon : 'fa fa-warning shake animated',number : '1',});$('[id*=\'botClose\']').click(function(){$('[data-dismiss=modal]').trigger({ type: 'click' });$('.modal-backdrop').hide();$.ajax({url: '" + redirectUrl + @"',success: function (result) {$('#onedice-content').html(result);},beforeSend: function (xhr) {$('#onedice-content').html('<h2><i class=\'si si-settings fa-spin\'></i> Loading...</h2>');},error: function (xhr, status, error) {$('#onedice-content').html('<h2><i class=\'fa fa-warning\'></i> Couldn\'t fetch the page, pls try again</h2>');}});});</script>";
        }
    }
}
