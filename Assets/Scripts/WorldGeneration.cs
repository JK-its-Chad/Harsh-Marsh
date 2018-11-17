using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour {

    static Vector3 NORTHWEST =  new Vector3(-50, 0, 50);
    static Vector3 NORTH =      new Vector3(0, 0, 50);
    static Vector3 NORTHEAST =  new Vector3(50, 0, 50);
    static Vector3 WEST =       new Vector3(-50, 0, 0);
    static Vector3 EAST =       new Vector3(50, 0, 0);
    static Vector3 SOUTHWEST =  new Vector3(-50, 0, -50);
    static Vector3 SOUTH =      new Vector3(0, 0, -50);
    static Vector3 SOUTHEAST =  new Vector3(50, 0, -50);

    public GameObject[] LoadedTiles = new GameObject[10];
    public List<GameObject> TileList;
    public GameObject baseTile;
    public GameObject Player;

    int seed;

	void Start ()
    {
        seed = (int)System.DateTime.Now.Ticks;
        LoadedTiles[0] = gameObject;            //Spawn         0
        LoadedTiles[1] = spawnTile(NORTHWEST);  //NorthEast     1
        LoadedTiles[2] = spawnTile(NORTH);      //North         2
        LoadedTiles[3] = spawnTile(NORTHEAST);  //NorthEast     3
        LoadedTiles[4] = spawnTile(WEST);       //West          4
        LoadedTiles[5] = gameObject;            //Center        5
        LoadedTiles[6] = spawnTile(EAST);       //East          6
        LoadedTiles[7] = spawnTile(SOUTHWEST);  //SouthWest     7
        LoadedTiles[8] = spawnTile(SOUTH);      //South         8
        LoadedTiles[9] = spawnTile(SOUTHEAST);  //SouthEast     9

        
    }
	
	void Update ()
    {
        //Player goes east
        if (Player.transform.position.x > LoadedTiles[5].transform.position.x + 25)
        {
            GameObject[] oldTiles = new GameObject[3];
            oldTiles[0] = LoadedTiles[1];
            oldTiles[1] = LoadedTiles[4];
            oldTiles[2] = LoadedTiles[7];
            LoadedTiles[1] = LoadedTiles[2];
            LoadedTiles[4] = LoadedTiles[5];
            LoadedTiles[7] = LoadedTiles[8];
            LoadedTiles[2] = LoadedTiles[3];
            LoadedTiles[5] = LoadedTiles[6];
            LoadedTiles[8] = LoadedTiles[9];
            LoadedTiles[3] = spawnTile(LoadedTiles[5].transform.position + NORTHEAST);
            LoadedTiles[6] = spawnTile(LoadedTiles[5].transform.position + EAST);
            LoadedTiles[9] = spawnTile(LoadedTiles[5].transform.position + SOUTHEAST);
            if (oldTiles[0] != LoadedTiles[0]) Destroy(oldTiles[0]);
            if (oldTiles[1] != LoadedTiles[0]) Destroy(oldTiles[1]);
            if (oldTiles[2] != LoadedTiles[0]) Destroy(oldTiles[2]);
        }
        //Player goes west
        if (Player.transform.position.x < LoadedTiles[5].transform.position.x - 25)
        {
            GameObject[] oldTiles = new GameObject[3];
            oldTiles[0] = LoadedTiles[3];
            oldTiles[1] = LoadedTiles[6];
            oldTiles[2] = LoadedTiles[9];
            LoadedTiles[3] = LoadedTiles[2];
            LoadedTiles[6] = LoadedTiles[5];
            LoadedTiles[9] = LoadedTiles[8];
            LoadedTiles[2] = LoadedTiles[1];
            LoadedTiles[5] = LoadedTiles[4];
            LoadedTiles[8] = LoadedTiles[7];
            LoadedTiles[1] = spawnTile(LoadedTiles[5].transform.position + NORTHWEST);
            LoadedTiles[4] = spawnTile(LoadedTiles[5].transform.position + WEST);
            LoadedTiles[7] = spawnTile(LoadedTiles[5].transform.position + SOUTHWEST);
            if (oldTiles[0] != LoadedTiles[0]) Destroy(oldTiles[0]);
            if (oldTiles[1] != LoadedTiles[0]) Destroy(oldTiles[1]);
            if (oldTiles[2] != LoadedTiles[0]) Destroy(oldTiles[2]);
        }
        //Player goes north
        if (Player.transform.position.z > LoadedTiles[5].transform.position.z + 25)
        {
            GameObject[] oldTiles = new GameObject[3];
            oldTiles[0] = LoadedTiles[7];
            oldTiles[1] = LoadedTiles[8];
            oldTiles[2] = LoadedTiles[9];
            LoadedTiles[7] = LoadedTiles[4];
            LoadedTiles[8] = LoadedTiles[5];
            LoadedTiles[9] = LoadedTiles[6];
            LoadedTiles[4] = LoadedTiles[1];
            LoadedTiles[5] = LoadedTiles[2];
            LoadedTiles[6] = LoadedTiles[3];
            LoadedTiles[1] = spawnTile(LoadedTiles[5].transform.position + NORTHWEST);
            LoadedTiles[2] = spawnTile(LoadedTiles[5].transform.position + NORTH);
            LoadedTiles[3] = spawnTile(LoadedTiles[5].transform.position + NORTHEAST);
            if (oldTiles[0] != LoadedTiles[0]) Destroy(oldTiles[0]);
            if (oldTiles[1] != LoadedTiles[0]) Destroy(oldTiles[1]);
            if (oldTiles[2] != LoadedTiles[0]) Destroy(oldTiles[2]);
        }
        //Player goes south
        if (Player.transform.position.z < LoadedTiles[5].transform.position.z - 25)
        {
            GameObject[] oldTiles = new GameObject[3];
            oldTiles[0] = LoadedTiles[1];
            oldTiles[1] = LoadedTiles[2];
            oldTiles[2] = LoadedTiles[3];
            LoadedTiles[1] = LoadedTiles[4];
            LoadedTiles[2] = LoadedTiles[5];
            LoadedTiles[3] = LoadedTiles[6];
            LoadedTiles[4] = LoadedTiles[7];
            LoadedTiles[5] = LoadedTiles[8];
            LoadedTiles[6] = LoadedTiles[9];
            LoadedTiles[7] = spawnTile(LoadedTiles[5].transform.position + SOUTHWEST);
            LoadedTiles[8] = spawnTile(LoadedTiles[5].transform.position + SOUTH);
            LoadedTiles[9] = spawnTile(LoadedTiles[5].transform.position + SOUTHEAST);
            if (oldTiles[0] != LoadedTiles[0]) Destroy(oldTiles[0]);
            if (oldTiles[1] != LoadedTiles[0]) Destroy(oldTiles[1]);
            if (oldTiles[2] != LoadedTiles[0]) Destroy(oldTiles[2]);
        }
    }

    GameObject spawnTile(Vector3 spawnPos)
    {
        Random.InitState((int)((Mathf.PerlinNoise((spawnPos.x - 1000) / 1000, (spawnPos.z - 1000) / 1000)) * 1000));
        return Instantiate(TileList[Random.Range(0, TileList.Count)], spawnPos, Quaternion.identity);
    }
}
