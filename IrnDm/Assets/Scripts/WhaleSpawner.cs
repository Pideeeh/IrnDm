using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleSpawner : MonoBehaviour {

    public GameObject SpawnLocation;
    public GameObject Target;

    public float SpawnSpeed;

    private bool isSpawning = false;
    private bool readyNow = true;
    private int difficulty;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isSpawning && readyNow)
        {
            StartCoroutine(MakeObject());
        }
    }

    IEnumerator MakeObject()
    {
        readyNow = false;
        GameObject targetInstance = Instantiate(Target, SpawnLocation.transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(SpawnSpeed);
        readyNow = true;
    }
}
