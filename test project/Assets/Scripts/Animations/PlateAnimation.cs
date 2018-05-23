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
        if (Time.timeScale == 0)
        {
            return;
        }

        if (!pActive)
        {
            _animator.Play("unpressed"); 
        }
        else
        {
            _animator.Play("pressed");
        }
    }
}
