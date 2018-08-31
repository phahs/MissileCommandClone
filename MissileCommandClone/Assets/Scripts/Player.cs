using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    float horz;

    public float rotationSpeed = 5;
    public float launchForce = 1000;
    public GameObject Bullet;
    public GameObject Cannon;

    private float RotMax = 90;
    private float RotMin = -90;
    private Quaternion p_AimRotation; // rotate cannon left and right
    
	// Use this for initialization
	void Start ()
    {
        horz = Input.GetAxis("Horizontal");
        p_AimRotation = transform.localRotation;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        RotateCannon();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(Bullet) as GameObject;
            newBullet.name = "Turret Bullet";
            newBullet.transform.localPosition = new Vector3(Cannon.transform.position.x, Cannon.transform.position.y, 0);
            newBullet.GetComponent<Rigidbody>().AddForce(transform.up * launchForce);

        }
	}

    void RotateCannon()
    {
        horz = Input.GetAxis("Horizontal");
        p_AimRotation *= Quaternion.Euler(0, 0, -horz);

        p_AimRotation = ClampRotationAroundZAxis(p_AimRotation);

        transform.localRotation = p_AimRotation;
    }
    
    Quaternion ClampRotationAroundZAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.z);

        angleZ = Mathf.Clamp(angleZ, RotMin, RotMax);

        q.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);

        return q;
    }
}
