using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Twilio
{
    public class NewCall
    {


        public void MessageLogTFN(string title, string msg)
        {
            try
            {
                String FilePath = HttpContext.Current.Server.MapPath("CallTwilio.txt");
                FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine("FFRSApplication: [" + title + "] " + DateTime.Now.ToString() + " \n");
                m_streamWriter.WriteLine(" " + msg + " \n");
                m_streamWriter.WriteLine(" ------------------------------------------------------------------- \n");
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
            catch (Exception)
            {
                // MessageLogTFN("CallTwillio:", "Error = " + ex.Message);
            }
        }

        public string GetRedirectUrl(String Url)
        {
            if (Url.Length > 0)
            {
                String[] urlArr = Url.Split('/');
                Url = urlArr[0] + "//";
                if (urlArr[2].Contains(":"))
                {
                    Url = Url + urlArr[2];
                }
                else
                {
                    Url = Url + urlArr[2] + "/" + urlArr[3];
                }
            }
            return Url + "/Default.aspx";
        }

        public string GetRedirectUrl(String Url, string Self)
        {
            if (Url.Length > 0)
            {
                String[] urlArr = Url.Split('/');
                Url = urlArr[0] + "//";
                if (urlArr[2].Contains(":"))
                {
                    Url = Url + urlArr[2];
                }
                else
                {
                    Url = Url + urlArr[2] + "/" + urlArr[3];
                }
            }
            return Url + "/Default.aspx";
        }
    }
}