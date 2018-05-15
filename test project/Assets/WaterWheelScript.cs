using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWheelScript : MonoBehaviour {

    [SerializeField] private float maxSpeed = 2f;       // Maximum animation speed
    [SerializeField] private float decayRate = 0.001f;  // Power removed per frame
    [SerializeField] private float addPower = 0.2f;     // Power added by water shot

    [SerializeField] private GameObject SlideDoor;

    private float _spinPower = 0f;      // Current spin power
    private Animator _spinAnimation;    // The animator
    private SlideDoorScript _slideDoorScript;

	// Use this for initialization
	void Start () {
        _spinAnimation = GetComponent<Animator>();
        _slideDoorScript = SlideDoor.GetComponent<SlideDoorScript>();
	}
	
	// Update is called once per frame
	void Update () {
        // decay the power over frames
		if(_spinPower > 0)
        {
            _spinPower -= decayRate;
            if (_spinPower < 0)
                _spinPower = 0f;
        }
        _spinAnimation.speed = _spinPower;//SpinPower;
        _slideDoorScript.SetDoorPosition(transform.position ,4f / maxSpeed * _spinPower);
        
    }

    public void AddPower()
    {
        // add power
        _spinPower += addPower;
        if (_spinPower > maxSpeed)
            _spinPower = maxSpeed;
    }
}
