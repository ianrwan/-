using UnityEngine;
using Newtonsoft.Json;
using System;

using Megumin.MeguminException;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Megumin.FileSystem
{
    public class JsonConverter
    {
        FileIO fileIO;
        public JsonConverter() : this(""){}

        public JsonConverter(string path)
        {
            fileIO = new FileIO(path);
        }

        // 將 json 進行 serealize
        // input parameter: 傳入要 serealize 的物件
        // output parameter: json format string
        // ex:
        //
        // class Player{string name, int age}
        // Player player
        // player.name = "Megumin", player.age = 14
        // =>
        // string json = {name: Megumin, age: 14}
        public string JsonSerealize<T>(T obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            }
            catch(Exception e)
            {
                Debug.LogError(ExceptionHandleWord.JsonSerealWrong);
                Debug.LogError(e);
                return null;
            }
        }

        // 將物件以 json 的形式存入指定 file
        // input parameter:
        // obj = the object you wanted to save to json format
        // path = absolute directory of the file you wanna save to
        public void JsonSaveToFile<T>(T obj, string path)
        {
            string tempJson;
            tempJson = JsonSerealize<T>(obj);
            JsonSaveToFIle(tempJson, path);
        }

        // 將 json: string 存入指定的 file
        // input parameter:
        // json = json format string
        // path = absolute directory of the file you wanna save to
        public void JsonSaveToFIle(string json, string path)
        {
            fileIO.WriteStringToFile_Cover(path, json);
        }

        // 將 json: string deserealize 成指定物件
        // input parameter:
        // json = json foramat string
        //
        // output parameter:
        // object you wanna get from json
        //
        // ex:
        // json = {name: Megumin, age = 14}
        // =>
        // player(optional object, the object will have datas name = "Megumin" and age = 14) 
        public T JsonDeSerealize<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }


        // 將 json file 的資料轉為指定的物件
        // input parameter:
        // path = absolute directory of the file you wanna save to
        //
        // output parameter:
        // object you wanna get from json
        public T FileToJson<T>(string path)
        {
            string json = fileIO.ReadFileToString(path);
            var obj = JsonDeSerealize<T>(json);
            return obj;
        }

        public JObject JsonParse(string path)
        {
            string json = fileIO.ReadFileToString(path);
            JObject jsonObj = JObject.Parse(json);
            return jsonObj;
        }

        public List<T> FileToJsonArray1D<T>(string path, string arrayName)
        {
            var jsonObj = JsonParse(path);
            List<T> list = new List<T>();

            foreach(var data in jsonObj[arrayName])
            {
                var temp = JsonDeSerealize<T>(data.ToString());
                list.Add(temp);
            }

            return list;
        }

        public List<T> FileToJsonArray1D<T>(string path)
        {
            return FileToJsonArray1D<T>(path, "data");
        }
    }
}

