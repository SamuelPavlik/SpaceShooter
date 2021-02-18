using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigi;
    private float _nextFire = 0.5F;
    private float _myTime = 0.0F;
    private const int PoolSize = 7;
    private List<GameObject> _shots;

    public GameObject Shot;
    public Transform ShotSpawn;
    public float MoveSpeed = 1;
    public Boundary boundary;
    public float Tilt = 4;
    public float FireDelta = 0.5F;

    // Use this for initialization
    void Start ()
	{
        _rigi = GetComponent<Rigidbody>();
        _shots = new List<GameObject>();
	    for (int i = 0; i < PoolSize; i++)
	    {
	        GameObject obj = (GameObject)Instantiate(Shot);
            obj.SetActive(false);
            _shots.Add(obj);
	    }
	}

    void Update()
    {
        _myTime += Time.deltaTime;

        if (Input.GetButton("Fire1") && _myTime > _nextFire)
        {
            _nextFire = _myTime + FireDelta;
            //Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            Fire();

            _nextFire = _nextFire - _myTime;
            _myTime = 0.0F;

            GetComponent<AudioSource>().Play();
        }
    }
	
	void FixedUpdate ()
	{
	    float moveHor = Input.GetAxis("Horizontal");
	    float moveVer = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHor, 0.0f, moveVer);
        _rigi.velocity = movement * MoveSpeed;
        _rigi.position = new Vector3(Mathf.Clamp(_rigi.position.x, boundary.xMin, boundary.xMax),
                                        0.0f,
                                        Mathf.Clamp(_rigi.position.z, boundary.zMin, boundary.zMax));
        _rigi.rotation = Quaternion.Euler(0.0f, 0.0f, -Tilt * _rigi.velocity.x);

    }

    void Fire()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            if (!_shots[i].activeInHierarchy)
            {
                _shots[i].transform.position = ShotSpawn.position;
                _shots[i].transform.rotation = ShotSpawn.rotation;
                _shots[i].SetActive(true);
                break;
            }
        }
    }
}
