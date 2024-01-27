using UnityEngine;

using Megumin.FileSystem;
using Megumin.DataStructure;

public class TestReadWrite : MonoBehaviour
{
    public void Start()
    {
        string temp;
        string readPath = Application.dataPath+@"/Storage/test/test.txt";
        string writePath = Application.dataPath+@"/Storage/test/testStore.txt";

        FileIO fileIO = new FileIO();
        temp = fileIO.ReadFileToString(readPath);
        Debug.Log(temp);

        fileIO.WriteStringToFile_Cover(writePath, temp);

        var list = fileIO.ReadFileToList(readPath);
        Debug.Log("list num\n"+list.Count);
        Debug.Log("list\n"+StringConverter.ListStringToString(list));
    }
}
