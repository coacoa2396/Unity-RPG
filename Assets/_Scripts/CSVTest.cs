using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVTest : MonoBehaviour
{
    private void Start()
    {
        List<Dictionary<string, object>> reader = CSVReader.Read("CSV/ItemTable");

        //Debug.Log((string)reader[0]["name"]);
        Debug.Log((string)reader[2]["name"]);
        Debug.Log((int)reader[2]["attack"]);
        Debug.Log((int)reader[2]["defence"]);

    }
}
