using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(bool pActive)
    {
        if (pActive)
        {
            _animator.Play("Lever_toActive");
            Debug.Log(_animator.playbackTime);
            _animator.speed = 1;
        }
        else
        {
            _animator.Play("Lever_toDeactive");
            //_animator.speed = -1;
        }
    }
}