using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avance : MonoBehaviour {

    public float speed = 2000;
    private Rigidbody rb;
    public Transform spawnPos;


    // Use this for initialization
    private void Awake() {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Time.deltaTime * speed;

    }

    // Update is called once per frame
    void Update () {
    	int i = 0;
    	while(i<50)
    	{
			if((transform.position.x < -48) || (transform.position.x > 98))
			{
            	Destroy(this.gameObject);
           		Instantiate(this.gameObject, spawnPos.position, spawnPos.rotation);
        	}
        	i++;
       	}
    }
}