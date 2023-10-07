using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Text scoreText;

    private GameObject[] collectables;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        collectables = GameObject.FindGameObjectsWithTag("collectable");
    }


    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " POINTS";
        
        if (score == collectables.Length) {
            SceneManager.LoadScene(2);
        }
    }
}
