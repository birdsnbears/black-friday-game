using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    public bool IsTieBreak { get { return _isTieBreak; } }
    bool _isTieBreak = false;
    public RoundTimer timer;
    public PlayerScore Player1;
    public PlayerScore Player2;
    public SweetDealSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        if(Player1.Score == Player2.Score)
        {
            // there is a tie
            Tie();
        } else
        {
            Time.timeScale = 0f;
            if(Player1.Score > Player2.Score)
            {
                // Player 1 won
                // transition to Game Over Screen
            } else
            {
                // Player 2 won
                // transition to Game Over Screen
            }
        }
    }

    private void Tie()
    {
        _isTieBreak = true;
        Player1.ResetScore();
        Player2.ResetScore();
        spawner.SetupTieBreak();
        timer.ResetForTie();
    }
}
