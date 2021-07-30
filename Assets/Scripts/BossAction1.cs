using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAction1 : MonoBehaviour
{
    public GameObject trunkPrefeb;//砸地的物体
    public int count;//砸地次数
    private bool clockwise;//砸地方向，顺逆时针
    private Vector3 head;//boss头部的位置，从该位置开始向两边砸
    private bool raising;//前摇
    private Transform trunkTransform;
    private Rigidbody2D trunkRigid;

    // Start is called before the first frame update
    void Start()
    {
        head = transform.position;
        head.y += 5;
        clockwise = true;
        raising = true;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //举起来的动作

        //if (raising)
        //{
        //    trunkTransform.position = trunkTransform.position + new Vector3(0, 0.1f);
        //    if (Mathf.Abs(trunkTransform.position.y - head.y) <= 0.1 || trunkTransform.position.y > head.y)
        //    {
        //        raising = false;
        //    }

        //    trunkRigid.velocity.Set()
        //}
        if (!raising)
        {

        }

    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1.0f); // 停止执行1秒

        //一秒后初始化实例
        GameObject trunk = Instantiate(trunkPrefeb, transform.position, transform.rotation);
        trunkTransform = trunk.transform;
        trunkRigid = trunk.GetComponent<Rigidbody2D>();
        raising = false;
    }


}
