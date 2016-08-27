using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public Transform Target;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Target)
        {
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Target.position.x, transform.position.y, transform.position.z), ref velocity, 3.0f * Time.deltaTime);
        }
	}
}
