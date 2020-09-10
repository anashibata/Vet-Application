using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Argus.Models
{
    public class Util
    {
        public static void UpLoadImagem(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/uploads"), fileName);
                file.SaveAs(path);                
            }          
        }
    }
}