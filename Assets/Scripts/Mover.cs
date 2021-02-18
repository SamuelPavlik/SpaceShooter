using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody _rigi;

    public float Speed;

	// Use this for initialization
	void Start ()
	{
        _rigi = GetComponent<Rigidbody>();
	    _rigi.velocity = GetComponent<Transform>().forward * Speed;
	}
}
