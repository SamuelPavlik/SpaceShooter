using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float Tumble;
    private Rigidbody _rigi;

    void Start()
    {
        _rigi = GetComponent<Rigidbody>();

        _rigi.angularVelocity = Random.insideUnitSphere * Tumble;
    }
}
