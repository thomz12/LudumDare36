using UnityEngine;
using System.Collections;

public class Landscape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("MainCamera").transform.position.x >= this.transform.position.x + 350)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
