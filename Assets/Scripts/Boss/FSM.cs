using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StateType
{
    Idle,Shoot,Knock
}

[Serializable]
public class Parameter
{
    public float maxDistance;
    public GameObject trunkPrefeb;//砸地的物体
//    public int count;//砸地次数
    public bool playerDeath = false;//玩家死亡
    public LineRenderer lineRenderer;//射击用的射线
    public Rigidbody2D rb;
    public Transform player;//获取玩家位置
    public int health;//未使用，boss血量
    public float chaseSpeed;//移动速度
    public float idleTime;//每次idle时间
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Animator animator;
    public float timeCost = 3.0f; //idle状态维持几秒
    public float minDistance;//最短距离，小于距离后开始砸
}
public class FSM : MonoBehaviour
{
    public Parameter parameter;
    public bool IsHurt;
    private Istate currentState;
    private Dictionary<StateType, Istate> states = new Dictionary<StateType, Istate>();
    public bool canAttack;
    public GameObject A;
    public GameObject B;
    private Coroutine hurting;
    // Start is called before the first frame update
    void Start()
    {
        canAttack = false;
        parameter.trunkPrefeb.SetActive(false);
        parameter.lineRenderer.enabled = false;
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Shoot, new ShootState(this));
        states.Add(StateType.Knock, new KnockState(this));

        parameter.animator = GetComponent<Animator>();
        TransitionState(StateType.Idle);

    }

    // Update is called once per frame
    void Update()
    {
        currentState.onUpdate();
        if (IsHurt)
        {
            IsHurt = false;
            getHurt();
        }
        if (parameter.playerDeath) {
            parameter.player.GetComponent<TrainEngineController>().isDie = true;
        }
    }

    public void TransitionState(StateType type)
    {
        if(currentState != null)
        {
            currentState.onExit();
        }
        currentState = states[type];
        currentState.onEnter();
    }
 //   public void knockStartCoroutine(GameObject trunk, bool raising)
 //   {
//        StartCoroutine(knockTimer(trunk,raising));
//    }
//    public IEnumerator knockTimer(GameObject trunk, bool raising)
//    {
//        yield return new WaitForSeconds(1.0f); // 停止执行1秒
        //一秒后初始化实例
//        trunk = Instantiate(parameter.trunkPrefeb, transform.position, transform.rotation);
//        raising = true;
//        StartCoroutine(stopKnockTimer(trunk, raising));
//    }
//    public IEnumerator stopKnockTimer(GameObject trunk, bool raising)
//    {
//        yield return new WaitForSeconds(2.0f); // 停止执行2秒
//        Destroy(trunk);
//        raising = false;
//        TransitionState(StateType.Idle);
//    }
     public void getHurt()
    {
        parameter.health -= 1;
   
        if (parameter.health <= 0)
        {
            //boss死亡，游戏结束
            parameter.animator.SetTrigger("die");
            A.SetActive(true);
            B.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
            enabled = false;
            //parameter.animator.SetTrigger("die");
        }
        else
        {
            if (hurting != null)
            {
                StopCoroutine(hurting);
            }

            hurting = StartCoroutine(HurtFlash());
        }

      
    }

    private IEnumerator HurtFlash()
    {
        Material material = GetComponent<SpriteRenderer>().material;
        float coefficient = 1f;
        float maxAlpha = 1f;
        float value = maxAlpha / coefficient;
         material.SetFloat("_Alpha", value);
        yield return null;
        while (material.GetFloat("_Alpha") > 0)
        {
            coefficient += 0.07f;
            value = maxAlpha / coefficient;
            value = value < 0.02 ? 0 : value;
            material.SetFloat("_Alpha",  value);
            yield return null;
        }
        hurting = null;
    }

    public void startAttack() {
        canAttack = true;
    }



}
