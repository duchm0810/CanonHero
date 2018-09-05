using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerDownHandler
{
    public GameObject PlayerShower,text;
    public Sprite equip, equiped;
    GameObject btnSel;
    private void Start()
    {
        PlayerShower = GameObject.Find("PlayerShower");
        text = GameObject.Find("Price");
        btnSel = GameObject.Find("btnSelect");
    }
    private void Update()
    {
        if(text == null)
        {
            text = GameObject.Find("Price");
        }
        if(btnSel == null)
        {
            btnSel = GameObject.Find("btnSelect");
        }
        
    }
    public void OnPointerDown(PointerEventData data)
    {
        Destroy(GameObject.FindWithTag("Player"));
        PlayerPrefs.SetInt("choosePlayer", int.Parse(gameObject.name));
        GameObject playerSelected = GameObject.Instantiate(PlayPreManager.ppm.listPlayer[PlayerPrefs.GetInt("choosePlayer")], PlayerShower.transform.position, Quaternion.identity) as GameObject;
        playerSelected.transform.localScale = new Vector3(1, 1, 1);
        playerSelected.GetComponent<PlayerController>().enabled = false;
        if (PlayerPrefs.GetInt(PlayerPrefs.GetInt("choosePlayer") + "unlock") ==1)
        {
            PlayPreManager.ppm.btnSelect.SetActive(true);
            PlayPreManager.ppm.btnBuy.SetActive(false);
            if (PlayerPrefs.GetInt(PlayerPrefs.GetInt("choosePlayer") + "current") ==1)
            {
                btnSel.GetComponent<Button>().image.sprite = equiped;
            }
            else
            {
                btnSel.GetComponent<Button>().image.sprite = equip;
            }
            if (text == null)
            {
                text = GameObject.Find("Price");
                text.GetComponent<Text>().text = PlayPreManager.ppm.listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price.ToString();
            }
            else
            {
                text.GetComponent<Text>().text = PlayPreManager.ppm.listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price.ToString();
            }
        }
        else
        {
            PlayPreManager.ppm.btnBuy.SetActive(true);
            PlayPreManager.ppm.btnSelect.SetActive(false);
            if (text == null)
            {
                text = GameObject.Find("Price");
                text.GetComponent<Text>().text = PlayPreManager.ppm.listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price.ToString();
            }
            else
            {
                text.GetComponent<Text>().text = PlayPreManager.ppm.listPlayer[PlayerPrefs.GetInt("choosePlayer")].GetComponent<PLayerModel>().price.ToString();
            }
        }
    }
}
