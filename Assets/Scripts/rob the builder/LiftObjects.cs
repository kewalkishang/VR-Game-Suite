using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftObjects : MonoBehaviour {

    public bool inAIR = false;
    public GameObject pointer;
    GameObject LiftObj;
	
	// Update is called once per frame
	void Update () {
      if(inAIR)
        {
           
            Ray ray = new Ray(pointer.transform.position, pointer.transform.forward);
            LiftObj.transform.position = Vector3.Slerp(LiftObj.transform.position,ray.GetPoint(15),Time.deltaTime*10);
        }
    }
    public void lift(GameObject lifted)
    {
        LiftObj = lifted;
        inAIR = !inAIR;
        if (!inAIR)
            lifted.GetComponent<Rigidbody>().useGravity = true;
        else
            lifted.GetComponent<Rigidbody>().useGravity = false;

    }

}
