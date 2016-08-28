using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public enum State { MENU, PLAY, UPGRADE};

    private int _tech;
    private int _upgrades;

    public int score;
    public State GameState;
    

    public void setUpgrade(int u)
    {
        _upgrades += (int)Mathf.Pow(2,u);
    } 

    public bool getUpgrade(int u)
    {
        return (_upgrades & (int)Mathf.Pow(2,u)) == (int)Mathf.Pow(2, u);
    }

    public float getTech()
    {
        return (float)_tech/10;
    }
    public void setTech(int change)
    {
        _tech += change;
        if (getUpgrade(5))
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

