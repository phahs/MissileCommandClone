using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
    public GameObject Explosion;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Explode()
    {
        GameObject newExplosion = Instantiate(Explosion) as GameObject;
        newExplosion.name = "Explosion";
        newExplosion.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
        newExplosion.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            // other.getcomponent<building>().blownup();
            Explode();
        }

        if(other.tag == "Bullet Kill")
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
