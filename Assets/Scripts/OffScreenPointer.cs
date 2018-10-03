using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenPointer : MonoBehaviour {
    Vector3 screenPos;
    Vector2 onScreenPos;
    float max;
    Camera camera;
    public GameObject cube;
    // Use this for initialization
    void Start () {
        camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        screenPos = camera.WorldToViewportPoint(cube.transform.position); //get viewport positions

        if (screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1)
        {
            Debug.Log("already on screen, don't bother with the rest!");
            return;
        }
        else
        {
            Debug.Log("out of scrren" + screenPos.x+ " " + screenPos.y);
        }
  
        //Debug.Log(onScreenPos);
    }
}
