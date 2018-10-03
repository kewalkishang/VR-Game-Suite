using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

    public GameObject ball;
    BoxCollider col;
    MeshRenderer mr;
    bool visible = true;
    private void Start()
    {
        col = GetComponent<BoxCollider>();
        mr = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("ball"))
        {
            if (col.enabled != false)
            {
                col.enabled = false;
                mr.enabled = false;
                if (visible)
                {
                    visible = false;
                    StartCoroutine(DelayBeforeInvisible());

                }
            }
            
        }
        else
        {
            if (col.enabled != true)
            {
                foreach (Transform t in gameObject.transform)
                    t.gameObject.SetActive(true);
                col.enabled = true;
                mr.enabled = true;
                visible = true;
            }
        }
        
    }
    public void GetBall()
    {
        Instantiate(ball, gameObject.transform.position, Quaternion.identity);
    }

    IEnumerator DelayBeforeInvisible()
    {
        yield return new WaitForSeconds(1);
        foreach (Transform t in gameObject.transform)
            t.gameObject.SetActive(false);
        
    }
}
