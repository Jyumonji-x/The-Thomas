using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [Header("target")]
    public GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag.ToString() == "Player" && !target.activeSelf)
        {
            triggerOn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag.ToString() == "Player" && target.activeSelf)
        {
            triggerOff();
        }
    }


    protected virtual void triggerOn()
    {
        target.SetActive(true);
    }

    protected virtual void triggerOff()
    {
        target.SetActive(false);
    }

}
