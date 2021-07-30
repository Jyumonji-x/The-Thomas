using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoppingState : Istate
{
    TrunkStateMachine tm;

    public StoppingState(TrunkStateMachine tm)
    {
        this.tm = tm;
        tm.rb.velocity = new Vector2(0, 0);
    }

    public void onEnter()
    {
        // todo 关闭shader 、 修改贴图
        tm.dj.enabled = false;
        tm.rb.velocity = new Vector2(0, 0);
        tm.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void onExit()
    {
    }

    public void onUpdate()
    {
        tm.rb.velocity = (tm.player.transform.position - tm.transform.position).normalized * 9;
    }

}
