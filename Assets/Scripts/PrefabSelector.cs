using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSelector : MonoBehaviour {

    public bool isEnemyList;
    public GameObject[] List;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public GameObject givePrefab()
    {
        if(isEnemyList)
        {

        }
        else
        {
            int i = Random.Range(0, List.Length);
            return List[i];
        }
        return null;
    }
}
