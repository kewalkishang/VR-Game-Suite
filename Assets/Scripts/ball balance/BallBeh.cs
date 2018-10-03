using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBeh : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
 
	}


    private void OnCollisionEnter(Collision collision)
    { if (collision.gameObject.tag == "floor")
        {
          
            Destroy(gameObject);

        }
    else
        if (collision.gameObject.tag == "basket")
        {
            Debug.Log("you scored");
            Destroy(gameObject);
            GameManager.instance.BBSCORE();
        }
  
    }
}
