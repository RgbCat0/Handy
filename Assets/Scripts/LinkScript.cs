using UnityEngine;

public class LinkScript : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement script;

    private void OnCollisionEnter2D(Collision2D other)
    {
        script.OnCollisionEnter2D(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        script.OnCollisionExit2D(other);
    }
}
