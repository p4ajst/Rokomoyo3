using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StereoPlug : Gimmick {

    bool flag = false;
    /// <summary>
    /// オブジェクトの配列
    /// </summary>
    GameObject[] objs = null;
    /// <summary>
    /// 音符のList構造の配列
    /// </summary>
    List<Notes> notes = new List<Notes>();

    /// <summary>
    /// 反転フラグ
    /// </summary>
    public static bool noteFripFlag;

	// Use this for initialization
	override protected void Start () {
        base.Start();

        // 指定したタグで設定されたオブジェクトを探す
        objs = GameObject.FindGameObjectsWithTag("Notes");
        // 探したオブジェクト分foreach構文を回す
        foreach(GameObject obj in objs)
        {
            // Notesのコンポーネントを取得
            Notes n = obj.GetComponent<Notes>();
            notes.Add(n);
        }

        noteFripFlag = false;
    }

    // Update is called once per frame
    override protected void Update () {
        base.Update();

        //ギミックの上にいるなら
        if (base.OnFloor() == true && !flag)
        {
            //Debug.Log("のってる");
            flag = true;
            // notesの配列分foreach構文を回す
            foreach (Notes note in notes)
            {
                //音符の種類を変える処理
                note.FlipNote();
            }
            noteFripFlag = !noteFripFlag;
        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            flag = false;
            //Debug.Log("当たっていません");
        }
        //if(flag)
        //{

        //    Debug.Log("はーんてぇーんっ！");
        //}
    }
}
