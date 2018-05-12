using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation(bool pActive)
    {
        if(!pActive)
        {
            _animator.Play("pressed");
        }
    }
}
