using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;

    public GameObject[] list;
    public List<GameObject> listPlayer = new List<GameObject>();


    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
    }
    // Use this for initialization
    void Start () {
        GameObject obj = null;
        int counter = 0;
        bool done = false;
        while (!done)
        {
            obj = Resources.Load("Player/" + counter) as GameObject;
            if (obj == null)
                done = true; 
            else
                listPlayer.Add(obj);
            ++counter;
        }
        checkUnlockandCurrent();
        selectGround();
    }
	
	// Update is called once per frame
	void Update () {
        //if (GameParameter.parameter.isShot)
        //{
        //    GameParameter.parameter.isShot = false;
        //    GameObject[] bullet = GameObject.FindGameObjectsWithTag("Weapon");
        //    if (bullet.Length ==0)
        //    GameParameter.parameter._state = GameParameter.State.Bot;
        //}
        if(GameParameter.parameter.shot >= 3)
        {
            GameParameter.parameter._state = GameParameter.State.Bot;
        }
        
    }
    public void selectGround()
    {
        int index = Random.Range(0, list.Length);
        Instantiate(list[index], new Vector3(9.2f, -7, 0), Quaternion.identity);
    }

    void checkUnlockandCurrent()
    {
        int x = 0;
        for(int i = 0; i < listPlayer.Count;i++)
        {
            // Get Current Player
            if (PlayerPrefs.GetInt((i)+"current") == 1)
            {
                GameObject player = GameObject.Instantiate(listPlayer[i], new Vector3(-3.3f, -5f, 0), Quaternion.identity) as GameObject;
                x++;
            }
        }
        if (x == 0)
        {
            GameObject player = GameObject.Instantiate(listPlayer[0], new Vector3(-3.3f, -5f, 0), Quaternion.identity) as GameObject;
        }
    }
   public void makeCoin()
    {
        GameParameter.parameter.score++;
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + (int)Random.Range(4, 7));

    }
}
