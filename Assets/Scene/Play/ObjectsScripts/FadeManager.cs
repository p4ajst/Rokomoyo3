using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    //フェードするためのフラグ
    public bool enableFade = false;
    public bool enableFadeOn = false;

    //フェードするスピード
    public float speed = 0.02f;

    //フェードの画像（黒）
    public Image FadeImage;

    //フェードのカウント（1になったら真っ黒）
    public float count = 0.0f;

    //フェードのカウントが１になっているかのフラグ（１になったら０に戻す）
    bool enableAlphaTop = false;

	// Use this for initialization
	void Start () {
        //透明な黒い画像をセットする
        SetAlpha(FadeImage, count);
	}
	
	// Update is called once per frame
	void Update () {

        //フェードフラグがたったら
		if(enableFadeOn)
        {
            //フェードを開始する
            FadeInAndOut(FadeImage);
        }
	}

    //画像の情報を取る
    void SetAlpha(Image image,float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    //フェードオンの処理
    void FadeInAndOut(Image image)
    {
        //フラグが立っていて
        if(enableFade)
        {
            //カウントが１まで行ってないなら
            if(!enableAlphaTop)
            {
                //カウントを足す
                count += speed;
            }
            //カウントが１まで行ってるなら
            else
            {
                //カウントを引く
                count -= speed;
                //αが０まで下がったなら
                if(image.color.a<=0.0f)
                {
                    //フェード関係のフラグをすべて消す
                    enableFade = false;
                    enableFadeOn = false;
                    enableAlphaTop = false;
                }
            }

            //画像の情報を取る
            SetAlpha(image, count);

            //αが１になったら
            if(image.color.a>=1.0f)
            {
                //それ用のフラグを立てる
                enableAlphaTop = true;
            }
        }
    }

    //画面が真っ暗になったときに処理をする場合で使用するゲッター
    public bool GetEnableAlphaTop()
    {
        return enableAlphaTop;
    }
}
