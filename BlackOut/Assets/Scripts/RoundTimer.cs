using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTimer : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTimeInSeconds = 65f;
    public TMPro.TextMeshProUGUI DisplayText;
    public MatchController matchController;

    [SerializeField]
    float TieTimeAmount;

    bool TimerPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTimeInSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if(!TimerPaused && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            DisplayText.text = currentTime.ToString("0");
        } else
        {
            if (!TimerPaused)
            {
                matchController.GameOver();
            }
        }

    }

    public void StartTimer()
    {
        TimerPaused = false;
    }

    public void ResetForTie()
    {
        currentTime = TieTimeAmount;
        DisplayText.text = currentTime.ToString("0");
        TimerPaused = true;
    }
}
