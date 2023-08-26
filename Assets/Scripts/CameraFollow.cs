using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;


    private Vector3 currentVelocity; //lưu trữ vận tốc
    public Vector3 offset; // xác định độ lệnh từ máy ảnh đến người chơi
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset; //
        if(targetPosition.sqrMagnitude != 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);

        }    
    }
}

