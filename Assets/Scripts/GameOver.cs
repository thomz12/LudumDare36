using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

    public void Start()
    {
        GameObject.FindGameObjectWithTag("GameOver_points").GetComponent<Text>().text = "You got " + GameManager.Instance.score + "m";
        GameObject.FindGameObjectWithTag("GameOver_tech").GetComponent<Text>().text = "You earned " + (float)GameManager.Instance.score/10 + " Tech";
        GameManager.Instance.tech += ((float)GameManager.Instance.score / 10);
        GameObject.FindGameObjectWithTag("GameOver_techtotal").GetComponent<Text>().text = "Total Tech " + (float)GameManager.Instance.tech+ " Tech";

    }

    public void ClickRestart()
    {
        GameManager.Instance.GameState = GameManager.State.PLAY;
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
