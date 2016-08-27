using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum State { MENU, PLAY, UPGRADE};
    private float _tech;
    public int score;
    public State GameState;

    public float getTech()
    {
        return _tech;
    }
    public void setTech(float change)
    {
        _tech += change;
    }

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

