using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public string targetTag = "Grabable";
    public float detectionRange = 1.5f;

    private GameObject grabbedObject = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                AttemptGrab();
            }
            else
            {
                ReleaseObject();
            }
        }
    }

    private void AttemptGrab()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject targetObject in targetObjects)
        {
            float distance = Vector3.Distance(player.transform.position, targetObject.transform.position);
            if (distance <= detectionRange)
            {
                Debug.Log("Player grabbed: " + targetObject.name);
                grabbedObject = targetObject;
                grabbedObject.transform.SetParent(player.transform);
                if (grabbedObject.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }
                }
                break;
            }
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObject != null)
        {
            Debug.Log("Player released: " + grabbedObject.name);

            grabbedObject.transform.SetParent(null);
            if (grabbedObject.GetComponent<Rigidbody2D>() != null)
            {
                Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }
            }
            grabbedObject = null;
        }
    }
}
