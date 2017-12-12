using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Inverted : MonoBehaviour {

    public Image nverted;
    public Image invertednote1;
    public Image invertednote2;
    bool flag;
    

    // Use this for initialization 
    void Start () {
        flag = false;
        nverted.color = new Color(0.0f, 0f, 0f, 0.0f);
        invertednote1.color = new Color(255f, 255f, 255f, 0.0f);
        invertednote2.color = new Color(0.0f, 0f, 255f, 0.0f);

    }

    // Update is called once per frame
    void Update () {
       if(Input.GetKey(KeyCode.Space))
        {
            invertedOn();
        }
        if (flag == true)
        {
            if (invertednote2.transform.position.x <= 250)
            {
                invertednote1.transform.position += new Vector3(-1, 0, 0);
                invertednote2.transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                invertedOff();
            }
        }
	}

    public void invertedOff()
    {
        flag = false;
        invertednote1.transform.position += new Vector3(150, 0, 0);
        invertednote2.transform.position += new Vector3(-150, 0, 0);
        nverted.color = new Color(0.0f, 0f, 0f, 0.0f);
        invertednote1.color = new Color(255f, 255f, 255f, 0.0f);
        invertednote2.color = new Color(0.0f, 0f, 255f, 0.0f);

    }
    public void invertedOn()
    {
        flag = true;
        nverted.color = new Color(0.0f, 0f, 0f, 255f);
        invertednote1.color = new Color(255f, 255f, 255f, 255f);
        invertednote2.color = new Color(0.0f, 0f, 255f, 255f);

    }
}
