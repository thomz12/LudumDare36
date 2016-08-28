using UnityEngine;
using System.Collections;

public class DinoAI : MonoBehaviour {

    private bool dead;

	// Use this for initialization
	void Start () {
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (dead)
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Animator>().speed = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x / 10);
        if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) > 25.0f)
            return;

        if(!dead)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);

        // Jump
        //if (!jumped && Vector3.Distance(new Vector3(GameObject.FindWithTag("Egg").transform.position.x, transform.position.y, transform.position.z), transform.position) < 3.0f)
        //{
        //    jumped = true;
        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
        //}
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Egg")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1500,3000));
        }

        if(collision.gameObject.transform.tag == "WheelBorrow")
        {
            dead = true;
            GetComponentInChildren<BoxCollider2D>().enabled = false;
            GetComponentInChildren<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * -1, transform.localScale.z);
        }
    }
}
