using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {

    private bool _isFired;
    public float reloadTime;
    private float _timer;

    private Vector3 pos;

    void Start()
    {
        _isFired = false;

        if(GameManager.Instance.getUpgrade(4))
        {
            transform.localScale += new Vector3(0.5F, 0.3F, 0.3F);
        }
    }

    void Update()
    {
        if (!_isFired && Input.GetMouseButtonUp(0))
        {
            _isFired = true;
            pos = transform.localPosition;
            gameObject.AddComponent<Rigidbody2D>();
            gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 1000);
            _timer = reloadTime;
        }
        if (!_isFired && GameManager.Instance.getUpgrade(3))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        _timer -= Time.deltaTime;

        if(_timer < 0 && _isFired)
        {
            transform.localPosition = pos;
            Destroy(GetComponent<Rigidbody2D>());
            _isFired = false;
        }
    }
}
