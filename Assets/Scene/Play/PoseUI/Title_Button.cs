using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_Button : MonoBehaviour
{
    // シーン変更
    SceneChanger sceneChanger = null;


    public void OnButton()
    {
        sceneChanger.ExecuteCoroutine("Title");
        Stage.SetStageNum(1);
        CharacterManager.SetBattery(1.0f);
    }

    // Use this for initialization
    void Start ()
    {
        GameObject scene = GameObject.Find("FadePanel");
        // コンポーネントを取得
        sceneChanger = scene.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
