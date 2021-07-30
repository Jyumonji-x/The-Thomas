using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : Istate
{

    public Vector3 aim;// 当前确定的角色位置
    private float shootAnimeCost = 1f;
    public float timeCost =0.3f;//射击消耗时间
    private float shootTimer;
    private FSM manager;
    private Parameter parameter;
    public ShootState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void onEnter()
    {
        manager.canAttack = false;
        parameter.lineRenderer.enabled = false;
        shootTimer = 0f;
        aim = new Vector3(parameter.player.position.x, parameter.player.position.y, 0f);
        parameter.animator.SetTrigger("Shoot");
    }
    public void onUpdate()
    {
        if (shootAnimeCost > 0f)
        {
            shootAnimeCost -= Time.deltaTime;
            return;
        }
        if (shootTimer > 0.4f)
        {
            manager.canAttack = false;
            manager.TransitionState(StateType.Idle);
        }
        if (manager.canAttack) {

            float x = ((timeCost - shootTimer) * parameter.rb.position.x + (shootTimer) * aim.x) / timeCost;
            float y = ((timeCost - shootTimer) * parameter.rb.position.y + (shootTimer) * aim.y) / timeCost;
            Vector2 startPoint = new Vector2(parameter.rb.position.x, parameter.rb.position.y);
            Vector2 endPoint = new Vector2(x, y);
            parameter.lineRenderer.enabled = true;
            parameter.lineRenderer.SetPosition(0, startPoint);
            parameter.lineRenderer.SetPosition(1, endPoint);
            Vector2 direction = endPoint - startPoint;
            RaycastHit2D hit;
            int layerMask = LayerMask.NameToLayer("Player");
            hit = Physics2D.Raycast(parameter.rb.position, direction, (endPoint - startPoint).magnitude, 1 << layerMask);//player的遮罩层
            if (hit.collider != null && hit.collider.name == "TrainEngine")
            {
                parameter.playerDeath = true;
            }
            shootTimer += Time.deltaTime;
        }

    }
    public void onExit()
    {
        manager.canAttack = false;
        shootTimer = 0f;
        parameter.lineRenderer.enabled = false;
        shootAnimeCost = 1f;
    }

}
