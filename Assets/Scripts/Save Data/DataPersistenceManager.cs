using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]

    [SerializeField] private string fileName;

    [SerializeField] private bool useEncryption;

    private SaveData saveData;

    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("DataPesistenceManager: More than one instance found!");
        }

        instance = this;
    }

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadData();
    }

    public void NewData()
    {
        saveData = new SaveData();
    }

    public void LoadData()
    {
        //load any saved data from file using data handler
        saveData = dataHandler.Load();

        //if no saved data found, create new data instead
        if (saveData == null)
        {
            Debug.Log("DataPesistenceManager: No saved data found! Creating new data...");
            NewData();
        }

        //push the new data to scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(saveData);
        }
    }

    public void SaveData()
    {
        //pass the data so other scripts cann update it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref saveData);
        }

        //save the data to a file using data handler
        dataHandler.Save(saveData);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
