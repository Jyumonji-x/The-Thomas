using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform curPosition;//移动目标
    public Transform aim;//移动目标
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = aim.position.x - curPosition.position.x;
        float y = aim.position.y - curPosition.position.y;
        float distance = Mathf.Sqrt(x * x + y * y);
        rb.velocity = new Vector2(speed*x/distance, speed * y/distance);
    }
}
