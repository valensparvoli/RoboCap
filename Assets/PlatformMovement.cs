using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nexPos;
    void Start()
    {
        nexPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == pos1.position)
        {
            nexPos = pos2.position;
        }
        if(transform.position == pos2.position)
        {
            nexPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nexPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
