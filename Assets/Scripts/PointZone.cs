using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class PointZone : MonoBehaviour {
    
    public Knight knight;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("ball")) return;
        Ball ball = col.gameObject.GetComponent<Ball>();
        ball.Restart(knight.player);
        knight.DoStun();

    }
}
