using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        GetComponent<Animator>().SetFloat("MovementSpeed", body.velocity.x);
	}
}
