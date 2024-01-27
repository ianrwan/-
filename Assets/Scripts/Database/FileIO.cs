using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Megumin.MeguminException;

namespace Megumin.FileSystem
{
    // 要進行 file 讀取存取的 class
    // 讀取的資料會將資料格式轉變為 string or list 傳回
    public class FileIO
    {
        private string path;

        public FileIO(string path)
        {
            this.path = path;
        }

        // 若沒有傳入 path，path 會是空值，需要自己設定，否則會報錯
        public FileIO() : this(""){}

        // 可以重新設定所要使用的 path
        // input parameter: path = the path where to read to (absolute directory only, for instance: C:\...\storage\data.txt)
        public void SetPath(string path) 
        {
            this.path = path;
        }

        // ReadFileToList 將資料從 file 每行讀取，並將每行轉成 string，再放入 list
        // 舉例以下例子，例子為兩行: 
        //
        // I like Megumin.
        // Explosion is wonderful. 
        // =>
        // list[0] = "I like Megumin."
        // list[1] = "Explosion is wonderful."
        //
        // input parameter: path = the path where to read to (absolute directory only, for instance: C:\...\storage\data.txt)
        public List<string> ReadFileToList(string path)
        {
            string line = null;
            List<string> dataStore = new List<string>();

            try
            {
                if(path == "" || path == null)
                    throw new Exception(ExceptionHandleWord.exceptionWordFilePath);

                this.path = path;

                using(StreamReader sr = new StreamReader(path))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        dataStore.Add(line);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordReadWrong);
                Debug.LogWarning(e);
            }

            return dataStore;
        }

        public List<string> ReadFileToList()
        {
            return ReadFileToList(this.path);
        }

        // ReadFileToString 將資料從 file 讀成有兼具換行的 string
        //
        // I like Megumin.
        // Explosion is wonderful. 
        // =>
        // string = "I like Megumin.\n"+
        // "Explosion is wonderful."
        //
        // input parameter: path = the path where to read to (absolute directory only, for instance: C:\...\storage\data.txt)
        public string ReadFileToString(string path)
        {
            string line = null;

            try
            {
                if(path == "" || path == null)
                    throw new Exception(ExceptionHandleWord.exceptionWordFilePath);
                
                this.path = path;

                using(StreamReader sr = new StreamReader(path))
                {
                    string temp = "";
                    while((temp = sr.ReadLine()) != null)
                    {
                        line += temp+'\n';
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordReadWrong);
                Debug.LogWarning(e);
            }

            return line;
        }

        public string ReadFileToString()
        {
            return this.ReadFileToString(this.path);
        }

        // WriteStringToFile_Cover 將資料寫入 file 並且覆蓋
        // input parameter: 
        // path = the path where to write to (absolute directory only, for instance: C:\...\storage\data.txt)
        // data = the data what you wanna write into file (data should be organized to string and newline)   
        public void WriteStringToFile_Cover(string path, string data)
        {
            try
            {
                if(path == "" || path == null)
                    throw new Exception(ExceptionHandleWord.exceptionWordFilePath);

                this.path = path;

                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(data);
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordWriteWrong);
                Debug.LogWarning(e);
            }
        }

        public void WriteStringToFile_Cover(string data)
        {
            WriteStringToFile_Cover(this.path, data);
        }

        // public List<string> DeserializeJSON()
        // {
        //     return dataStore;
        // }
    }
}
