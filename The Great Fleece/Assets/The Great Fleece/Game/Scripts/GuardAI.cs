using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{ 
    [SerializeField]
    private List<Transform> _wayPoints;
    [SerializeField]
    private GuardAnimationsManager _animations;
    private NavMeshAgent _agent;
    private int _currentTarget;
    private bool _reverce = false;
    private bool _targetReached;

    private bool _isTriggeredByCoin = false;
    private Vector3 _coinPosition;



    private void Start()
    {
        if (!TryGetComponent<NavMeshAgent>(out _agent))
            Debug.Log("Error! _agent = NULL");

        if (!TryGetComponent<GuardAnimationsManager>(out _animations))
            Debug.Log("Error! _animations is NULL");
    }

    private void Update()
    {
        if(_isTriggeredByCoin == true)
        {
            GoToCoin();
        }

        Patrol();
    }

    private void Patrol()
    {
        
        if(_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null && _isTriggeredByCoin == false)
        {
            _agent.SetDestination(_wayPoints[_currentTarget].position);
            

            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);

            //reverce system
            //if at first elem of list reverce = false. Guard goes ahead
            if(_currentTarget == 0)
            {
                _reverce = false;
            }
            //if at last elem list reverce = true. Guard goes back
            else if(_currentTarget == _wayPoints.Count - 1)
            {
                _reverce = true;
            }           

            //if only one waypoint return
            if(_wayPoints.Count < 2)
            {
                return;
            }

            //set target position depending from reverce
            if(distance < 1f && _targetReached == false && _wayPoints.Count > 1)
            {
                _targetReached = true;
                StartCoroutine(WaitBeforeMoving());

                if(_reverce == false)
                {
                    _currentTarget++;
                }
                else if(_reverce == true)
                {
                    _currentTarget--;
                }
            }           
        }
    }


    private void GoToCoin()
    {
        _agent.SetDestination(_coinPosition);

        float distance = Vector3.Distance(transform.position, _coinPosition);
        if(distance < 3f)
        {
            StartCoroutine(CoinTriggerRoutine());
        }
    }

    IEnumerator WaitBeforeMoving()
    {   
        //Guard stops only at first and last _wayPoint
        if(_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1)
        {
            float delay = UnityEngine.Random.Range(3f, 5f);
            _agent.speed = 0f;
            _animations.PlayWalkAnimation(false);
            yield return new WaitForSeconds(delay);
        }

        _targetReached = false;
        _agent.speed = 3.3f;
        _animations.PlayWalkAnimation(true);
    }

    IEnumerator CoinTriggerRoutine()
    {
        //Guard stops only at first and last _wayPoint
        if (_isTriggeredByCoin)
        {
            float delay = UnityEngine.Random.Range(3f, 5f);
            _agent.speed = 0f;
            _animations.PlayWalkAnimation(false);
            yield return new WaitForSeconds(delay);
        }

        _isTriggeredByCoin = false;
        _targetReached = false;
        _agent.speed = 3.3f;
        _animations.PlayWalkAnimation(true);
    }

    public void SendAIToCoin(Vector3 coinPosition)
    {
        _coinPosition = coinPosition;
        _isTriggeredByCoin = true;
    }

}
