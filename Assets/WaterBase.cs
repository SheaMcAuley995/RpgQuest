using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBase : MonoBehaviour {

    public float speedX = 0.1f;
    public float speedY = 0.1f;
    private float curX;
    private float curY;




	void Awake () {
        curX = GetComponent<Renderer>().material.GetTextureOffset("EmissionTileOffset").x;
        //Debug.Log(curX);
	}
	
	
	void Update () {
		
	}
}
