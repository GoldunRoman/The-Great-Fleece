using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimations _playerAnims;
    private NavMeshAgent _agent;
    private Vector3 _target;

    [SerializeField]
    private GameObject _coinPrefab;
    private bool _hasCoin = true;

    [SerializeField]
    private List<GameObject> _guards;

    void Start()
    {
        if(!TryGetComponent(out _agent))
        {
            Debug.Log("NavMeshAgent is NULL!");
        }

        if (!TryGetComponent(out _playerAnims))
        {
            Debug.Log("PlayerAnimations is NULL!");
        }
    }

    void Update()
    {
        MoveToPoint();
        CoinDistraction();
        
    }

    private void MoveToPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
                _playerAnims.PlayWalkAnimation(true);
                _target = hit.point;
            }
        }

        float distance = Vector3.Distance(transform.position, _target);

        if(distance < 2f)
        {
            _playerAnims.PlayWalkAnimation(false);
        }
    }

    private void CoinDistraction()
    {
        if (Input.GetMouseButtonDown(1) && _hasCoin == true && _coinPrefab != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                _hasCoin = false;
                Instantiate(_coinPrefab, hit.point, Quaternion.identity);
                AudioManager.Instance.PlayCoinSound();
                _playerAnims.PlayCoinTossAnimation();
                SendAIToCoinSpot(hit.point);  
            }
        }
    }

    private void SendAIToCoinSpot(Vector3 coinPosition)
    {
        for (int i = 0; i < _guards.Count; i++)
        {
            _guards[i].GetComponent<GuardAI>().SendAIToCoin(coinPosition);           
        }
    }
}
