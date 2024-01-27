using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Megumin.FileSystem;

public class JsonTest : MonoBehaviour
{
    public Text showText;

    private string path = Application.dataPath;
    private List<string> listText;

    public void Start()
    {
       listText = new List<string>(); 
       showText.text = path;
       AddDataFromFile();
       TestPlayerJsonReadWrite();
    }

    public void AddDataFromFile()
    {
        ReadTxtFile();
        
        string temp = showText.text;
        AddDataAndLine(ref temp);
        showText.text = temp;
    }

    public void ReadTxtFile()
    {
        string temp = "";
        try
        {
            using(StreamReader sm = new StreamReader(path+"/Storage/test/Test_1.txt"))
            {
                while((temp = sm.ReadLine()) is not null)
                    listText.Add(temp);
            }
        }
        catch(FileNotFoundException)
        {
            Debug.LogError("File isn't found");
        }
    }

    public void AddDataAndLine(ref string originData)
    {
        if(listText.Count == 0)
        {
            originData = "It's empty inside the List.";
            return;
        }

        foreach(string temp in listText)
        {
            originData += "\n"+temp;
        }
    }

    private void TestPlayerJsonReadWrite()
    {
        TestPlayerWrite();
        TestPlayerRead();
    }

    private void TestPlayerWrite()
    {
        PlayerTest player_1 = new PlayerTest("Megumin", 9999);
        
        string player_1Json;
        player_1Json = JsonConvert.SerializeObject(player_1, Formatting.Indented);
        Debug.Log(player_1.name+" "+player_1.health);
        Debug.Log(player_1Json);

        string writePath = path+"/Storage/test/player.json";
        try
        {
            if(!File.Exists(writePath))
            {
                using(FileStream fs = File.Create(writePath))
                {

                }
            }

            using(StreamWriter sm = new StreamWriter(writePath))
            {
                sm.WriteLine(player_1Json);
            }
        }
        catch(Exception e)
        {
            Debug.LogError("Here is something wrong: TestPlayerWrite, File Problems\n"+e);
        }
    }

    private void TestPlayerRead()
    {
        List<string> tempList;
        string tempJson = "";
        string writePath = path+"/Storage/test/player.json";
        FileIO ds = new FileIO(writePath);

        try
        {
            if(!File.Exists(writePath))
            {
                throw new Exception("File isn't exist");
            }

            // using(StreamReader sm = new StreamReader(writePath))
            // {
            //     tempJson += sm.ReadLine();
            // }
            tempJson = ds.ReadFileToString();
        }
        catch(Exception e)
        {
            Debug.LogError("Here is something wrong: TestPlayerWrite, File Problems\n"+e);
        }

        PlayerTest player_1 = JsonConvert.DeserializeObject<PlayerTest>(tempJson);
        showText.text += '\n'+"name: "+player_1.name+" "+"health: "+player_1.health;

        for(int i = 0 ; i < 3 ; i++)
        {
            showText.text += '\n'+"items: "+player_1.items[i];
        }
    }
}
