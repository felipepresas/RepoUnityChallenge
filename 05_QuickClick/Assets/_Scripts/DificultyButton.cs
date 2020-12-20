using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DificultyButton : MonoBehaviour
{
   private Button _button;
   private GameManager gameManager;
   public int difficulty;
    void Start()
    {
        _button=GetComponent<Button>();
        _button.onClick.AddListener(SetDificulty);
        gameManager=FindObjectOfType<GameManager>();
    }

    void SetDificulty()
    {
        gameManager.StartGame(difficulty);
        //Debug.Log("El boton"+gameObject.name+"fue pulsado");
    }
}
