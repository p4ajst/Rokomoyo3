using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEffects : MonoBehaviour
{

    public LayerMask mask;
    Vector3 PointVec;
    Vector3 PastPoint;
    public Transform prefab;
    GameObject[] box;
    bool flag;
    bool works;
    bool worksflag;
    // Use this for initialization
    void Start()
    {

        flag = false;
        works = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rey();
    }

    private void Rey()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Rayが衝突したかどうか

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            PointVec = hit.collider.gameObject.transform.position;
            //Debug.Log(PointVec);
            if (PointVec != PastPoint)
            {
                box = GameObject.FindGameObjectsWithTag("point");
                foreach (GameObject obs in box)
                {
                    Destroy(obs);
                    //Debug.Log("破棄中");
                }
                worksflag = true;
            }
            switch (hit.collider.tag)
            {
                case "Notes":
                    PastPoint = PointVec;
                    flag = true;
                    works = true;
                    //Debug.Log("生成中");
                    break;
                case "Untagged":
                    flag = false;
                    works = false;
                    worksflag = true;
                    break;
            }

        }
        else
        {

            flag = false;
            worksflag = true;
        }

        if (works == true && worksflag == true)
        {
            for (int t = 0; t < 7; t++)
            {
                if (PointVec.x + (1.0f * t) <= 3)
                {
                    Instantiate(prefab, new Vector3(PointVec.x + (1.0f * t), 0.51f, PointVec.z), Quaternion.identity);
                }
                if (PointVec.x - (1.0f * t) >= -3)
                {
                    Instantiate(prefab, new Vector3(PointVec.x - (1.0f * t), 0.51f, PointVec.z), Quaternion.identity);
                }
                if (PointVec.z + (1.0f * t) <= 3)
                {
                    Instantiate(prefab, new Vector3(PointVec.x, 0.51f, PointVec.z + (1.0f * t)), Quaternion.identity);
                }
                if (PointVec.z - (1.0f * t) >= -3)
                {
                    Instantiate(prefab, new Vector3(PointVec.x, 0.51f, PointVec.z - (1.0f * t)), Quaternion.identity);
                }
            }
            works = false;
            worksflag = false;
        }

        if (flag == false)
        {
            box = GameObject.FindGameObjectsWithTag("point");
            foreach (GameObject obs in box)
            {
                Destroy(obs);
                //Debug.Log("破棄中");
            }

        }
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 30.0f);
    }
}
