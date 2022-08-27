using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
	private float length, startpos;
	public GameObject cam;
	public float parralaxEffect;

    // Start is called before the first frame update
    void Start()
    {
    	startpos = transform.position.x;
    	//length of the sprite 
    	length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float dist = (cam.transform.position.x * parralaxEffect);
       float temp = (cam.transform.position.x * (1 - parralaxEffect));

       transform.position = new Vector3 (startpos + dist, transform.position.y, transform.position.z);

       if (temp > startpos + length) startpos += length;
       else if (temp < startpos - length) startpos -= length;



    }
}
