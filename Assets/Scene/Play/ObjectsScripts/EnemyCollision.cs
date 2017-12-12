using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyCollision : Trap {

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;

    //電磁パルスの個数を数えるためのもの
    int objCount = 0;

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
        base.Start();
        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");

        //即死トラップを数える
        objCount = GameObject.Find("DeathTraps").transform.childCount;

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
	override protected void Update () {
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
            microUSB.SetFlag(false);
            //プレイヤーの座標をスタートの座標にする
            player.transform.position = start.transform.position;

            //鍵をアクティブにする
            GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);

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

            //電磁パルスが０じゃないなら
            if (objCount != 0)
            {
                //電磁パルスの個数ぶん回す
                for (int i = 0; i < objCount; i++)
                {
                    //０の時だけ何もつかないので分ける
                    if (i == 0)
                        GameObject.Find("DeathTraps").transform.Find("DeathTrap").gameObject.SetActive(true);
                    //それ以外の時は（？）がつく
                    else
                        GameObject.Find("DeathTraps").transform.Find("DeathTrap (" + i + ")").gameObject.SetActive(true);
                }
            }
        }
    }
}
