using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour {

    public GameObject EggTop,
                      EggBottom;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            //TODO GAMESTATE
            GameObject.Destroy(this.gameObject);
            GameObject go = (GameObject)Instantiate(EggTop);
            go.transform.position = this.gameObject.transform.position;
            GameObject go2 = (GameObject)Instantiate(EggBottom);
            go2.transform.position = this.gameObject.transform.position;
        }
    }
}
