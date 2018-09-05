using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

    public GameObject tower;
    public bool isTaget = false;
	// Use this for initialization
	void Start () {
        createTower();
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x >= 0 && GameParameter.parameter._state == GameParameter.State.Ready && !isTaget)
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
        }
        else if(transform.position.x < 0 &&GameParameter.parameter._state == GameParameter.State.Ready && !isTaget)
        {
            GameParameter.parameter.bulletCol = false;
            GameParameter.parameter.shot = 0;
            GameParameter.parameter._state = GameParameter.State.Player;
            GameParameter.parameter.isShot = false;
            isTaget = true;
        }
        if (transform.position.x >= -9.2 && GameParameter.parameter._state == GameParameter.State.Ready && isTaget)
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
        }
        else if(transform.position.x <-9.2 && GameParameter.parameter._state == GameParameter.State.Ready && isTaget)
        {
            Destroy(gameObject);
        }       
    }

    void createTower()
    {
        float posx = Random.Range(7.5f, 12.5f);
        float posy = Random.Range(-3.5f, -8.5f);
        //Instantiate(tower, new Vector3(posx, posy, 0), Quaternion.identity);
        GameObject item = GameObject.Instantiate(tower, new Vector3(posx, posy, 0), Quaternion.identity) as GameObject;
        item.transform.parent = this.transform;

    }
}
