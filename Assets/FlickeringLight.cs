using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlickeringLight : MonoBehaviour {

    public Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        
       
        light.intensity = Random.Range(4f, 4.5f); ;
	}
}
