using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightA : MonoBehaviour
{
    float myTime = 0;
    bool type = true;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myTime += Time.deltaTime;
        if (myTime >= 2 && type) {
            target.SetActive(false);
            type = !type;
            myTime = 0;
        }
        if (myTime >= 0.7 && !type) {
            target.SetActive(true);
            type = !type;
            myTime = 0;
        }
    }
}
