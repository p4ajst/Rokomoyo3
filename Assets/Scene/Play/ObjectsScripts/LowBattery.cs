using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//充電減のスクリプト

public class LowBattery : Trap {

    //一度だけ使わせるようにフラグ管理
    bool used;
    public Image img;
    bool imgflag;
    // Use this for initialization
    override protected void Start () {
        //基底クラスのStart関数
        base.Start();
        imgflag = false;

    }

    // Update is called once per frame
    override protected void Update () {
        //基底クラスのUpdate関数
        base.Update();

        //トラップの上にいるなら
        if (base.OnFloor() == true && used == false)
        {
            //Debug.Log("当たっています");
            img.color = new Color(0.5f, 0f, 0f, 0.5f);
            imgflag = true;
            //プレイヤーの充電を一度だけ減らす
            //player.GetComponent<chara>().Charge -= 0.1f;
            CharacterManager.SetBattery(CharacterManager.GetBattery() - 0.1f);

            //減らしたらトラップを使ったというフラグを立てる
            used = true;
        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            //Debug.Log("当たっていません");
            img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime*4);
            //当たっていない状態にする
            used = false;
        }
        if (imgflag)
        {
            img.color = Color.Lerp(this.img.color, Color.clear, Time.deltaTime * 4);
            if (img.color.a <= 0.0f)
            {
                imgflag = false;
            }
        }
    }
}
