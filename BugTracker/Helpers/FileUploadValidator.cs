﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BugTracker.Helpers
{
    public  class FileUploadValidator
    {
        public static bool IsWebFriendlyImage(HttpPostedFileBase file)
        {
            if (file == null) return false;

            if (file.ContentLength > 10 * 1024 * 1024 || file.ContentLength < 1024) return false;

            try
            {
                using (var img = Image.FromStream(file.InputStream))
                {
                    return ImageFormat.Jpeg.Equals(img.RawFormat) ||
                        ImageFormat.Png.Equals(img.RawFormat) ||
                        ImageFormat.Gif.Equals(img.RawFormat);
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool IsWebFriendlyFile(HttpPostedFileBase file)
        {
            if (file == null) return false;

            var maxSize = WebConfigurationManager.AppSettings["MaxFileSize"];
            var minSize = WebConfigurationManager.AppSettings["MinFileSize"];
            if (file.ContentLength > Convert.ToInt32(maxSize) || file.ContentLength < Convert.ToInt32(minSize))
            return false;

            try
            {
                var allowedExtensions = WebConfigurationManager.AppSettings["AllowedExtension"];
                var fileExt = Path.GetExtension(file.FileName);
                return allowedExtensions.Contains(fileExt);

            }
            catch
            {
                return false;
            }
        }
    }

}