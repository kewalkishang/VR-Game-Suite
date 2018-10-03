using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {
    public GameObject Down;
    public GameObject up;
    bool Cond1 = false;
    bool Cond2 = false;
    public bool AllConnect = false;
	void Start () {
		
	}

    void FixedUpdate()
    {
        
        RaycastHit hit;
        RaycastHit hit2;
        // Debug.DrawLine(transform.position, Color.green ,1);
        Vector3 downward = transform.TransformDirection(-Vector3.up)*2f;
        Debug.DrawRay(transform.position,downward, Color.green);
        if (Physics.Raycast(transform.position, downward, out hit , 2f))
        {
            if (hit.collider.gameObject == Down)
                Cond1 = true;
            else
                Cond1 = false;
        }
        else
        {
            Cond1 = false;
        }
        Vector3 upward = transform.TransformDirection(Vector3.up) * 1.5f;
        Debug.DrawRay(transform.position, upward, Color.green);
        if (Physics.Raycast(transform.position, upward, out hit2, 1.5f))
        {

            if (hit2.collider.gameObject == up)
                Cond2 = true;
            else
                Cond2 = false;
        }
        else
        {
            Cond2 = false;
        }
        if (Cond1 && Cond2)
        {
            AllConnect = true;
             Debug.Log("shape is done");

        }
        else
        {
            AllConnect = false;
        }
    }
}
