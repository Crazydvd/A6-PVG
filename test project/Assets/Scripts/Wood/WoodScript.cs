using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    [HideInInspector] public bool IsBurning;
    private WoodScript _wood;

    private List<GameObject> _colliders = new List<GameObject>();

    // Update is called once per frame
    public void Burn()
    {
        if (!IsBurning)
        {
            IsBurning = true;
            transform.GetChild(0).gameObject.SetActive(true);
            foreach (GameObject item in _colliders)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.tag == "Wood" && !item.GetComponent<WoodScript>().IsBurning)
                {
                    _wood = item.GetComponent<WoodScript>();
                    Invoke("burnOthers", 2);
                }
            }
            Destroy(gameObject, 3f);
        }
    }

    private void burnOthers()
    {
        _wood.Burn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wood" && !_colliders.Contains(other.gameObject))
        {
            _colliders.Add(other.gameObject);
        }
    }
}