using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jump;
    
	private Transform tm;
   

    bool ground = true;

    void Start()
    {
		tm = GetComponent<Transform>();
    }

	void Update()
    {
        if (Input.GetKey(KeyCode.W) && ground == true)
        {
            transform.Translate(Vector3.up * jump * Time.deltaTime);
            ground = false;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
