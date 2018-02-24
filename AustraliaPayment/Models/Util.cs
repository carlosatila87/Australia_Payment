using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AustraliaPayment.Models
{
    
    public class Util
    {
        public static string Log(string Text)
        {
            string fileName = "Payments_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            string path = System.Web.HttpContext.Current.Server.MapPath("/Logs/" + fileName);

            try
            {

                if (!System.IO.File.Exists(path))
                {
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(Text);
                    }
                    return fileName;
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
                    {
                        sw.WriteLine(Text);
                    }
                    return fileName;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "";
            }
        }        
    }    
}