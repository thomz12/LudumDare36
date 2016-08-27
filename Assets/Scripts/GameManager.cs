using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int score;
    public int tech;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            }
            return _instance;
        }
        set
        {
            ;
        }
    }
}
