using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void Start()
    {
        GameObject.FindGameObjectWithTag("GameOver_points").GetComponent<Text>().text = "You got " + GameManager.Instance.score + "m far";
        GameObject.FindGameObjectWithTag("GameOver_tech").GetComponent<Text>().text = "You earned " + (float)GameManager.Instance.score/10 + " Tech!";
        if(GameManager.Instance.getUpgrade(5))
            GameObject.FindGameObjectWithTag("GameOver_tech").GetComponent<Text>().text = "You earned " + ((float)GameManager.Instance.score / 10 * 2) + " Tech!";

        GameManager.Instance.setTech(GameManager.Instance.score);
        GameObject.FindGameObjectWithTag("GameOver_techtotal").GetComponent<Text>().text = "Total Tech: " + (float)GameManager.Instance.getTech();

    }

    public void ClickRestart()
    {
        GameManager.Instance.GameState = GameManager.State.PLAY;
        SceneManager.LoadScene(0);
    }

    public void ClickSpend()
    {
        GameObject go = GameObject.FindWithTag("TechTree");
        go.GetComponent<TechMenu>().On = true;
        GameObject.FindGameObjectWithTag("UpgradeMenu_tech").GetComponent<Text>().text = "Tech Points: " + GameManager.Instance.getTech();
    }

    public void ClickBack()
    {
        GameObject go = GameObject.FindWithTag("TechTree");
        go.GetComponent<TechMenu>().On = false;
    }
}
