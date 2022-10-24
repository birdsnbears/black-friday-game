using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get { return _score; } }
    private int _score;
    private List<SweetDeal> sweetDealTracker = new List<SweetDeal>();

    public Transform DropLocation;
    public TMPro.TextMeshProUGUI ScoreDisplay;
    public float VerticalDropForce;

    // for tie management
    public MatchController matchController;
    public RoundTimer roundTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        _score = 0;
        ScoreDisplay.text = $"{_score}";
        sweetDealTracker.Clear();
    }

    public void AddSweetDeal(SweetDeal theDeal)
    {
        // add to score
        _score++;
        ScoreDisplay.text = $"{_score}";
        // disable the deal
        theDeal.gameObject.SetActive(false);
        // store sweetDeal into tracker
        sweetDealTracker.Add(theDeal);

        // In case of tie...
        if (matchController.IsTieBreak)
        {
            roundTimer.StartTimer();
        }
    }

    public void DropSweetDeal()
    {
        if(sweetDealTracker.Count > 0)
        {
            // remove sweetDeal from Tracker
            SweetDeal victim = sweetDealTracker[0];
            sweetDealTracker.RemoveAt(0);
            // relocate the deal
            victim.transform.position = DropLocation.position;
            // renable the deal
            victim.gameObject.SetActive(true);
            // shoot the deal
            victim.GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(0, 6) - 3f, VerticalDropForce);
            // deduct from score
            _score--;
            ScoreDisplay.text = $"{_score}";

            // In case of tie...
            if (matchController.IsTieBreak)
            {
                roundTimer.ResetForTie();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SweetDeal potentialScore = collision.transform.GetComponent<SweetDeal>();
        if (potentialScore)
        {
            AddSweetDeal(potentialScore);
        }
    }
}
