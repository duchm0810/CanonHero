using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBullet : MonoBehaviour {

    public GameObject player,viewer, finder;
    Weapon weapon;
    
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = player.transform.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) *2* Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(dir * (weapon.speed * Time.deltaTime));  
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Player")
        {
            Instantiate(weapon.effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
