using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockState : Istate
{
    //private bool clockwise;//砸地方向，顺逆时针
    //private Vector3 head;//boss头部的位置，从该位置开始向两边砸
    //    private bool raising;//前摇
    //    private Transform trunkTransform;
    //    private Rigidbody2D trunkRigid;
    //    private FSM manager;
    //    private Parameter parameter;
    //    public Transform aim;//移动目标
    //    public KnockState(FSM manager)
    //    {
    //        this.manager = manager;
    //        this.parameter = manager.parameter;
    //    }
    //    public void onEnter()
    //    {
    //  trunkRigid.position = new Vector2(parameter.player.position.x, parameter.player.position.y);
    // head = parameter.rb.position;
    //  head.y += 5;
    //  clockwise = true;
    //        aim = parameter.player.transform;
    //        raising = true;
    //        manager.knockStartCoroutine(parameter.trunkPrefeb, raising);
    //    }
    //   public void onUpdate()
    //   {
    //举起来的动作
    //       if (raising)
    //       {
    //trunkTransform.position = trunkTransform.position + new Vector3(0, 0.1f);
    //if (Mathf.Abs(trunkTransform.position.y - head.y) <= 0.1 || trunkTransform.position.y > head.y)
    //{
    //    raising = false;
    //}
    //trunkRigid.velocity.Set(0,0);
    //       if (!raising)
    //   {

    //     }

    //    }
    //  public void onExit()
    //    {
    //       raising = false;
    //    }

    public Vector3 aim;// 当前确定的角色位置
    public float timeCost = 0.2f;//射击消耗时间
    private float knockTimer;
    private FSM manager;
    private Parameter parameter;
    private float knockAnimeCost = 0.5f;
    public KnockState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        Debug.Log("knock:");
        aim = new Vector2(parameter.player.position.x, parameter.player.position.y);
        parameter.trunkPrefeb.SetActive(false);
        knockTimer = 0f;
        parameter.animator.SetTrigger("Knock");
    }

    public void onUpdate()
    {
        if (knockAnimeCost > 0f)
        {
            knockAnimeCost -= Time.deltaTime;
            return;
        }

        if (knockTimer > 0.3f)
        {
            manager.canAttack = false;
            manager.TransitionState(StateType.Shoot);
        }
        if (manager.canAttack) {
            parameter.trunkPrefeb.SetActive(true);
            float x = ((timeCost - knockTimer) * parameter.rb.position.x + (knockTimer) * aim.x) / timeCost;
            float y = ((timeCost - knockTimer) * parameter.rb.position.y + (knockTimer) * aim.y) / timeCost;
            parameter.trunkPrefeb.transform.position = new Vector2(x, y);
            knockTimer += Time.deltaTime;
        }


    }
    public void onExit()
    {
        manager.canAttack = false;
        parameter.trunkPrefeb.SetActive(false);
        knockTimer = 0f;
        knockAnimeCost = 0.5f;
    }

}
