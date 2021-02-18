using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    private Transform _transform;
    public int ScoreValue;

    private GameController _gameController;

    void Start()
    {
        _transform = GetComponent<Transform>();
        if ((_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>()) == null)
            Debug.Log("Cannot find 'GameController' script");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Boundary" || col.tag == "Enemy")
            return;
        if (col.tag == "Player")
        {
            Instantiate(PlayerExplosion, _transform.position, _transform.rotation);
            _gameController.GameOver();
        }

        if (Explosion != null)
            Instantiate(Explosion, _transform.position, _transform.rotation);

        if (col.CompareTag("Bolt"))
        {
            col.gameObject.SetActive(false);
        }
        else
        {
            Destroy(col.gameObject);
        }

        Destroy(gameObject);
        _gameController.AddScore(ScoreValue);

    }
}
