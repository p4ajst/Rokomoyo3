using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//即死トラップのスクリプト

public class DeathTrap : Trap {

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;

    /// <summary>
    /// オブジェクトの配列
    /// </summary>
    GameObject[] objs = null;
    /// <summary>
    /// 音符のList構造の配列
    /// </summary>
    List<Notes> notes = new List<Notes>();

    //サウンドストップ用
    GameObject soundmng;

    //フェード用
    GameObject fade;

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

        //サウンドストップ用
        soundmng = GameObject.Find("SoundManager");

        //フェード用
        fade = GameObject.Find("FadeManager");
        fade.GetComponent<FadeManager>();

    }

    // Update is called once per frame
    override protected void Update()
    {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true)
        {
            //フェードオンするためのフラグをオンにする
            fade.GetComponent<FadeManager>().enableFade = true;
            fade.GetComponent<FadeManager>().enableFadeOn = true;

            //サウンドストップ
            soundmng.GetComponent<SoundManager>().StopMusic();
        }

        //フェードオンで画面が暗くなったら処理を実行する
        if (fade.GetComponent<FadeManager>().GetEnableAlphaTop() == true)
        {
            //プレイヤーの座標をスタートの座標にする
            player.transform.position = start.transform.position;

            //鍵をアクティブにする
            GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);

            //ステレオプラグ踏んでたなら
            if (StereoPlug.noteFripFlag == true)
            {
                foreach (Notes note in notes)
                {
                    //音符の種類を変える処理
                    note.FlipNote();
                    StereoPlug.noteFripFlag = false;
                }
            }
        }

        //microUSBを踏まれたなら
        if (microUSB.GetFlag())
        {
            //オブジェクトを消す
            gameObject.SetActive(false);
        }
    }
}
