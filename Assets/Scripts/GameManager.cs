using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum State { MENU, PLAY, UPGRADE};
    public int tech;
    public State GameState;

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
