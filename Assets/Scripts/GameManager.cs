using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum State { MENU, PLAY, UPGRADE};
    public float tech;
    public int score;
    public State GameState;


    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; } set { ; }
    }

    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
