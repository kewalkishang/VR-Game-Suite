using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBeh : MonoBehaviour {
    Animator anim;
    private bool attackDone = false;
    private bool shot = false;
    public float speed = 2f;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position,new Vector3(0, 0, 0)) < 10)
        {
            anim.SetTrigger("attack");
            if(!attackDone)
            {
                attackDone = true;
                StartCoroutine(attackDelay());
            }
        }
        else
        {
            Vector3 targetDir = new Vector3(0,0,0) - transform.position;
       
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, Time.deltaTime * speed, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
	}
    IEnumerator attackDelay()
    {
        yield return new WaitForSeconds(3);
        GameManager.instance.TakeDamage(4);
        attackDone = false;
    }

   public void OnShot()
    {    
        if (!shot)
        {
          
            Animator muzzle = GameObject.FindGameObjectWithTag("muzzle").GetComponent<Animator>();
            muzzle.SetTrigger("muzzle");
            muzzle.SetTrigger("idle");
            shot = true;
            anim.SetTrigger("death");
            StartCoroutine(dying());
            GameManager.instance.ZSCORE();
        }
    }
    IEnumerator dying()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
