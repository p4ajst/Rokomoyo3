using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//即死トラップのスクリプト

public class DeathTrap : Trap {

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;
    GameObject microUSB;
    /// <summary>
    /// 例
    /// </summary>
    microUSB mUSB;
    GameObject key;
    Transform childKey;
    // Use this for initialization
    override protected void Start () {
        //基底クラスのStart関数
        base.Start();

        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");
        microUSB = GameObject.Find("microUSB");

        key = GameObject.Find("Key");

        childKey = key.transform.Find("Key");
        mUSB = microUSB.GetComponent<microUSB>();

    }

    // Update is called once per frame
    override protected void Update()
    {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true)
        {
            //プレイヤーの座標をスタートの座標にする
            player.transform.position = start.transform.position;

            ////鍵をアクティブにする
            //if (GameObject.Find("Key").transform.Find("Key") == null)
            //    GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);


            if(key == null)
            {
                childKey.gameObject.SetActive(true);
            }
        }

        ////マイクロUSBを確認しフラグが立っているのなら
        //if (microUSB.GetComponent<microUSB>() != null)
        //{
        //    if (microUSB.GetComponent<microUSB>().GetFlag())
        //    {
        //        //オブジェクトを消す
        //        gameObject.SetActive(false);
        //    }
        //}

        if(mUSB != null)
        {
            if(mUSB.GetFlag())
            {
                gameObject.SetActive(false);
            }
        }
    }
}
