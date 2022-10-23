using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetDealSpawner : MonoBehaviour
{
    public SweetDeal SweetDealPrefab;
    public Sprite[] SweetDealSprites;
    public float spawnRateInSeconds = 1f;

    [SerializeField]
    float _spawnHeight = 3f;
    [SerializeField]
    float _spawnLeftBound = -15f;
    [SerializeField]
    float _spawnWidth = 30f;

    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed >= spawnRateInSeconds)
        {
            timeElapsed -= spawnRateInSeconds;
            _spawn();
        }
    }

    void _spawn()
    {
        Sprite randomSweetDealSprite = _getRandomSweetDealSprite();
        SweetDealPrefab.InitializeSprite(randomSweetDealSprite);
        Instantiate(SweetDealPrefab, _generateSpawnPosition(), Quaternion.identity).GetComponent<SweetDeal>();
    }

    Sprite _getRandomSweetDealSprite()
    {
        if(SweetDealSprites.Length < 1)
        {
            return null;
        }
        int randIndex = Random.Range(0, SweetDealSprites.Length - 1);
        return SweetDealSprites[randIndex];
    }

    Vector3 _generateSpawnPosition ()
    {
        return new Vector3(Random.Range(_spawnLeftBound, _spawnLeftBound + _spawnWidth), _spawnHeight, 0);

    }


}
