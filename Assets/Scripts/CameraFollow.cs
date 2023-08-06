using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - player.position;
        
    }

    private void Update()
    {
        Vector3 targetPos = _offset + player.position;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}