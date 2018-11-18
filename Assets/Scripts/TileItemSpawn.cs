using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItemSpawn : MonoBehaviour
{

    public int prefabSpawn = 0;
    public int enemySpawn = 0;
    List<Vector3> TakeSpots = new List<Vector3>();

    void Start()
    {
        PrefabSelector objects = GetComponent<PrefabSelector>();
        EnemySelector enemies = GetComponent<EnemySelector>();
        for (int i = 0; i < prefabSpawn; i++)
        {
            float testX = Random.Range(-24 + transform.position.x, 24 + transform.position.x);
            int useX = Mathf.RoundToInt(testX);
            float testZ = Random.Range(-24 + transform.position.z, 24 + transform.position.z);
            int useZ = Mathf.RoundToInt(testZ);
            Vector3 testSpot = new Vector3(useX, 0, useZ);
            if (CheckSpots(testSpot))
            {
                GameObject addMe = Instantiate(objects.givePrefab(), testSpot, Quaternion.identity) as GameObject;
                addMe.transform.parent = transform;
                TakeSpots.Add(testSpot);
            }
        }
        for (int i = 0; i < enemySpawn; i++)
        {
            float testX = Random.Range(-24 + transform.position.x, 24 + transform.position.x);
            int useX = Mathf.RoundToInt(testX);
            float testZ = Random.Range(-24 + transform.position.z, 24 + transform.position.z);
            int useZ = Mathf.RoundToInt(testZ);
            Vector3 testSpot = new Vector3(useX, 0, useZ);
            if (CheckEnemySpots(testSpot))
            {
                GameObject addMe = Instantiate(enemies.givePrefab(), testSpot, Quaternion.identity) as GameObject;
                addMe.transform.parent = transform;
                TakeSpots.Add(testSpot);
            }
            else i--;
        }
    }

    void Update()
    {

    }

    bool CheckSpots(Vector3 test)
    {
        test.x -= 2;
        test.z -= 2;
        for (int z = 0; z < 5; z++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (TakeSpots.Contains(test))
                {
                    return false;
                }
                test.x += 1;
            }
            test.z += 1;
            test.x -= 5;
        }
        return true;
    }


    bool CheckEnemySpots(Vector3 test)
    {

        if (TakeSpots.Contains(test))
        {
            return false;
        }
        return true;
    }
}
