using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParameter : MonoBehaviour {

    public static GameParameter parameter;

    public ShakingCamera shakingCamera;

    public bool shaking = false;
    public bool bulletCol = false;
    public int shot = 0;
    public int choosePlayer;
    public bool isShot;
    public int score, coin;
    public bool replay;

    public enum State
    {
        Player,Bot,Ready,None
    }

    public State _state;


    private void Awake()
    {
        if(parameter == null)
        {
            parameter = this;
        }
        if (PlayerPrefs.GetInt("choosePlayer") == 0)
        {
            PlayerPrefs.SetInt("choosePlayer", 1);
        }
    }
    private void Start()
    {
        score = 0;
        _state = State.None;
        choosePlayer = PlayerPrefs.GetInt("choosePlayer");
     //   prints();
    }

    public void ShakeCamera()
    {
        StartCoroutine(shakingCamera.Shake(0.15f, 0.4f));
    }
    void prints()
    {
        print(PlayerPrefs.GetInt("0current"));
        print(PlayerPrefs.GetInt("1current"));
        print(PlayerPrefs.GetInt("2current"));
        print(PlayerPrefs.GetInt("3current"));
        print(PlayerPrefs.GetInt("choosePlayer"));
        
    }
}
