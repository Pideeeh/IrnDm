using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {

    public float SpawnSpeed;

    public GameObject Target;

    private bool isSpawning = false;
    private bool readyNow = true;
    private int difficulty;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (isSpawning && readyNow)
        {
            StartCoroutine(MakeObject());
        }
    }

    IEnumerator MakeObject()
    {
        readyNow = false;
        //Debug.Log("Spawn");
        int SpawnDistance = Random.Range(15, 30);
        float SpawnAngel = NDistribution(0, Mathf.PI / 2);
        float FacingAngel = Random.Range(0.7f, 1.2f);
        Vector3 SpawnDirection = new Vector3(Mathf.Cos(SpawnAngel), 0, Mathf.Sin(SpawnAngel));
        //int rotation = (int)(Mathf.Sign(SpawnDirection.x) * Mathf.Sign(SpawnDirection.z));
        Instantiate(Target, SpawnDirection * SpawnDistance + new Vector3(0, 4, 0), new Quaternion(SpawnDirection.z, 0, -SpawnDirection.x, Mathf.Cos(FacingAngel)));
        yield return new WaitForSecondsRealtime(SpawnSpeed);
        readyNow = true;
    }


    Transform NextSpawnPosition() {
        //Add logic for random spawn
        return gameObject.transform;
    }

    public void StartSpawning(int difficulty) {
        this.difficulty = difficulty;
        isSpawning = true;
    }

    public void StopSpawning() {
        isSpawning = false;
    }

    public float NDistribution(float mean, float std)
    {
        float u1 = 0;
        float u2 = 0;
        float v = 0;

        while (v > 1 || v == 0)
        {
            u1 = Random.Range(-1f, 1f);
            u2 = Random.Range(-1f, 1f);
            v = u1 * u1 + u2 * u2;
        }

        return mean + std * v;
    }
}
