using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffectBefore : MonoBehaviour
{
    private float Cycle;
    private float move;
    private float tall;
    private Vector3 pos;
    // Use this for initialization
    void Start()
    {
        Cycle = 0.1f;
        move = 0.02f;
        tall = 4.0f;
        pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveEffectBefore()
    {
        transform.position = new Vector3(transform.position.x
  , 1.5f + (Mathf.Sin(Time.frameCount * Cycle) / tall), transform.position.z + move);
    }
    public void ResetEffect(Vector3 positions)
    {
        if (transform.position.z >= 3.0f)
        {
            transform.position = positions;
        }
    }

    public void ResetPos(Vector3 positions)
    {
        transform.position = positions;
    }
}

