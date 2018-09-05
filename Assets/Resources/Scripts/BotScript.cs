using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour {

    public GameObject player, viewer, finder, wp;
    public GameObject dieBot;
    bool shot = false;
	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
       // transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(transform.right, player.transform.position));
    }
	
	// Update is called once per frame
	void Update () {
        if(player != null)
        {
            Vector3 dir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            viewer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (GameParameter.parameter._state == GameParameter.State.Bot && !shot)
            {
                shot = true;
                Invoke("fire", 0.5f);
            }
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
	}

    void fire()
    {
        Vector3 direction = player.transform.position - transform.position;
        Instantiate(wp, finder.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Weapon")
        {
            Instantiate(dieBot, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
