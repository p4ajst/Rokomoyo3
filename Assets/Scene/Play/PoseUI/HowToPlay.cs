using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {

    bool flag;
    public GameObject HowTo;
    public void OnClick()
    {
        flag = true;
        HowTo.SetActive(true);
    }
    public void OnClick1()
    {
        flag = true;
        HowTo.SetActive(false);
    }
    // Use this for initialization
    void Start () {
        flag = false;
        HowTo.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (flag == true)
        {
        }
    }
}
