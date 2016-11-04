using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	//public int numOfEnemies;
	//public GameObject enemy;
    
    public GameObject enemyFlying1; 
    public GameObject enemyFlying2;
    public GameObject enemyFlying3;
    public GameObject enemyGround1;
    public GameObject enemyGround2;    
     
    public float timeBetweenSpawns;
    public int fly1health;
    public int fly1damage;
    public int fly1armour;
    public int fly1speed;

    public int fly2health;
    public int fly2damage;
    public int fly2armour;
    public int fly2speed;

    public int fly3health;
    public int fly3damage;
    public int fly3armour;
    public int fly3speed;

    public int ground1health;
    public int ground1damage;
    public int ground1armour;
    public int ground1speed;

    public int ground2health;
    public int ground2damage;
    public int ground2armour;
    public int ground2speed;

    private Vector3 min;
	private Vector3 max;
	private Renderer ren;
    private int spawnRate;
	private float timeLastSpawn;

	// Use this for initialization
	void Start () {
		ren = GetComponent<Renderer> ();
		min = ren.bounds.min;
		max = ren.bounds.max;
        spawnRate = 0;
		timeLastSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        /*
   
         */
        if (Time.time - timeLastSpawn > timeBetweenSpawns) {
			timeLastSpawn = Time.time;
			Vector3 pos = new Vector3 (
				Random.Range(min.x, max.x),
				Random.Range(min.y, max.y),
				Random.Range(min.z, max.z));
            //GameObject NewEnemy = (GameObject)Instantiate(enemy, pos, Quaternion.identity);
            spawnRate = Random.Range(1, 100);
            if (spawnRate >= 1 && spawnRate <= 6)
            {
                GameObject NewEnemyFlying1 = (GameObject)Instantiate(enemyFlying1, pos, Quaternion.identity);
            }
             if (spawnRate >= 7 && spawnRate <= 13)
            {
                GameObject NewEnemyFlying2 = (GameObject)Instantiate(enemyFlying2, pos, Quaternion.identity);
            }
           else if (spawnRate >= 14 &&spawnRate <= 20)
            {
                GameObject NewEnemyFlying3 = (GameObject)Instantiate(enemyFlying3, pos, Quaternion.identity);
            }
            else if (spawnRate >= 21 && spawnRate <= 26)
            {
                GameObject NewEnemyGround1 = (GameObject)Instantiate(enemyGround1, pos, Quaternion.identity);
            }
            else if (spawnRate >= 27 && spawnRate <= 34)
            {
                GameObject NewEnemyGround2 = (GameObject)Instantiate(enemyGround2, pos, Quaternion.identity);
            }
        }
	}
}
