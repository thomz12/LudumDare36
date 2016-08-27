using UnityEngine;
using System.Collections;

public class LandscapeGen : MonoBehaviour {

    public GameObject Landscape;
    private int spawnCount = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x >= 190 + 480*spawnCount)
        {
            GameObject go = (GameObject)Instantiate(Landscape);
            spawnCount++;
            go.transform.position = new Vector3(480 * spawnCount, 0, 0);
            
        }
	}
}
