using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public enum GameState{
        inGame,
        gameOver,
        loading
    }
    public GameState gameState;

    public List<GameObject> targetPrefabs; // esto es hacerlo con una lista es como un array pero se ajusta
    //public GameObject[] targetPrefabs2; esto es hacerlo con un array
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    private int _score;
    private int score
    {
        set
        {
            _score = Mathf.Max(a: value, b: 0);
        }
        get
        {
            return _score;
        }
    }
    void Start()
    {
        gameState=GameState.inGame;
        StartCoroutine(routine: SpawnTarget());
        score = 0;
        UpdateScore(0);
        // gameOverText.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget()
    {
        while (gameState==GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[idx]);
        }
    }
    ///<summary>
    ///Actualiza la puntuacion y lo muestra por pantalla
    ///<summary>
    ///<param name=" scoreToAdd ">Numeros de puntos agregar a la puntuacion global</param>  
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Puntuacion\n" + score;
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameState=GameState.gameOver;
    }
}