using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

    public enum WeaponMode
    {
        LIGHTNING,
        FIRE,
        WATER,
        AIR,
        SUCTION,
        ICE
    }

    public GameObject FireBall;
    public GameObject WaterBall;
    public GameObject IceCone;
    public GameObject AirBall;
    public GameObject Lightning;
    public Transform ShootingPoint;

    WeaponMode _weaponMode;


    private KeyCode[] actionButtons = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        foreach(KeyCode button in actionButtons)
        {
            if (Input.GetKeyDown(button))
            {
                ChangeMode(button);
            }
        }
    }

    private void Shoot()
    {
        switch (_weaponMode)
        {
            case WeaponMode.WATER:
                GameObject newWaterball = Instantiate(WaterBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, Vector3.forward));
                newWaterball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                break;
            case WeaponMode.ICE:
                GameObject newIceCone = Instantiate(IceCone, ShootingPoint.position, Quaternion.FromToRotation(Vector3.up, ShootingPoint.forward));
                newIceCone.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                break;
            case WeaponMode.FIRE:
                GameObject newFireball = Instantiate(FireBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, Vector3.forward));
                newFireball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                break;
            case WeaponMode.LIGHTNING:
                RaycastHit hit;
                if (Physics.Raycast(ShootingPoint.position, ShootingPoint.transform.forward, out hit, 100f))
                {
                    Vector3 direction = (hit.point - ShootingPoint.position);
                    int distance = 2;
                    for (int i = 0; i < direction.magnitude; i += distance)
                    {
                        GameObject newLightning = Instantiate(Lightning, ShootingPoint.position + direction.normalized * i, Quaternion.FromToRotation(Vector3.up, ShootingPoint.forward));
                        Destroy(newLightning, 0.5f);

                    }
                }
                break;
            case WeaponMode.AIR:
                GameObject newAirball = Instantiate(AirBall, ShootingPoint.position, Quaternion.FromToRotation(Vector3.forward, Vector3.forward));
                newAirball.GetComponent<Rigidbody>().AddForce(ShootingPoint.transform.forward * 1000f);
                break;
            case WeaponMode.SUCTION:
                _weaponMode = WeaponMode.SUCTION;
                break;
        }
    }

    private void ChangeMode(KeyCode button)
    {
        switch (button)
        {
            case KeyCode.Alpha1:
                _weaponMode = WeaponMode.WATER;
                break;
            case KeyCode.Alpha2:
                _weaponMode = WeaponMode.ICE;
                break;
            case KeyCode.Alpha3:
                _weaponMode = WeaponMode.FIRE;
                break;
            case KeyCode.Alpha4:
                _weaponMode = WeaponMode.LIGHTNING;
                break;
            case KeyCode.Alpha5:
                _weaponMode = WeaponMode.AIR;
                break;
            case KeyCode.Alpha6:
                _weaponMode = WeaponMode.SUCTION;
                break;
        }
    }
}
