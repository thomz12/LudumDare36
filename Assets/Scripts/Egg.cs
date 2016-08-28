using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Egg : MonoBehaviour {

    public GameObject EggTop;
    public GameObject EggBottom;

    public Text Score;
    private float maxScore;

    public float startPos;

    // Use this for initialization
    void Start () {
        startPos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.GameState == GameManager.State.PLAY)
        {
            maxScore = maxScore > Mathf.Floor(this.gameObject.transform.position.x - startPos) ? maxScore : Mathf.Floor(this.gameObject.transform.position.x - startPos);
            Score.text = maxScore.ToString();
        }
        if (transform.position.x > 50)
            if (GetComponent<SpringJoint2D>())
                GetComponent<SpringJoint2D>().enabled = false;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if((coll.gameObject.tag == "Dino" || coll.gameObject.tag == "Ground") && (GameManager.Instance.GameState == GameManager.State.PLAY))
        {
            GameManager.Instance.GameState = GameManager.State.UPGRADE;
            Score.text = "";
            this.GetComponent<AudioSource>().Play();
            this.GetComponent<PolygonCollider2D>().enabled = false;
            this.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().Target = null;
            GameObject go = (GameObject)Instantiate(EggTop);
            go.transform.position = this.gameObject.transform.position;
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(8000,1000));
            GameObject go2 = (GameObject)Instantiate(EggBottom);
            go2.transform.position = this.gameObject.transform.position;
            go2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-8000, 1000));
            GameManager.Instance.score = (int)maxScore;
            StartCoroutine(Wait());
            
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        GameObject.FindWithTag("GameOver").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Destroy(this.gameObject);
    }
}
