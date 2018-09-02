using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    float timer;
    float expand = 2f;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(timer < expand)
        {
            float x, y, z;
            x = timer / expand;
            y = timer / expand;
            z = timer / expand;

            transform.localScale = new Vector3(x, y, z);
        }
        else
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
	}
}
