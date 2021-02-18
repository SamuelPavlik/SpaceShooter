using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private AudioSource _audioSource;

    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;
    public float Delay;

	// Use this for initialization
	void Start ()
	{
	    _audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", Delay, FireRate);
	}

    void Fire ()
    {
        Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
        _audioSource.Play();
    }
}
