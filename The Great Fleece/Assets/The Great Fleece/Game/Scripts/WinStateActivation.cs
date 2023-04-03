using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinStateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutscenes;
    [SerializeField]
    private GameObject _winLevelScene;
    [SerializeField]
    private GameObject _doNotHaveACardMessage;

    private void Start()
    {
        if (_winLevelScene == null)
            Debug.Log("_winLevelScene in NULL!");

        if (_doNotHaveACardMessage == null)
            Debug.Log("_doNotHaveACardMessage in NULL!");

        if(_cutscenes == null)
        {
            Debug.Log("_cutscenes is NULL!");
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.HasCard == true)
            {
                player.gameObject.SetActive(false);
                _cutscenes.SetActive(true);
                _winLevelScene.SetActive(true);
            }

            else if(GameManager.Instance.HasCard == false)
            {
                _doNotHaveACardMessage.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            if(GameManager.Instance.HasCard == false)
            {
                _doNotHaveACardMessage.SetActive(false);
            }
        }
    }
}
