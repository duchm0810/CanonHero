using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieScripts : MonoBehaviour {

    Rigidbody2D rb;
    bool grouded = false;
    Vector3 de = new Vector3(-2.47f, -3.85f,0);
    public GameObject Expar;
	void Start () {
        
        rb = GetComponent<Rigidbody2D>();   
        Vector3 dir = de - transform.position;
        Instantiate(Expar, this.transform.position, Quaternion.identity);
        //rb.velocity = Vector3.up * 10; 
    }
    private void Update()
    {
        //if (!grouded)
        //{
        //    transform.Rotate(Vector3.forward * 30000 * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Rotate(Vector3.forward * 0 * Time.fixedDeltaTime);
        //}
        //if(transform.position.y < -15)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider != null)
        {
            grouded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.collider != null)
        {
            grouded = false;
        }
    }

}
