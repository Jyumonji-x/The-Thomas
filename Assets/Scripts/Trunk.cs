using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : MonoBehaviour
{
    private Rigidbody2D rb;
    public float multiple = 0.0f;
    public DistanceJoint2D j;
    public GameObject fore;
    public float distance = 0.4f;
    private int num;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        j = GetComponent<DistanceJoint2D>();
        fore = j.connectedBody.gameObject;
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "back")
            {
                j.anchor = child.localPosition;
            }
        }
        j.distance = distance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 force = -multiple * rb.velocity;
        rb.AddForce(force);
    }
}
