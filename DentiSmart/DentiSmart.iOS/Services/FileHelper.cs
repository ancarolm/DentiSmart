using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DentiSmart.iOS.Services;
using DentiSmart.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace DentiSmart.iOS.Services
{
    public class FileHelper : IfileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder =
                   Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libFolder =
                   Path.Combine(docFolder, "..", "Databases");

            if (Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }
    }
}