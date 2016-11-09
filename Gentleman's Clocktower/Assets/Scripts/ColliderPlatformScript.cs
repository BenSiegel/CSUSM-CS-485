using UnityEngine;
using System.Collections;

public class ColliderPlatformScript : MonoBehaviour {

	private Collider2D setCol;

	void Start(){
		setCol = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (!col.gameObject.tag.Equals ("Ground")) {
			Physics2D.IgnoreCollision (setCol, col, true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (!col.gameObject.tag.Equals ("Ground")) {
			Physics2D.IgnoreCollision (setCol, col, false);
		}
	}
}
