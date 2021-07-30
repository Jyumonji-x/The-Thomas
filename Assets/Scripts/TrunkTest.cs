using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkTest : MonoBehaviour
{
    public GameObject following;
    GameObject back;
    public float distance = 0.8f;
    private Vector2 pos = Vector2.one;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in following.transform)
        {
            if (child.gameObject.name == "back")
            {
                back = child.gameObject;
            }
        }
        distance = Vector2.Distance(transform.position, back.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, back.transform.position);
        Vector2 dir = back.transform.position - transform.position;
        if (dis > distance) {
            float ratio = (dis - distance) / distance;
            transform.position += ratio * (back.transform.position-transform.position);
        }
    }
}
