using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject gb;
    public GameObject gb2;
    public GameObject cam;
    private GameObject canvas;
    bool canAct;
    public int type;

    void Start()
    {
        canAct = cam.GetComponent<ctrl>().canAct;
        canvas = GameObject.Find("Canvas");
    }

    void Update() {
        canAct = cam.GetComponent<ctrl>().canAct;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (canAct) {
            gb.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (canAct)
        {
            gb.SetActive(false);
        }
    }

    public void click() {
        if (canAct)
        {
            gb2.SetActive(true);
            cam.GetComponent<ctrl>().canAct = false;
            gb.SetActive(false);
            StartCoroutine(end());
            GetComponent<AudioSource>().Play();
        }

        if (type == 0) {
            StartCoroutine(next());
        }
        if (type == 1) {
            //预处理
            Application.Quit();
        }

    }

    IEnumerator end() {
        yield return new WaitForSecondsRealtime(1);
        canvas.GetComponent<Animator>().SetTrigger("end");
    }

    IEnumerator next() {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(1);
    }

}
