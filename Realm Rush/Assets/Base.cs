using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{

    [SerializeField] int baseHealth = 5;
    public int score = 0;
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = baseHealth.ToString();
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeALife()
    {
        baseHealth--;
        if (baseHealth == 0)
        {
            //ToDo end of game
        }
        healthText.text = baseHealth.ToString();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();

    }
}
