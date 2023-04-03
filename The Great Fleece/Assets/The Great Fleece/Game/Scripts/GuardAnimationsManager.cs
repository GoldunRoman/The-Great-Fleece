using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimationsManager : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        if (!TryGetComponent(out _animator))
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
}
