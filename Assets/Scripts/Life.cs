using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    private float _maxSize;

	// Use this for initialization
	void Start () {
        _maxSize = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeLife(Knight knight, int pv)
    {
        float newSize = _maxSize * pv / knight.PvMax;
        transform.localScale = new Vector3(newSize, transform.localScale.y, transform.localScale.z);
    }
}
