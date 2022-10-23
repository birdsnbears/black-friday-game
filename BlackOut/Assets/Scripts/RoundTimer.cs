using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTimeInSeconds = 65f;
    public TMPro.TextMeshProUGUI DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            DisplayText.text = currentTime.ToString("0");
        } else
        {
            // timer has run out!
            GameOver();
        }

    }

    public void GameOver()
    {
        // TODO: replace this with something that prompts the end of the game.
        Debug.Log("Timer has run out!");
        Time.timeScale = 0;
    }
}
