using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform _playerPosition;
    [SerializeField]
    private Transform _startCameraPos;

    private void Start()
    {
        transform.SetPositionAndRotation(_startCameraPos.position, _startCameraPos.rotation);
    }

    void Update()
    {
        transform.LookAt(_playerPosition.position); 
    }
}
