using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _newCameraPos;
    [SerializeField]
    private GameObject _virtualCamera;
    private void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.CompareTag("Player"))
        {
            Camera.main.transform.SetPositionAndRotation(_newCameraPos.position, _newCameraPos.rotation);
        }
    }
}
