using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtnk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player = GameObject.FindGameObjectWithTag("player");
    public GameObject following;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getOut() { 
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "Boss") {
            getOut();
            following.GetComponent<Turtnk>().cutOff();
        }
    }
    public void cutOff() { 
    }
}
