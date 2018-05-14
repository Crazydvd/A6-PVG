using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    List<GameObject> wood = new List<GameObject>();

    public void Electrocute()
    {
        Debug.Log(wood.Count);
        foreach(GameObject woodBlock in wood)
        {
            woodBlock.GetComponent<WoodScript>().Burn();
            wood.Remove(woodBlock);
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
