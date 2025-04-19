using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Utility
{
    public static class APPConstants
    {
        public static string LoginSuccessfully = "Login Done Successful";
        public static string PendingValidOTP = "Pending Valid OTP";
        public static string OTPSentSuccessfully = "Pending Valid OTP";
        public static string OTPTemplate = "Please use this OTP for verify user ";
        public static string OTPTemplateTitle = "Email Verification";
        public static string ExceptionSYSTEMIDNOTSET = "Setting of System User ID Not Set Correctly";
        public static readonly string FirstName = "FirstName";
        public static readonly string LastName = "LastName";
        public static string ByFileExtensions = "pdf, doc, docx, ppt, pptx, xls, xlsx, png, jpeg, jpg, mpp, gif, bmp, tif, tiff";

        public static string AsposeLicensePath { get; set; }
        public static string DbConnectionString { get; set; }

    }
}
