using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float sprintMultiplier;
    public float deacceleration;

	// Use this for initialization
	void Start ()
    {
        GameManager.Instance.transform.position = new Vector3(10, 10, 10);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float actualSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
            actualSpeed *= sprintMultiplier;

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        //body.velocity = new Vector2(Input.GetAxis("Horizontal") * actualSpeed, body.velocity.y);
        body.AddForce(new Vector2(Input.GetAxis("Horizontal") * actualSpeed, 0));

        if (body.velocity.x > maxSpeed)
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        if(body.velocity.x < -maxSpeed)
            body.velocity = new Vector2(-maxSpeed, body.velocity.y);

        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1f)
        {
            if(body.velocity.x > 0.0f)
                body.velocity = new Vector2(body.velocity.x - deacceleration * Time.deltaTime, body.velocity.y);
            else
                body.velocity = new Vector2(body.velocity.x + deacceleration * Time.deltaTime, body.velocity.y);
        }

        GetComponent<Animator>().SetFloat("MovementSpeed", body.velocity.x);
	}
}
