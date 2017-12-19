using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEffectRight : MonoBehaviour
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

    public void MoveEffectRight()
    {
        transform.position = new Vector3(transform.position.x + move
  , 1.5f + (Mathf.Sin(Time.frameCount * Cycle) / tall), transform.position.z);
    }

    public void ResetEffect(Vector3 positions)
    {
        if (transform.position.x >= 3.0f)
        {
            transform.position = positions;
        }
    }
    public void ResetPos(Vector3 positions)
    {
        transform.position = positions;
    }

}
