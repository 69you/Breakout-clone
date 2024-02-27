using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class Player : MonoBehaviour {
    public float speedX = 18f;
    Rigidbody2D rb;
    public TextMeshProUGUI ScoreText;
    bool pause = false;

    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.R)) RestartGame();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            ScoreText.gameObject.SetActive(pause);
            Time.timeScale = pause ? 0f : 1f;
            ScoreText.text = pause ? "PAUSE" : "";
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -6f, 6f);
        rb.MovePosition(mousePosition);
    }

    void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}