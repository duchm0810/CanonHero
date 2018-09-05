using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParSc : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("des", 01f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void des()
    {
        Destroy(this.gameObject);
    }
}
