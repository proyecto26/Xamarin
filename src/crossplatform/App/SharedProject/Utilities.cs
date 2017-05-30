using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SharedProject
{
    class Utilities
    {
        public string GetFilePath(string fileName)
        {
            #if __ANDROID__
                string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            #elif __IOS__
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libraryPath = Path.Combine(documentsPath, "..", "Library");
            #else
                string libraryPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            #endif
            var path = Path.Combine(libraryPath, fileName);

            return path;
        }
    }
}
