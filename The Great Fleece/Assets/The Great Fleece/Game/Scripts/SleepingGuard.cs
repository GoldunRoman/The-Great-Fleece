using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingGuard : MonoBehaviour
{
    [SerializeField]
    private GameObject _keyCardCutscene;
    [SerializeField]
    private GameObject _sleepingGuard;

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            if(_keyCardCutscene != null)
                _keyCardCutscene.SetActive(true);

            GameManager.Instance.HasCard = true;

            Debug.Log(GameManager.Instance.HasCard);
        }
    }
}
