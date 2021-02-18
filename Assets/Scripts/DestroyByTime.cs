using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Lifetime;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, Lifetime);
	}
}