using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject dieSprite;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (GameParameter.parameter._state == GameParameter.State.Ready)
        {
            anim.SetBool("isReady", true);
        }
        else
        {
            anim.SetBool("isReady", false);
        }
        if (Input.GetMouseButton(0) && !UIManager.ui.panel.active)
        {
            anim.SetBool("fire", true);
        }
        else
        {
            anim.SetBool("fire", false);
        }
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Weapon")
        {
            GetComponent<SpriteRenderer>().enabled = false;
            //IntersititialsAds.admob.showAds();
            Instantiate(dieSprite, transform.position,Quaternion.identity);
            GameParameter.parameter._state = GameParameter.State.None;
            UIManager.ui.showP();
            Destroy(this.gameObject);
        }
    }
    
}
