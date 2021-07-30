using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : Istate
{
    private FSM manager;
    private Parameter parameter;
    private float timer;//数秒后shoot一次
    
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        timer = 0f;
    }
    public void onUpdate()
    {
        timer += Time.deltaTime;
        float x = parameter.player.position.x - parameter.rb.position.x;
        float y = parameter.player.position.y - parameter.rb.position.y;
        float length = Mathf.Sqrt(x * x + y * y);
        if (timer > parameter.timeCost&& length < parameter.maxDistance)
        {
            manager.TransitionState(StateType.Shoot);
        }

        if (length < parameter.minDistance)
        {
            manager.TransitionState(StateType.Knock);
        }
        if (length < parameter.maxDistance)
        {
            parameter.rb.velocity = new Vector2(x / length * parameter.chaseSpeed * Time.deltaTime, y / length * parameter.chaseSpeed * Time.deltaTime);
        }
        else
        {
            parameter.rb.velocity = new Vector2(0f, 0f);
        }
        
    }
    public  void onExit()
    {
        parameter.rb.velocity = new Vector2(0f, 0f);
        timer = 0f;
    }

}
