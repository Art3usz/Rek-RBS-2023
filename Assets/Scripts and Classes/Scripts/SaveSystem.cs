using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class SaveSystem : MonoBehaviour

{
    Dictionary<string, MyObject> myObj;
    private string path = "";
    private string persistentPath = "";
    public TextMeshProUGUI time;
    private void Start () {
        if (myObj == null)
            myObj = new Dictionary<string, MyObject> ();
        RefreshTime ();
        fillDict ();
        DefinitePaths ();
    }

    private void fillDict () {
        for (int id = 0; id < 10; id++) {
            MyObject mO = new MyObject (id + " " + System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss"));
            myObj.Add ("" + id, mO);
        }

    }

    public void RefreshTime () {
        time.text = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
    }

    public static string CreateJSON (MyObject myObject) {
        return JsonUtility.ToJson (myObject);
    }

    private void LoadFromJSON (string jsonString) {

        myObj = JsonConvert.DeserializeObject<Dictionary<string, MyObject>> (jsonString);
        Debug.Log (myObj);
        time.text = myObj["1"].text;

    }
    private void DefinitePaths () {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

    }
    // Start is called before the first frame update
    public void LocalSave () {
        string savePath = persistentPath;
        string json = JsonConvert.SerializeObject (myObj);
        using StreamWriter writer = new StreamWriter (savePath);
        writer.Write (json);

    }

    public void LocalLoad () {
        using StreamReader reader = new StreamReader (persistentPath);
        string json = reader.ReadToEnd ();
        LoadFromJSON (json);
    }
}