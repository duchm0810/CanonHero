using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsWeapon : MonoBehaviour {

    Vector3 wpline, vLeft;
    Rigidbody2D rb;
    Weapon weapon;
    public float time = 0.5f;
    public ShakingCamera shakingCamera;
    bool tg = false;
    public bool ins = false;

    public enum WeaponType
    {
        RockType,
        Archer,
        Bullet,
        Lazer

    }
    public WeaponType weaponType; 
	// Use this for initialization
	void Start () {
        
        shakingCamera = GameObject.Find("Main Camera").GetComponent<ShakingCamera>();  
        weapon = GetComponent<Weapon>();
        rb = GetComponent<Rigidbody2D>();
        rb.mass = weapon.mass;
        wpline = ViewFinder.viewFinder.rkVector;
        rb.velocity = wpline * weapon.speed;
        if (weaponType == WeaponType.Bullet)
        {
            
            if (!ins)
            {
                
                GameObject item1 = GameObject.Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;
                GameObject item2 = GameObject.Instantiate(this.gameObject, this.transform.position, Quaternion.identity) as GameObject;
                item1.GetComponent<PhysicsWeapon>().ins = item2.GetComponent<PhysicsWeapon>().ins = true;
                item1.GetComponent<Weapon>().speed = weapon.speed / 10 * 9;
                item2.GetComponent<Weapon>().speed = weapon.speed / 10 * 8;

            }
        }
        else
        {
            //wpline = ViewFinder.viewFinder.rkVector;
            //rb.velocity = wpline * weapon.speed;
            //rb.AddForce(wpline * weapon.speed);
            transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(transform.right, wpline));
            transform.SetParent(null);
            //vLeft = new Vector3(0, 0, Vector3.Angle(transform.right, -wpline)) - Vector3.zero;
        }
    }

    void checkTypeWp()
    {
        switch (weaponType)
        {
            case WeaponType.Archer:
                transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(transform.right, rb.velocity.normalized)));
                break;
            case WeaponType.Bullet:
                transform.Rotate(new Vector3(0, 0, 360.0f - Vector3.Angle(transform.right, rb.velocity.normalized)));

                break;
            case WeaponType.Lazer:
                time -= Time.deltaTime;
                if(time < 0 && !tg)
                {
                    GameParameter.parameter._state = GameParameter.State.Bot;
                    Destroy(gameObject);
                }else if(time < 0 && tg)
                {
                    GameParameter.parameter._state = GameParameter.State.Ready;
                    Destroy(gameObject);
                }
                break;
            case WeaponType.RockType:
                transform.Rotate(Vector3.forward * weapon.rotareSpeed * Time.deltaTime);
                break;
        }
    }
	void Update ()
    {
        checkTypeWp();
        if(weaponType == WeaponType.Bullet)
        {
            
            if (transform.position.x > 5)
            {
                if (GameParameter.parameter.shot >= 3)
                {
                    GameParameter.parameter._state = GameParameter.State.Bot;
                }
                else
                {
                    GameParameter.parameter.shot++;
                }
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.x > 5)
            {
                GameParameter.parameter._state = GameParameter.State.Bot;
                Destroy(gameObject);
            }
        }
        
    }
    void makingBullet()
    {
        Vector3 wplineU;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (weaponType == WeaponType.Archer)
        {
            if (col.collider.tag == "Bot")
            {
                GameParameter.parameter._state = GameParameter.State.Ready;
                Instantiate(weapon.effect, transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                GameManager.gm.selectGround();
                GameManager.gm.makeCoin();
                Destroy(gameObject);
            }
            else if (col.collider.tag != "Bot")
            {
                GameParameter.parameter._state = GameParameter.State.Bot;
                GetComponent<Collider2D>().enabled = false;
                Instantiate(weapon.effect, transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                Destroy(gameObject);
            }
        }
        if (weaponType == WeaponType.Lazer)
        {
            if (col.collider.tag == "Bot")
            {
                GetComponent<Collider2D>().enabled = false;
                tg = true;
                GetComponent<Collider2D>().enabled = false;
                Instantiate(weapon.effect, col.transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                GameManager.gm.selectGround();
                GameManager.gm.makeCoin();
            }
            else if (col.collider.tag != "Bot")
            {
                GetComponent<Collider2D>().enabled = false;
                Instantiate(weapon.effect, transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                GameParameter.parameter._state = GameParameter.State.Bot;
                Destroy(gameObject);
            }
        }
        if (weaponType == WeaponType.Bullet)
        {
            if (GameParameter.parameter.bulletCol)
            {
                if(col.collider != null)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (col.collider.tag == "Bot")
                {
                    GameParameter.parameter.ShakeCamera();
                    col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                    Instantiate(weapon.effect, transform.position, Quaternion.identity);
                    GameParameter.parameter._state = GameParameter.State.Ready;
                    GameParameter.parameter.bulletCol = true;
                    GameManager.gm.selectGround();
                    GameManager.gm.makeCoin();
                    Destroy(gameObject);
                }
                else if (col.collider.tag != "Bot")
                {
                    GetComponent<Collider2D>().enabled = false;
                    Instantiate(weapon.effect, transform.position, Quaternion.identity);
                    GameParameter.parameter.ShakeCamera();
                    col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                    if (GameParameter.parameter.shot >= 3)
                    {
                        GameParameter.parameter._state = GameParameter.State.Bot;
                    }
                    else {
                        GameParameter.parameter.shot++;
                    }
                    Destroy(gameObject);
                }
            }
        }
        if (weaponType == WeaponType.RockType)
        {
            if (col.collider.tag == "Bot")
            {
                Instantiate(weapon.effect, transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                GameManager.gm.selectGround();
                GameParameter.parameter._state = GameParameter.State.Ready;
                GameManager.gm.makeCoin();
                Destroy(gameObject);
            }
            else if (col.collider.tag != "Bot")
            {
                GetComponent<Collider2D>().enabled = false;
                Instantiate(weapon.effect, transform.position, Quaternion.identity);
                GameParameter.parameter.ShakeCamera();
                col.transform.position = col.transform.position + new Vector3(Mathf.Sin(Time.fixedDeltaTime), 0.0f, 0.0f);
                GameParameter.parameter._state = GameParameter.State.Bot;
                Destroy(gameObject);
            }
        }
        
    }
}
