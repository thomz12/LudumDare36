using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int score;
    public int tech;


    private static GameObject instance;
    public static GameObject Instance
    {
        get
        {
            return Instance;
        }
        set
        {
            if (instance == null)
                Instance = GameObject.FindWithTag("GameManager");
        }
    }
}
