using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPreManager : MonoBehaviour {
    public static PlayPreManager ppm;
    public GameObject content;
    public GameObject prefab;
    public List<GameObject> listPlayer = new List<GameObject>();
    public List<GameObject> listButton = new List<GameObject>();
    public GameObject btnBuy, btnSelect;
    public Sprite equip, equiped;
    // Use this for initialization

    private void Awake()
    {
        if(ppm == null)
        {
            ppm = this;
        }
    }
    void Start()
    {
       /// PlayerPrefs.SetInt("coin", 90000);
        createListPlayer();
        checkUnlock();
        btnBuy.SetActive(false);
        btnBuy.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        GameObject.Find("CoinText").GetComponent<Text>().text = PlayerPrefs.GetInt("coin").ToString();
	}
    // Checking unlocked
    void checkUnlock()
    {
        for (int i = 0; i < listPlayer.Count; i++)
        {
            if (PlayerPrefs.GetInt(listPlayer[i].GetComponent<PLayerModel>().name+ "unlocked") == 1)
            {
                listPlayer[i].GetComponent<PLayerModel>().unlocked = true;
            }
        }
    }
    void createListPlayer()
    {
        listPlayer.Clear();
        listButton.Clear();
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
            counter++;
        }
        GameObject btn;
        for (int i = 0; i < listPlayer.Count; i++)
        {
            btn = Object.Instantiate(prefab,Vector3.zero,Quaternion.identity) as GameObject;
            btn.name = (i).ToString();
            listButton.Add(btn);
            if(listPlayer[i].GetComponent<PLayerModel>().unlocked)
                btn.GetComponent<Image>().sprite = listPlayer[i].GetComponent<PLayerModel>().unLocksprite;
            else
                btn.GetComponent<Image>().sprite = listPlayer[i].GetComponent<PLayerModel>().lockSprite;
            RectTransform rect = btn.GetComponent<RectTransform>();
            rect.SetParent(content.transform);
            rect.localScale = new Vector3(1,1,1);
            rect.pivot = new Vector2(0.5f,0.5f);
        }
    }
    public void btnPlay()
    {
        Application.LoadLevel("GamePlay");
    }
    public void btnSelectandBuy()
    {
        if (PlayerPrefs.GetInt( PlayerPrefs.GetInt("choosePlayer")+ "unlock") ==1)
        {
            for(int i = 0; i < listPlayer.Count; i++)
            {
                if(i == PlayerPrefs.GetInt("choosePlayer"))
                {
                    PlayerPrefs.SetInt(i + "current", 1);
                    btnSelect.GetComponent<Button>().image.sprite = equiped;
                }
                else
                {
                    PlayerPrefs.SetInt(i + "current", 0);
                    //btnSelect.GetComponent<Button>().image.sprite = equip;
                }
            }
        }
        else
        {
            if(PlayerPrefs.GetInt("coin") >= listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price)
            {
                PlayerPrefs.SetInt(PlayerPrefs.GetInt("choosePlayer").ToString() + "unlock", 1);
                int coin = PlayerPrefs.GetInt("coin")- listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price;
                PlayerPrefs.SetInt("coin", coin);
                
                for (int i = 0; i < listButton.Count; i++)
                {
                    Destroy(listButton[i].gameObject);
                }
                createListPlayer();
                btnBuy.SetActive(false);
                btnSelect.SetActive(true);
                
            }
        }
    }
}
