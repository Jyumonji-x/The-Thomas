using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trunkAnime : MonoBehaviour
{
    public Animator animate;
    public Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animate.SetFloat("Rotation", trans.rotation.eulerAngles.z);
    }
}
