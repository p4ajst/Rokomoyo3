using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//即死トラップのスクリプト

public class DeathTrap : Trap {

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;
    //GameObject microUSB;

    /// <summary>
    /// オブジェクトの配列
    /// </summary>
    GameObject[] objs = null;
    /// <summary>
    /// 音符のList構造の配列
    /// </summary>
    List<Notes> notes = new List<Notes>();

    ///// <summary>
    ///// 例
    ///// </summary>
    //microUSB mUSB;
    //GameObject key;
    //Transform childKey;
    // Use this for initialization
    override protected void Start () {
        //基底クラスのStart関数
        base.Start();

        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");
        //microUSB = GameObject.Find("microUSB");

        // 指定したタグで設定されたオブジェクトを探す
        objs = GameObject.FindGameObjectsWithTag("Notes");
        // 探したオブジェクト分foreach構文を回す
        foreach (GameObject obj in objs)
        {
            // Notesのコンポーネントを取得
            Notes n = obj.GetComponent<Notes>();
            notes.Add(n);
        }


        //key = GameObject.Find("Key");

        //childKey = key.transform.Find("Key").transform;
        //mUSB = microUSB.GetComponent<microUSB>();

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

            //ステレオプラグ踏んでたなら
            if (StereoPlug.noteFripFlag)
            {
                foreach (Notes note in notes)
                {
                    //音符の種類を変える処理
                    note.FlipNote();
                    StereoPlug.noteFripFlag = false;
                }
            }

            //鍵をアクティブにする
            //if (GameObject.Find("Key").transform.Find("Key") == null)
                GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);


            //if(key == null)
            //{
            //    childKey.gameObject.SetActive(true);
            //}
        }

        //マイクロUSBを確認しフラグが立っているのなら
        //if (microUSB.GetComponent<microUSB>() != null)
        {
            //if (microUSB.GetComponent<microUSB>().GetFlag())
            if(microUSB.GetFlag())
            {
                //オブジェクトを消す
                gameObject.SetActive(false);
            }
        }

        //if (mUSB != null)
        //{
        //    if(mUSB.GetFlag())
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
    }
}
