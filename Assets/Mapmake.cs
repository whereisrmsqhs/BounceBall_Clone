using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mapmake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("stage");

        for (int i = 0; i < data_Dialog.Count; i++)
        {
            print(data_Dialog[i]["object"].ToString());
        }
    }
    
}
