using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodScript : MonoBehaviour
{
    [HideInInspector] public bool IsBurning;
    private WoodScript _wood;

    private List<GameObject> _colliders = new List<GameObject>();
    private List<WoodScript> _toBurn = new List<WoodScript>();

    // Update is called once per frame
    public void Burn()
    {
        if (!IsBurning)
        {
            IsBurning = true;
            transform.GetChild(0).gameObject.SetActive(true);
            foreach (GameObject item in _colliders)
            {
                Debug.Log(item.name);
                if (item == null)
                {
                    continue;
                }
                if (item.tag == "Wood" && !item.GetComponent<WoodScript>().IsBurning)
                {
                    _wood = item.GetComponent<WoodScript>();
                    _toBurn.Add(_wood);
                }
            }
            Invoke("burnOthers", 2f);
            Destroy(gameObject, 3f);
        }
    }

    private void burnOthers()
    {
        foreach (WoodScript item in _toBurn)
        {
            item.Burn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wood" && !_colliders.Contains(other.gameObject))
        {
            _colliders.Add(other.gameObject);
        }
    }
}