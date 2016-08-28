using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

    private bool jumped;

	// Use this for initialization
	void Start () {
        jumped = false;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);

        if (!jumped && Vector3.Distance(new Vector3(GameObject.FindWithTag("Egg").transform.position.x, transform.position.y, transform.position.z), transform.position) < 3.0f)
        {
            jumped = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 2500));
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Egg")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500,3000));
        }
    }
}
