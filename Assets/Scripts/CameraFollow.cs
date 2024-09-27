using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 14f;
    public float teleportDistance;
    private float _smoothSpeed;

    private void FixedUpdate()
    {
        if (!target)
            return;

        if (Vector2.Distance(transform.position, target.position) > teleportDistance)
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
