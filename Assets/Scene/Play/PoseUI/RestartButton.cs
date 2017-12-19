using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

    /// <summary>
    /// オブジェクトの配列
    /// </summary>
    GameObject[] objs = null;
    /// <summary>
    /// 音符のList構造の配列
    /// </summary>
    List<Notes> notes = new List<Notes>();

    //（空の）スタートオブジェクトを取得するためのGameObject型の変数
    GameObject start;

    //プレイヤーオブジェクトを取得するためのGameObject型の変数
    GameObject player;

    //即死トラップのオブジェクト数を調べる
    int objCount = 0;

    //microUSBを取得するためのGameObject型の変数
    //GameObject microUSB;

    //サウンドストップ用
    GameObject soundmng;

    //鍵用
    GameObject key;
    GameObject keyChild;

    // Use this for initialization
    void Start () {
        // 指定したタグで設定されたオブジェクトを探す
        objs = GameObject.FindGameObjectsWithTag("Notes");
        // 探したオブジェクト分foreach構文を回す
        foreach (GameObject obj in objs)
        {
            // Notesのコンポーネントを取得
            Notes n = obj.GetComponent<Notes>();
            notes.Add(n);
        }

        //スタートオブジェクトを取得する
        start = GameObject.Find("Start");

        //プレイヤーオブジェクトを取得する
        player = GameObject.Find("Player");

        //microUSBオブジェクトを取得する
        //microUSB = GameObject.Find("microUSB/microUSB");

        //即死トラップを数える
        objCount = GameObject.Find("DeathTraps").transform.childCount;

        //サウンドストップ用
        soundmng = GameObject.Find("SoundManager");

        //鍵
        key = GameObject.Find("Key");
        keyChild = key.transform.Find("key").gameObject;
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void OnClick()
    {
        //Debug.Log("リスタート");

        //プレイヤーの座標をスタートの座標にする
        player.transform.position = start.transform.position;

        //サウンドストップ
        soundmng.GetComponent<SoundManager>().StopMusic();

        //鍵をアクティブにする
        //GameObject.Find("Key").transform.Find("Key").gameObject.SetActive(true);
        if (keyChild.activeSelf == false)
            keyChild.SetActive(true);

        //オブジェクトの数分復活させる
        if (objCount != 0)
        {
            //Debug.Log("即死トラップの数は" + objCount);
            for (int i = 0; i < objCount; i++)
            {
                if (i == 0)
                    GameObject.Find("DeathTraps").transform.Find("DeathTrap").gameObject.SetActive(true);
                else
                    GameObject.Find("DeathTraps").transform.Find("DeathTrap (" + i + ")").gameObject.SetActive(true);
            }
        }

        //ステレオプラグ踏んでたなら
        if (StereoPlug.noteFripFlag)
        {
            Debug.Log("反転入れ替え");
            foreach (Notes note in notes)
            {
                //音符の種類を変える処理
                note.FlipNote();
            }
            StereoPlug.noteFripFlag = false;
        }

        //microUSBのフラグをfalseにする
        //if (microUSB != null)
        //    microUSB.GetComponent<microUSB>().SetFlag(false);
        microUSB.SetFlag(false);

    }
}
