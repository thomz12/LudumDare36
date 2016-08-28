using UnityEngine;
using System.Collections;

public class EggCanon : MonoBehaviour {

    public GameObject egg;
    public bool shot = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position) < 10)
            if(!shot)
                StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        shot = true;
        yield return new WaitForSeconds(2);
        GameObject go = (GameObject)Instantiate(egg, transform.position, transform.rotation);

        go.transform.localScale = new Vector3(0.10f, 0.09f, 0.5f);
        go.transform.tag = "Ground";
        Destroy(go.GetComponent<SpringJoint2D>());
        Destroy(go.GetComponent<Egg>());
        shot = false;
    }
}
