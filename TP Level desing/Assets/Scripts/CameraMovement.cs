using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour {

    private float timer;
    public GameObject playbutton;
    public GameObject restartButton;
    public GameObject ganaste;
    public GameObject perdiste;
    public static CameraMovement instance;
    public Text text;
    private int poinsts;

    private void Start()
    {
        instance = this;
        poinsts = 0;
        playbutton.SetActive(true);
        ganaste.SetActive(false);
        perdiste.SetActive(false);
        restartButton.SetActive(false);
        Time.timeScale = 0;
        timer = 0;
        text.text = "Points: " + poinsts;
    }
    void LateUpdate()
    {
        if (timer < Modifiers.initialTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * Modifiers.cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playbutton.activeSelf) { Play(); }
            if (restartButton.activeSelf) { Restart(); }
        }
    }
    public void Play()
    {
        Time.timeScale = 1;
        playbutton.SetActive(false);
        restartButton.SetActive(false);
        ganaste.SetActive(false);
        perdiste.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1;
        restartButton.SetActive(false);
        playbutton.SetActive(false);
        ganaste.SetActive(false);
        perdiste.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Ganaste()
    {
        restartButton.SetActive(true);
        ganaste.SetActive(true);
        Time.timeScale = 0;
    }
    public void Perder()
    {
        restartButton.SetActive(true);
        perdiste.SetActive(true);
        Time.timeScale = 0;
    }
    public void Points(int p)
    {
        poinsts += p;
        text.text = "Points: " + poinsts;
    }

}
