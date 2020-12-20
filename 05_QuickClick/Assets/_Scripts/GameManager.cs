using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        inGame,
        gameOver,
        loading
    }
    private const string MAX_SCORE = "MAX_Score";
    public GameState gameState;
    public Button restartButton;
    public List<GameObject> targetPrefabs; // esto es hacerlo con una lista es como un array pero se ajusta
    //public GameObject[] targetPrefabs2; esto es hacerlo con un array
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public GameObject titleScreen;
    private int numberOfLives = 4;
    public List<GameObject> lives;
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
    private void Start()
    {
        ShowMaxScore();
    }
    ///<summary>
    ///Metodo que inicia la partida
    ///<summary>
    ///<param name="difficulty">Nuemro entero que determina el grado de dificultad "</param> 
    public void StartGame(int difficulty)
    {

        titleScreen.gameObject.SetActive(false);
        gameState = GameState.inGame;  //Estado de la partida activo


        spawnRate /= difficulty; // aumenta la dificultad de la partida reduce el tiempo spawn
        numberOfLives -= difficulty; // coloca vidas segun el nivel de la partida easy 3 mediun 2 hard  1 
        for (int i = 0; i < numberOfLives; i++) //deja solo la imagen de vida correspondiente a la dificultad
        {
            lives[i].SetActive(true);
        }
        StartCoroutine(routine: SpawnTarget());

        score = 0; // inicia la partida en 0
        UpdateScore(0);
    }
    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = UnityEngine.Random.Range(0, targetPrefabs.Count);
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

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        scoreText.text = "Maxima puntuacion\n" + maxScore;
    }
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (_score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, _score);
            //TODO:si existe nueva  puntuacion lanzar cohetes
        }
    }
    public void GameOver()
    {
        numberOfLives--;

        if (numberOfLives>=0)
        {
        Image heartImage = lives[numberOfLives].GetComponent<Image>();
        Color tempColor = heartImage.color; //Tambien se puede declarar como var
        tempColor.a=0.3f;
        heartImage.color=tempColor;
        }

        if (numberOfLives <=0)
        {
            SetMaxScore();
            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            restartButton.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}