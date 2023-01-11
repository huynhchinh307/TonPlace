﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TonPlace
{
    class FileIO
    {
        public static void Create(string filename)
        {
            if (!File.Exists(filename))
            {
                var myFile = File.Create(filename);
                myFile.Close();
            }
        }

        public static void Create_File_From_Json(string json, string path)
        {
        Again:
            try
            {
                if (!File.Exists(path))
                {
                    var myFile = File.Create(path);
                    myFile.Close();
                    WriteFilePath(path, json);
                }
                else
                {
                    File.Delete(path);
                    var myFile = File.Create(path);
                    myFile.Close();
                    WriteFilePath(path, json);
                }
            }
            catch
            {
                Thread.Sleep(5000);
                goto Again;
            }
        }

        public static string ReadFile(string filename)
        {
            string text;
            var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                lock (streamReader)
                {
                    text = streamReader.ReadToEnd();
                }
            }
            fileStream.Close();
            return text;
        }

        public static void WriteFile(string filename, string text)
        {
            using (FileStream fs = File.Open("Data//" + filename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
            }
            var fileStream = new FileStream("Data//" + filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (var sw = new StreamWriter(fileStream, Encoding.UTF8))
            {
                lock (sw)
                {
                    sw.WriteLine(text);
                }
            }
            fileStream.Close();
        }

        public static void WriteFilePath(string path, string text)
        {
            using (FileStream fs = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                lock (fs)
                {
                    fs.SetLength(0);
                }
            }
            var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (var sw = new StreamWriter(fileStream, Encoding.UTF8))
            {
                lock (sw)
                {
                    sw.WriteLine(text);
                }
            }
            fileStream.Close();
        }
    }
}
