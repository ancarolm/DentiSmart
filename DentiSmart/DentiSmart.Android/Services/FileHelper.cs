using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DentiSmart.Droid.Services;
using DentiSmart.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace DentiSmart.Droid.Services
{
    public class FileHelper : IfileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, fileName);
        }
    }
}