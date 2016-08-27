using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TechMenu : MonoBehaviour {

    public Vector2 offset;
    private bool on;

    public bool On { get { return on; } set { TurnOn(value); on = value; } }

    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    public bool clicking;

    private Vector2 oldmouse;

	// Use this for initialization
	void Start ()
    {
        transform.parent.GetComponent<Canvas>().enabled = on;
    }

    void TurnOn(bool onoff)
    {
        transform.parent.GetComponent<Canvas>().enabled = onoff;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 mousedelta = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - oldmouse;
        oldmouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        if (on)
        {
            if(clicking)
            {
                offset += new Vector2(mousedelta.x, mousedelta.y);
                transform.GetChild(0).GetComponent<RectTransform>().localPosition = offset;
            }

            if (offset.x > 500)
                offset = new Vector2(500, offset.y);
            if(offset.x < -250)
                offset = new Vector2(-250, offset.y);

            if(offset.y > 200)
                offset = new Vector2(offset.x, 200);
            if (offset.y < -200)
                offset = new Vector2(offset.x, -200);
        }

        transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector2(Mathf.Clamp(transform.GetChild(0).GetComponent<RectTransform>().localPosition.x, minX, maxX), Mathf.Clamp(transform.GetChild(0).GetComponent<RectTransform>().localPosition.y, minY, maxY));
        offset = transform.GetChild(0).GetComponent<RectTransform>().localPosition;
    }

    public void ClickDown(BaseEventData data)
    {
        clicking = true;
    }

    public void ClickUp(BaseEventData data)
    {
        clicking = false;
    }
}
