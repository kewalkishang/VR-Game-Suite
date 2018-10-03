using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStick : MonoBehaviour {
    public GameObject Stickman;
    public GameObject target;
	// Use this for initialization
	void Start () {

        InvokeRepeating("SpawnS", 2.0f, 3.5f);
    


}
	
    public void SpawnS()
    {

        if (gameObject.activeSelf == true)
        { 
            GameObject sm = Instantiate(Stickman, RandomCircle(new Vector3(0, -2, 0), 30), Quaternion.identity);
            sm.transform.LookAt(target.transform);

        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
