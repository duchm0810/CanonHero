using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundNONSTATE : MonoBehaviour {

    public bool isTaget = false;
	// Use this for initialization
	void Start () {
        //GetComponent<SpriteRenderer>().color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x >= -9.2 && GameParameter.parameter._state == GameParameter.State.Ready && isTaget)
        {
            transform.Translate(Vector2.left * 3f * Time.deltaTime);
        }
        else if(transform.position.x <-9.2 && GameParameter.parameter._state == GameParameter.State.Ready && isTaget)
        {
            Destroy(gameObject);
        }       
    }
}
