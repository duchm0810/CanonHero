using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDie : MonoBehaviour {

    Rigidbody2D rb;
    bool grouded = false;
    Vector3 de = new Vector3(7.5f, 0, 0);
    public GameObject coin;
    void Start()
    {
        Instantiate(coin, this.transform.position, Quaternion.identity);
        rb = GetComponent<Rigidbody2D>();
        Vector3 dir = de - transform.position;
        rb.velocity = dir * 2;
    }
    private void Update()
    {
        transform.Rotate(Vector3.forward * 3000 * Time.deltaTime);
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider != null)
        {
            grouded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider != null)
        {
            grouded = false;
        }
    }

}