using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;
    [SerializeField]
    private List<GameObject> _playerAndGuards;
    [SerializeField]
    private Color _redColor;
    [SerializeField]
    private Animator _animator;


    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_TintColor", _redColor);

            //disable guards and player
            for (int i = 0; i < _playerAndGuards.Count; i++)
            {
                _playerAndGuards[i].SetActive(false);   
            }

            _animator = GetComponentInParent<Animator>();
            _animator.enabled = false;

            StartCoroutine(AlertRoutine());
        }

        

        IEnumerator AlertRoutine()
        {
            yield return new WaitForSeconds(0.5f);
            _gameOverCutscene.SetActive(true);
        }

    }
}
