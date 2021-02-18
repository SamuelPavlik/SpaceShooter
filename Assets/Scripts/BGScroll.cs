using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float ScrollSpeed;
    public float TileSizeZ;

    private Transform _transform;
    private Vector3 _startPos;
    
	// Use this for initialization
	void Start ()
	{
        _transform = GetComponent<Transform>();
	    _startPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float newPos = Mathf.Repeat(Time.time * ScrollSpeed, TileSizeZ);
	    _transform.position = _startPos + Vector3.forward * newPos;
	}
}
