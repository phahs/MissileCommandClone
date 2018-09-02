using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGenerator : MonoBehaviour {
    int WaveNumber = 1;
    float WaveLength = 60f;
    float WaveTimer = 0f;
    float TimeBetweenWaves = 10f;
    float BetweenWaveTimer = 0f;
    bool betweenWave = true;
    int MinMissiles = 12;
    int MissilesPerWave;
    float MissileChance = 0f;
    float launchForce = 25;

    public GameObject Missile;

	// Use this for initialization
	void Start ()
    {
        MissilesPerWave = DetermineMissilesInWave();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(betweenWave)
        {
            if(BetweenWaveTimer >= TimeBetweenWaves)
            {
                betweenWave = false;
                BetweenWaveTimer = 0f;
                MissileChance = SetChanceToFireFirstMissile();
            }
            else
            {
                BetweenWaveTimer += Time.deltaTime;
            }
        }
        else
        {
            if(WaveTimer >= WaveLength)
            {
                betweenWave = true;
                WaveTimer = 0f;
            }
            {
                if(MissilesPerWave > 0)
                {
                    FireMissile();
                }
            }
        }
	}

    private int DetermineMissilesInWave()
    {
        return Random.Range(MinMissiles, (MinMissiles + WaveNumber * 5));
    }

    private float SetChanceToFireFirstMissile()
    {
        return Random.Range(0f, 100f);
    }

    private void FireMissile()
    {
        float rand = Random.Range(0f, 100f);

        if(rand < MissileChance)
        {
            GameObject newMissile = Instantiate(Missile) as GameObject;
            newMissile.name = "Missile";
            newMissile.transform.localPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(10f, 13f), 0);
            newMissile.GetComponent<Rigidbody>().AddForce(-transform.up * launchForce);

            MissilesPerWave -= 1;
            MissileChance = SetChanceToFireFirstMissile();
        }
        else
        {
            MissileChance += MissilesPerWave;
        }
    }
}
