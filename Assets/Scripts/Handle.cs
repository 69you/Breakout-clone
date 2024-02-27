using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Handle : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Time.timeScale = 0;
        ScoreText.gameObject.SetActive(true);
        ScoreText.text = $"Score: {Nerd.score}\nTime: {Time.time}s\nLevel: {Bricks.level-8}";
    }
}
