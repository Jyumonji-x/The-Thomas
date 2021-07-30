using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBack : MonoBehaviour
{
    private Rigidbody2D rb;
    public float multiple;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = -multiple * rb.velocity;
        rb.AddForce(force);
    }
}
