using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChecker : MonoBehaviour {
    public Shape[] connectors;
    public GameObject SUCCESS;
    public GameObject SHAPE;
    public GameObject inAIR;

    // Update is called once per frame
    void Update()
    { if (gameObject.transform.parent.gameObject.activeSelf == true)
        {
            if (connectors.Length == 2)
                if (connectors[0].AllConnect && connectors[1].AllConnect && !inAIR.GetComponent<LiftObjects>().inAIR)
                {
                    SUCCESS.SetActive(true);
                    SHAPE.SetActive(false);
                    Debug.Log("shape found");
                }
                else
                {
                    SUCCESS.SetActive(false); SHAPE.SetActive(true);
                }
            if (connectors.Length == 1)
            {
                if (connectors[0].AllConnect && !inAIR.GetComponent<LiftObjects>().inAIR)
                {
                    SUCCESS.SetActive(true);
                    SHAPE.SetActive(false);
                    Debug.Log("shape found");
                }
                else
                {
                    SUCCESS.SetActive(false);
                    SHAPE.SetActive(true);
                }
            }
        }
    }
}
