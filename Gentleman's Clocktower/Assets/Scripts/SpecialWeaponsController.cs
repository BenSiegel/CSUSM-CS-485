using UnityEngine;
using System.Collections;

public class SpecialWeaponsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    void weapons(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            DestroyObject(gameObject, 0f);
        }
    }
}
