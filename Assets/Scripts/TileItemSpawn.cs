using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileItemSpawn : MonoBehaviour {

    public class Positions
    {
        int x;
        int z;
        public Positions(int offsetX, int offsetZ)
        {
            x = offsetX;
            z = offsetZ;
        }
        public Vector3 Location()
        {
            return new Vector3(x, 0, z);
        }
    }

    public int prefabSpawn = 0;
    List<Positions> TakeSpots = new List<Positions>();

	void Start ()
    {
		
	}
	
	void Update ()
    {
		for(int i = 0; i < prefabSpawn; i++)
        {
            float testX = Random.Range(-25 + transform.position.x, 25 + transform.position.x);
            int useX = Mathf.RoundToInt(testX);
            float testZ = Random.Range(-25 + transform.position.z, 25 + transform.position.z);
            int useZ = Mathf.RoundToInt(testZ);
            Vector3 testSpot = new Vector3(useX, 0, useZ);
            //if()
        }
	}
}
