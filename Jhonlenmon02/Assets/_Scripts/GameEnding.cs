using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float faithDuration = 1f;
    public float displayImageDuration;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBacgrountImagecanvasGroup;
    private bool isPlayerAtExit, isPlayerCaught;
    private float timer;
    public GameObject player;
    public AudioSource exitAudio, caughtAudio;
    private bool hasAudioPlayed;

    /// <summary>
    /// OnTriggerEnter es llamado cuando otro collider entra en el trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, doRestart: false,exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBacgrountImagecanvasGroup, doRestart: true,caughtAudio);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSourse)
    {

        if (!hasAudioPlayed)
        {
            hasAudioPlayed=true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / faithDuration;
        if (timer > faithDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Application.Quit();
            }
        }

    }
    public void CatchPlayer()
    {
        isPlayerCaught=true;
    }
}
