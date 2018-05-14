using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    public void Burn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Destroy(gameObject, 3f);
    }
}
