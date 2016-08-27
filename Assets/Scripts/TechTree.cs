using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TechTree : MonoBehaviour {

    public int cost;
    public string techTreeName;
    public TechTree[] unlock;
    public bool unlocked;
    public bool bought;
    public string desc;

    private bool _tooltip;

	void Start ()
    {
        GetComponentInChildren<Text>().text = techTreeName + "\n" + cost + " Tech";

        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.PointerEnter, OnPointerEnter);
        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.PointerExit, OnPointerExit);
        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.PointerClick, OnPointerClick);
    }

    public static void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, System.Action<BaseEventData> callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
        trigger.triggers.Add(entry);
    }

    public void OnPointerClick(BaseEventData data)
    {
        if (bought || !unlocked)
            return;

        if (GameManager.Instance.getTech() >= cost)
        {
            GameManager.Instance.setTech(-cost);
            GameObject.FindGameObjectWithTag("UpgradeMenu_tech").GetComponent<Text>().text = "Tech Points: " + GameManager.Instance.getTech();
            bought = true;
        }
    }

    public void OnPointerExit(BaseEventData data)
    {
        GameObject go = GameObject.FindWithTag("Tooltip");
        go.GetComponent<RectTransform>().position = ((PointerEventData)data).position;
        go.GetComponent<Image>().enabled = false;
        go.GetComponentInChildren<Text>().enabled = false;

        _tooltip = false;
    }

    public void OnPointerEnter(BaseEventData data)
    {
        GameObject go = GameObject.FindWithTag("Tooltip");
        RectTransform trans = go.GetComponent<RectTransform>();
        trans.position = new Vector2(((PointerEventData)data).position.x + trans.sizeDelta.x / 2, ((PointerEventData)data).position.y - trans.sizeDelta.y / 2);
        go.GetComponent<Image>().enabled = true;
        go.GetComponentInChildren<Text>().enabled = true;
        go.GetComponentInChildren<Text>().text = desc;

        _tooltip = true;
    }

	void Update ()
    {
	    foreach(TechTree t in unlock)
        {
            if (!t.bought)
            {
                unlocked = false;
                break;
            }
            unlocked = true;
        }

        if(_tooltip)
        {
            GameObject go = GameObject.FindWithTag("Tooltip");
            RectTransform trans = go.GetComponent<RectTransform>();
            trans.position = new Vector2(Input.mousePosition.x + trans.sizeDelta.x / 2, Input.mousePosition.y - trans.sizeDelta.y / 2);

            go.GetComponent<Image>().enabled = true;
            go.GetComponentInChildren<Text>().enabled = true;
        }

        if(unlocked)
        {
            GetComponentInChildren<Image>().color = new Color(101 / 255f, 255 / 255f, 102 / 255f);
            if (GameManager.Instance.getTech() < cost)
            {
                GetComponentInChildren<Image>().color = new Color(255 / 255f, 255 / 255f, 102 / 255f);
            }
        }

        if(bought)
        {
            GetComponentInChildren<Image>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        }
	}
}
