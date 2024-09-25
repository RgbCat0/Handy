using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private Quaternion desiredRotation;
    public float smoothSpeed = 14f;
    private float _smoothSpeed;

    private void FixedUpdate()
    {
        if (!target)
            return;

        if (Vector2.Distance(transform.position, target.position) > 15)
            ForceTeleportToTarget();

        _smoothSpeed = smoothSpeed + Vector2.Distance(transform.position, target.position);
        var smoothedPosition = Vector3.Lerp(
            transform.position,
            target.position,
            _smoothSpeed * Time.deltaTime
        );
        smoothedPosition += new Vector3(0, 0, -10);

        transform.position = smoothedPosition;
    }

    public void ForceTeleportToTarget() => transform.position = target.position;
}
