using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    List<GameObject> wood = new List<GameObject>();

    public void Electrocute()
    {
        if (wood.Count > 0)
        {
            for (int i = 0; i < wood.Count; i++)
            {
                wood[i].GetComponent<WoodScript>().Burn();
            }
            wood = new List<GameObject>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wood" && !wood.Contains(other.gameObject))
        {
            wood.Add(other.gameObject);
        }
    }
}
