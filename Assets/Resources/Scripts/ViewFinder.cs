using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFinder : MonoBehaviour {

    public static ViewFinder viewFinder;
    public Vector3 rkVector;
    public GameObject finder;
    public GameObject weapon;
    SpriteRenderer spriteRenderer;
    GameObject scenes;
    bool shot = false;

    private void Awake()
    {
        if (viewFinder == null)
        {
            viewFinder = this;
        }
    }
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        scenes = GameObject.Find("scenes");
    }
	
	// Update is called once per frame
	void Update () {

        if(scenes == null)
        {
            if (!GameParameter.parameter.isShot)
            {
                if (Input.GetMouseButton(0) && GameParameter.parameter._state == GameParameter.State.Player)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("fire", true);
                    spriteRenderer.enabled = true;
                    if (transform.eulerAngles.z < 90)
                    {
                        //print(transform.eulerAngles.z);
                        transform.eulerAngles += new Vector3(0, 0, 1);
                    }

                }
                else if (Input.GetMouseButtonUp(0) && GameParameter.parameter._state == GameParameter.State.Player)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("fire", false);
                    GameParameter.parameter.isShot = true;
                    spriteRenderer.enabled = false;
                    rkVector = finder.transform.position - transform.position;
                    Instantiate(weapon, finder.transform.position, Quaternion.identity);
                    //float angle = Vector3.Angle(finder.transform.position, new Vector3(1,0,0));
                    //print(angle);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    
                }
            }
           
        }
        
	}
}
