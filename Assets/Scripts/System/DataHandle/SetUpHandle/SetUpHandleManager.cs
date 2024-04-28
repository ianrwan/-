using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpHandleManager : MonoBehaviour
{
    public static SetUpHandleManager instance{get; private set;}

    [SerializeField] private GameObject[] handleDatas;
    private ISetUp[] handleDatasSetUp;
    public bool isCompleteSetUpOnStart{get; private set;}

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isCompleteSetUpOnStart = false;

        handleDatasSetUp = new ISetUp[handleDatas.Length];
        int index = 0;
        foreach(var handleData in handleDatas)
        {
            handleDatasSetUp[index++] = handleData.GetComponent<ISetUp>();
        }
    }

    private void Update()
    {
        if(!TextAssetsManager.instance.isLoaded)
            return;

        if(isCompleteSetUpOnStart)
            return;
        
        StartSetUp();
    }

    private void StartSetUp()
    {
        foreach(var handleData in handleDatasSetUp)
        {
            handleData.SetUp();
        }

        isCompleteSetUpOnStart = true;        
    }
}
