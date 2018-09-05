using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

    public static SoundManager sm;
    public AudioClip canonShot, lazerShot, bulletShot, rockShot, magicShot, canonReload, bulletReload;
    public AudioSource audio;
    public bool isReplay = false;
    
    public bool soundOn;
    

    private void Awake()
    {
        isReplay = false;
        if (sm == null)
        {
            sm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        soundOn = true;
    }
    private void Update()
    {
       
    }

    // Update is called once per frame
    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip, 1);
    }
    public void MuteButton()
    {
        if (soundOn)
        {
            soundOn = false;
        }
        else{
            soundOn = true;
        }
    }
    public void replay()
    {
        isReplay = true;
        Application.LoadLevel(Application.loadedLevel);
        Invoke("delay", 0.5f);
    }
    void delay()
    {
        UIManager.ui.panel.SetActive(false);
        GameParameter.parameter._state = GameParameter.State.Ready;
        print("done");
    }
}
