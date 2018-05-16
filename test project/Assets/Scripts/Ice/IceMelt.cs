using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour
{
    [Tooltip("If you check this, the ice will automaticly melt in [MeltTime] seconds.")]
    public bool AutoMelt = true;

    [Tooltip("The time it takes for the ice to melt, in seconds")]
    public float MeltTime = 2;
    private float _melt;
    private float _scale = 1;
    private float _t = 0;
    private Vector3 _initalScale;

    [Tooltip("The scale it will smoothly scale to while melting")]
    [SerializeField] private float _minScale = 0.25f;


    private void Start()
    {
        _initalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (AutoMelt)
        {
            _t += (1 / MeltTime) * Time.deltaTime;
            _scale = Mathf.Lerp(1, _minScale, _t);

            transform.localScale = _initalScale * _scale;

            _melt += Time.deltaTime;

            if (_melt >= MeltTime)
            {
                Destroy(gameObject);
            }
        }
    }
}