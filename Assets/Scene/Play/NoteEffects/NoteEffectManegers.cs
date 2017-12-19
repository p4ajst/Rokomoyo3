using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffectManegers : MonoBehaviour
{

    // Ray
    private Ray ray;
    // Rayがヒットしたものの情報 
    private RaycastHit hit;
    Vector3 PointVec;
    Vector3 PastPoint;
    private bool OnOff;

    [SerializeField]
    private NoteEffectBack Back;
    [SerializeField]
    private NoteEffectBefore Before;
    [SerializeField]
    private NoteEffectLeft Left;
    [SerializeField]
    private NoteEffectRight Right;

    /// <summary>
    /// 音マネージャーのインスタンス
    /// </summary>
    public SoundManager sound;

    // Use this for initialization
    void Start()
    {

        PastPoint = new Vector3(10, 10, 10);
        GameObject obj = null;
        // シーンからサウンドマネージャーを探す
        obj = GameObject.Find("SoundManager");
        // サウンドマネージャーのコンポーネントを取得
        sound = obj.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Vector3 clickDeltaPosition = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(clickDeltaPosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                switch (hit.collider.tag)
                {
                    case "Notes":
                        PointVec = hit.collider.gameObject.transform.position;

                        if (PointVec == PastPoint)
                        {
                            this.gameObject.transform.position = PointVec;
                            OnOff = !OnOff;
                            //Debug.Log(OnOff+"にした");
                        }
                        else
                        {
                            this.gameObject.transform.position = PointVec;
                            OnOff = true;
                            //Debug.Log("onにした");
                        }


                        PastPoint = PointVec;
                        break;
                    case "Untagged":

                        break;
                }
            }
        }


        if (sound.nowPlay == Notes.MusicType.NONE)
        {
            OnOff = false;
            //Debug.Log("offにした");
        }
        else
        {
            OnOff = true;
        }

        if (OnOff == false)
        {
            Back.ResetPos(transform.position);
            Before.ResetPos(transform.position);
            Left.ResetPos(transform.position);
            Right.ResetPos(transform.position);
            Back.gameObject.SetActive(false);
            Before.gameObject.SetActive(false);
            Left.gameObject.SetActive(false);
            Right.gameObject.SetActive(false);
            //Debug.Log("off");
        }
        else if (OnOff == true)
        {
            if(this.gameObject.transform.position.z != -3)
                Back.gameObject.SetActive(true);
            if (this.gameObject.transform.position.z != 3)
                Before.gameObject.SetActive(true);
            if (this.gameObject.transform.position.x != -3)
                Left.gameObject.SetActive(true);
            if (this.gameObject.transform.position.x != 3)
                Right.gameObject.SetActive(true);

            Back.MoveEffectBack();
            Before.MoveEffectBefore();
            Left.MoveEffectLeft();
            Right.MoveEffectRight();
            Back.ResetEffect(transform.position);
            Before.ResetEffect(transform.position);
            Left.ResetEffect(transform.position);
            Right.ResetEffect(transform.position);
            //Debug.Log("on");
        }


    }

}
