using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public int Tilt;
    public float Dodge;
    public float Smoothing;
    public Vector2 StartWait;
    public Vector2 ManeuverTime;
    public Vector2 ManeuverWait;
    public Boundary Bound;

    private Transform _playerTransform;
    private float _targetManeuver;
    private Transform _transform;
    private Rigidbody _rigibody;

    void Start ()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _transform = GetComponent<Transform>();
        _rigibody = GetComponent<Rigidbody>();
	    StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(StartWait.x, StartWait.y));

        while (_playerTransform != null)
        {
            //_targetManeuver = Random.Range(1, Dodge) * -Mathf.Sign(_transform.position.x);
            _targetManeuver = _playerTransform.position.x;
            yield return new WaitForSeconds(Random.Range(ManeuverTime.x, ManeuverTime.y));
            _targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(ManeuverWait.x, ManeuverWait.y));
        }
    }

	void FixedUpdate ()
	{
	    float newManeuver = Mathf.MoveTowards(_transform.position.x, _targetManeuver, Time.deltaTime * Smoothing);
        //_rigibody.position = new Vector3(newManeuver, 0.0f, _rigibody.position.z);
        _rigibody.position = new Vector3(
                                        Mathf.Clamp(newManeuver, Bound.xMin, Bound.xMax),
                                        0.0f,
                                        Mathf.Clamp(_rigibody.position.z, Bound.zMin, Bound.zMax));
	    _rigibody.rotation = Quaternion.Euler(0.0f, 0.0f, -Tilt * _rigibody.velocity.x);

    }
}
