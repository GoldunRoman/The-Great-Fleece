using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEyes : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;
    [SerializeField]
    private GameObject _guards;

    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            _guards.SetActive(false);
            player.gameObject.SetActive(false);
            _gameOverCutscene.SetActive(true);
        }
    }
}
