using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Megumin.MeguminException;

namespace Megumin.FileSystem
{
    // 要進行 file 讀取存取的 class
    // 讀取的資料會將資料格式轉變為 string or list 傳回
    public class DatabaseSystem
    {
        private string path;
        private List<string> dataStore;

        public DatabaseSystem(string path)
        {
            this.path = path;
            dataStore = new List<string>();
        }

        // 若沒有傳入 path，path 會是空值，需要自己設定，否則會報錯
        public DatabaseSystem() : this(""){}

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

            try
            {
                if(path == "" || path == null)
                    throw new Exception(ExceptionHandleWord.exceptionWordFileWrong);

                using(StreamReader sr = new StreamReader(path))
                {
                    line = sr.ReadLine();

                    while(line != null)
                    {
                        dataStore.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordFileWrong);
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
                    throw new Exception();

                using(StreamReader sr = new StreamReader(path))
                {
                    string temp = "";
                    while((temp = sr.ReadLine()) != null)
                    {
                        line += temp;
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordFileWrong);
                Debug.LogWarning(e);
            }

            return line;
        }

        public string ReadFileToString()
        {
            return this.ReadFileToString(this.path);
        }

        // WriteStringToFile_Cover 將資料寫入 file 並且覆蓋
        // input parameter: path = the path where to write to (absolute directory only, for instance: C:\...\storage\data.txt)
        public void WriteStringToFile_Cover(string path)
        {
            try
            {
                if(path == "" || path == null)
                    throw new Exception(ExceptionHandleWord.exceptionWordFilePath);

                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine();
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning(ExceptionHandleWord.exceptionWordFileWrong);
                Debug.LogWarning(e);
            }
        }

        public void WriteStringToFile_Cover()
        {
            WriteStringToFile_Cover(this.path);
        }

        public List<string> DeserializeJSON()
        {
            return dataStore;
        }
    }
}
