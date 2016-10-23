using UnityEngine;
using System.Collections;

public class BulletDistory : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision){
		DestroyObject (gameObject, 0f);
	}
}
