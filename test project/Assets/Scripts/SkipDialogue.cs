using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.active)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameObject.SetActive(false);
            }
        }
	}
}
