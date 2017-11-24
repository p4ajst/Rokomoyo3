using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microUSB : Gimmick {

    //踏んでいるか確認のフラグ
    static bool flag = false;

    // Use this for initialization
    override protected void Start () {
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        base.Update();

        //踏んでいたら
        if (base.OnFloor())
        {
            //フラグを立てる
            flag = true;
        }
	}

    //フラグ確認用
    static public bool GetFlag()
    {
        return flag;
    }
    static public void SetFlag(bool _flag)
    {
        flag = _flag;
    }
}
