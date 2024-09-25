using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    public bool fuckingLaunch;
    public float speed;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(fuckingLaunch)
            _rb.AddForce(Vector2.up * speed); 
    }
}
