using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager ui;
    public GameObject panel,btnReplay,btnPlay;
    public Text text,HSText;
    public Button btnSound;
    public Sprite son, soff;

    private void Awake()
    {
        if (ui == null)
        {
            ui = this;
        }
    }
    private void Start()
    {
        HSText.text = "HIGHSCORE"+"\n"+ PlayerPrefs.GetInt("HighScore").ToString();
        if (btnSound != null)
        {
            SoundManager.sm.audio.volume = 1;
            btnSound.image.sprite = son;
        }
        else
        {
            btnSound = GameObject.Find("BtnSound").GetComponent<Button>();
        }
        if (SoundManager.sm.isReplay)
        {
            btnReplay.SetActive(true);
            btnPlay.SetActive(false);
        }
        else
        {
            btnPlay.SetActive(true);
            btnReplay.SetActive(false);
        }
    }
    private void Update()
    {
        text.text = GameParameter.parameter.score.ToString();
        GameObject.Find("CoinText").GetComponent<Text>().text = PlayerPrefs.GetInt("coin").ToString();
        HSText.text = "HIGHSCORE" + "\n" + PlayerPrefs.GetInt("HighScore").ToString();
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GameParameter.parameter._state = GameParameter.State.Ready;
        //}

        if (SoundManager.sm.soundOn)
        {
            SoundManager.sm.audio.volume = 1;
            btnSound.image.sprite = son;
        }
        else
        {
            SoundManager.sm.audio.volume = 0;
            btnSound.image.sprite = soff;
        }
    }

    public void PlayButton()
    {
        if (SoundManager.sm.isReplay)
        {
            SoundManager.sm.replay();
        }
        else
        {
            SoundManager.sm.isReplay = true;
            GameParameter.parameter._state = GameParameter.State.Ready;
            panel.SetActive(false);
        }
        if (SoundManager.sm.isReplay)
        {
            btnReplay.SetActive(true);
            btnPlay.SetActive(false);
        }
        else
        {
            btnPlay.SetActive(true);
            btnReplay.SetActive(false);
        }

    }
    public void ShopButton()
    {
        Application.LoadLevel("SelectScenes");
    }
    public void RateButton()
    {
        Application.OpenURL("market://details?id=com.ulatech.canon");
    }
    public void ShareButton()
    {

    }
    public void ExiButton()
    {

    }
    public void btnSounds()
    {
        if (SoundManager.sm.soundOn)
        {
            SoundManager.sm.soundOn = false;
        }
        else
        {
            SoundManager.sm.soundOn = true;
        }
    }
    public void showP()
    {
        AdmobIntersititilas.adsi.loadAds();
        Invoke("showpanel", 1f);
    }
    void showpanel()
    {
        UIManager.ui.panel.SetActive(true);
        //Destroy(GameObject.FindGameObjectWithTag("Player"));
        checkScore();
    }
    void checkScore()
    {
        if (GameParameter.parameter.score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", GameParameter.parameter.score);
            GameParameter.parameter.score = 0;
        }
    }
}
