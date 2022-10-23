using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _score;
    private List<SweetDeal> sweetDealTracker = new List<SweetDeal>();

    public Transform DropLocation;
    public TMPro.TextMeshProUGUI ScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            // deduct from score
            _score--;
            ScoreDisplay.text = $"{_score}";
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
