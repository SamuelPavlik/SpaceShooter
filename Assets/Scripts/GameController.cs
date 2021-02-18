using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] Hazards;
    public Vector3 SpawnValues;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public GUIText ScoreText;
    public GUIText GameOverText;
    public GameObject RestartButton;

    private int _score;
    private bool _gameOver;

    void Start()
    {
        _gameOver = false;
        GameOverText.text = "";

        StartCoroutine(SpawnWaves());
        _score = 0;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + _score;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                if (_gameOver)
                    break;

                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                Instantiate(Hazards[Random.Range(0, Hazards.Length)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(SpawnWait);
            }

            if (_gameOver)
                break;

            yield return new WaitForSeconds(WaveWait);
        }
    }

    public void AddScore(int scoreValue)
    {
        _score += scoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        GameOverText.text = "Game Over";
        RestartButton.SetActive(true);
        _gameOver = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
