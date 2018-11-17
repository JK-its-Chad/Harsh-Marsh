using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItemSpawn : MonoBehaviour {

    public int prefabSpawn = 0;
    List<Vector3> TakeSpots = new List<Vector3>();

    public GameObject prefab;

	void Start ()
    {
        for (int i = 0; i < prefabSpawn; i++)
        {
            float testX = Random.Range(-25 + transform.position.x, 25 + transform.position.x);
            int useX = Mathf.RoundToInt(testX);
            float testZ = Random.Range(-25 + transform.position.z, 25 + transform.position.z);
            int useZ = Mathf.RoundToInt(testZ);
            Vector3 testSpot = new Vector3(useX, 0, useZ);
            if (CheckSpots(testSpot))
            {
                GameObject addMe = Instantiate(prefab, testSpot, Quaternion.identity) as GameObject;
                addMe.transform.parent = transform;
                TakeSpots.Add(testSpot);
            }
        }
    }
	
	void Update ()
    {

	}

    bool CheckSpots(Vector3 test)
    {
        test.x -= 1;
        test.z -= 1;
        for (int z = 0; z <= 2; z++)
        {
            test.z += z;
            for (int x = 0; x <= 2; x++)
            {
                test.x += x;
                if (TakeSpots.Contains(test))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
