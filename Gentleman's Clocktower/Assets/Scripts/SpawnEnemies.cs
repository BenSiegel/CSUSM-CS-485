using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	//public int numOfEnemies;
	public GameObject enemy;
	public float timeBetweenSpawns;

	private Vector3 min;
	private Vector3 max;
	private Renderer ren;
	private float timeLastSpawn;

	// Use this for initialization
	void Start () {
		ren = GetComponent<Renderer> ();
		min = ren.bounds.min;
		max = ren.bounds.max;
		timeLastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeLastSpawn > timeBetweenSpawns) {
			timeLastSpawn = Time.time;
			Vector3 pos = new Vector3 (
				Random.Range(min.x, max.x),
				Random.Range(min.y, max.y),
				Random.Range(min.z, max.z));
			GameObject NewEnemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
		}
	}
}
