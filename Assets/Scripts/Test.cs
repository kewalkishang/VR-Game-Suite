using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

public void DoSomething()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
    }
}
