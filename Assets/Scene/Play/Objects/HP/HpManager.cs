using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour {   
    private float nowRate;
    public static float _hp;
    float _disappearancehp = 0.01f;
    //HP用バー
    Image Bar;

    //HPが削られたとき見える赤いバー
    public Image activeBar;
    public Image frame;
    Color color1= new Color(1.0f, 1.0f, 1.0f, 1.0f);
    Color color2 = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    // シーン変更
    SceneChanger sceneChanger = null;
     void Awake()
    {
        //一に設定
        nowRate = 1;
        //_hp = chara.Charge;
        _disappearancehp = 0.01f;
    }

    void Start()
    {
        //Scriptを持っている画像を読み込む
       Bar = GetComponent<Image>();
       GameObject scene = GameObject.Find("FadePanel");
        // コンポーネントを取得
        sceneChanger = SceneChanger.Instance;

    }


    void Update()
    {
        _hp = CharacterManager.GetBattery();

        // _hp = chara.Charge;

        ActiveBar();
        // HP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hp -= 0.3f;
        }
        if (_hp < 0.05)
        {
            if (color1 != frame.GetComponent<Image>().color)
            {
                frame.color = color1;
            }
            else
            {
                frame.color = color2;
            }
        }
        if (_hp < 0)
        {
            Debug.Log("hp0");
            // 最大を超えたら1に戻す
            CharacterManager.SetBattery(1.0f);
            nowRate = 1;
            Stage.SetStageNum(1);
            sceneChanger.ExecuteCoroutine("Result");
        }
        // HPゲージに値を設定
        Bar.fillAmount = _hp;
    }

    //自身の子要素に数値に応じた動作を実行
    public void ActiveBar()
    {
  
        if (_hp < nowRate)
        {
            nowRate -= _disappearancehp;
        }
        activeBar.fillAmount = nowRate;
    }
}
