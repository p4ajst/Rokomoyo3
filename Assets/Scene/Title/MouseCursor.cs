using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Vector3 position;
    private Vector3 screenToWorldPosition;


    public void FixedUpdate()
    {
        // マウスの座標を取得
        position = Input.mousePosition;
        // ｚ軸を設定
        position.z = 10.0f;
        // マウスの位置をスクリーン座標からワールド座標に変換する
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(position);
        // ワールド座標に変換されたマウス座標を代入
        gameObject.transform.position = screenToWorldPosition;
    }

    // Use this for initialization
    void Start ()
    {
        
	}
    // オブジェクトの有効かどうか
    private void OnEnable()
    {
        Cursor.visible = false;
    }
    private void OnDisable()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
