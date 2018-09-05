using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRender : MonoBehaviour
{
    public float speed;
    bool created;
    public bool isCloud;
   
    void Update()
    {
        if (isCloud)
        {
            this.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            if (this.transform.position.x <= 0 && !created)
            {
                GameObject go = Instantiate(this.gameObject, new Vector3(40, this.transform.position.y, 0), Quaternion.identity);
                go.name = this.gameObject.name;
                created = true;
            }
            if (this.transform.position.x < -40)
            {
                Destroy(gameObject);
            }
        }
        else if (GameParameter.parameter._state == GameParameter.State.Ready)
        {
            this.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            if (this.transform.position.x <= 0 && !created)
            {
                GameObject go = Instantiate(this.gameObject, new Vector3(40, this.transform.position.y, 0), Quaternion.identity);
                go.name = this.gameObject.name;
                created = true;
            }
            if (this.transform.position.x < -40)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
