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

	void Start ()
    {
        GetComponentInChildren<Text>().text = techTreeName + "\n" + cost + " Tech";

        AddEventTriggerListener(GetComponent<EventTrigger>(), EventTriggerType.PointerDown, OnPointerEnter);
    }

    public static void AddEventTriggerListener(EventTrigger trigger, EventTriggerType eventType, System.Action<BaseEventData> callback)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = eventType;
        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(new UnityEngine.Events.UnityAction<BaseEventData>(callback));
        trigger.triggers.Add(entry);
    }


    public void OnPointerEnter(BaseEventData data)
    {
        Debug.Log("adsl;fkjasdf");
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

        if(unlocked)
        {
            GetComponentInChildren<Image>().color = new Color(101 / 255f, 255 / 255f, 102 / 255f);
        }
	}
}
