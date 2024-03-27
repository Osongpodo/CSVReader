using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clipboard : MonoBehaviour
{
    public GameObject cell;
    public GameObject instance;
    List<GameObject> cells;
    
    void Start()
    {
        cells = new List<GameObject>();
        //read the CSV file and make cell instance
        makeCell();
    }

    void makeCell()
    {
        //Vector3 cellPosition;
        float xPosition;
        float yPosition;
        float zPosition;
        float scale;

        List<Dictionary<string, object>> data_Dialog = CSVReader.Read("result");

        
        for (int i = 0; i < data_Dialog.Count; i++)
        {

            //print(data_Dialog[i]["Position X [m]"].ToString() + " : " + data_Dialog[i]["Position Y [m]"].ToString() + " : " + data_Dialog[i]["Position Z [m]"].ToString() + " : " + data_Dialog[i]["Diameter [m]"].ToString());

            //print(data_Dialog[i]["Position X [m]"]);

            instance = Instantiate(cell);
            cells.Add(instance);

            xPosition = float.Parse(data_Dialog[i]["Position X [m]"].ToString());
            yPosition = float.Parse(data_Dialog[i]["Position Y [m]"].ToString());
            zPosition = float.Parse(data_Dialog[i]["Position Z [m]"].ToString());
            scale = float.Parse(data_Dialog[i]["Diameter [m]"].ToString());

            instance.transform.position = new Vector3(xPosition, yPosition, zPosition);
            instance.transform.localScale = new Vector3(scale, scale, scale);

            Debug.Log(instance.transform.position);
        }
    }
}
