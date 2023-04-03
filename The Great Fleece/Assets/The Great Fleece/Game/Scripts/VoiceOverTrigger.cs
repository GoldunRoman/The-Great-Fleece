using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip _VOsound;
    private bool _doNotPlayAgain = false;


    void Start()
    {       
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && _doNotPlayAgain == false)
        {
            AudioManager.Instance.PlayVoiceOverSound(_VOsound);
            _doNotPlayAgain = true;
        }
    }

}
