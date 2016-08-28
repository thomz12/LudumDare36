using UnityEngine;
using System.Collections;

public class SpearScript : MonoBehaviour {

    void Start()
    {
        if(GameManager.Instance.getUpgrade(4))
        {
            transform.localScale += new Vector3(0.5F, 0.3F, 0.3F);
        }
    }

    void Update()
    {
        if (GameManager.Instance.getUpgrade(3))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
