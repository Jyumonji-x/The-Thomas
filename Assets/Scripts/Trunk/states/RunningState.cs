using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : Istate
{
    TrunkStateMachine tm;

    public RunningState(TrunkStateMachine tm) {
        this.tm = tm;
    }

    public void onEnter() {
        //tm.dj.enabled = true ;
        tm.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        tm.rb.mass = tm.magicNumber / Mathf.Pow(2, tm.num);
    }

    public void onExit() {
    }

    public void onUpdate() {
        Vector2 force = -tm.multiple * tm.rb.velocity;
        tm.rb.AddForce(force);
    }
    
}
