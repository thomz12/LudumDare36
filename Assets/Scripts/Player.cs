﻿using UnityEngine;
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

        if(!GameManager.Instance.getUpgrade(0))
        {
            Destroy(GameObject.FindWithTag("WheelBorrow"));
            GameObject.FindWithTag("Egg").transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            GameObject.FindWithTag("Egg").layer = 0;
            transform.GetChild(0).GetChild(1).transform.eulerAngles = new Vector3(0, 0, 190);
            transform.GetChild(0).GetChild(2).transform.eulerAngles = new Vector3(0, 0, 460);
            GameObject.FindWithTag("Egg").GetComponent<SpringJoint2D>().enabled = true;
        }

        if (GameManager.Instance.getUpgrade(2))
            GameObject.FindWithTag("WheelBorrow").transform.GetChild(0).gameObject.SetActive(true);

        if (GameManager.Instance.getUpgrade(7))
            transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float actualSpeed = maxSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && GameManager.Instance.getUpgrade(1))
            actualSpeed *= sprintMultiplier;

        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0));

        if (body.velocity.x > actualSpeed)
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        if(body.velocity.x < -actualSpeed)
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
