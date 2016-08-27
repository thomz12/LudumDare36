using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Egg")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500,3000));
        }
    }
}
