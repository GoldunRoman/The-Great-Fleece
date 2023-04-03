using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        if(!GameObject.Find("Darren_3D").TryGetComponent(out _animator))
        {
            Debug.Log("Error! Animator is NULL!");
        }
    }
    public void PlayWalkAnimation(bool isWalking)
    {
        if (isWalking)
            _animator.SetBool("isWalking", true);
        else
            _animator.SetBool("isWalking", false);
    }

    public void PlayCoinTossAnimation()
    {
        _animator.SetTrigger("coinToss");
    }
}
