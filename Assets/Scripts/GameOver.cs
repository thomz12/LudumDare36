using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public void ClickRestart()
    {
        Application.LoadLevel(0);
    }

    public void ClickSpend()
    {
        GameObject go = GameObject.FindWithTag("TechTree");
        go.GetComponent<TechMenu>().On = true;
    }

    public void ClickBack()
    {
        GameObject go = GameObject.FindWithTag("TechTree");
        go.GetComponent<TechMenu>().On = false;
    }
}
