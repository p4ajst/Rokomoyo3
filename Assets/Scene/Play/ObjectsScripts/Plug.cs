using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Plug : Gimmick {

  

    //パーティクルエフェクト
    public GameObject RecoveryEffectParticle;        //パーティクル
    public Transform[] RecoveryEffectPoints;         // 地点
    bool effect;

    // Use this for initialization
    override protected void Start () {
        base.Start();
	}

    // Update is called once per frame
    override protected void Update () {
        base.Update();

        //ギミックの上にいるなら
        if (base.OnFloor() == true)
        {
            //Debug.Log("当たっています");
            foreach (Transform explosionPos in RecoveryEffectPoints[0])
            {
                GameObject RecoveryEffect = Instantiate(RecoveryEffectParticle,               // パーティクルオブジェクトの生成
                    explosionPos.position, transform.rotation) as GameObject;
                Destroy(RecoveryEffect, 1f);                                             // 3秒後に消す
            }
        
            //プレイヤーの充電を回復する
            CharacterManager.SetBattery(CharacterManager.GetBattery() + 0.01f);
        }
        //トラップから抜けたら
        else if (base.OnFloor() == false)
        {
            //Debug.Log("当たっていません");

        }
  
    }
}
