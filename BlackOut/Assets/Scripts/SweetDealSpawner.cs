using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetDealSpawner : MonoBehaviour
{
    public SweetDeal SweetDealPrefab;
    public Sprite[] SweetDealSprites;
    public float spawnRateInSeconds;

    [SerializeField]
    float _spawnHeight;
    [SerializeField]
    float _spawnLeftBound;
    [SerializeField]
    float _spawnWidth;

    private bool isPaused = false;
    private float timeElapsed = 0f;
    private List<SweetDeal> spawnedSweetDeals;

    // Start is called before the first frame update
    void Start()
    {
        spawnedSweetDeals = new List<SweetDeal>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused == false)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > spawnRateInSeconds)
            {
                timeElapsed -= spawnRateInSeconds;
                _spawn();
            }
        }
    }

    void _spawn()
    {
        Sprite randomSweetDealSprite = _getRandomSweetDealSprite();
        SweetDealPrefab.InitializeSprite(randomSweetDealSprite);
        SweetDeal victim = Instantiate(SweetDealPrefab, _generateSpawnPosition(), Quaternion.identity).GetComponent<SweetDeal>();
        spawnedSweetDeals.Add(victim);
    }

    Sprite _getRandomSweetDealSprite()
    {
        if(SweetDealSprites.Length < 1)
        {
            return null;
        }
        int randIndex = Random.Range(0, SweetDealSprites.Length);
        return SweetDealSprites[randIndex];
    }

    Vector3 _generateSpawnPosition ()
    {
        return new Vector3(Random.Range(_spawnLeftBound, _spawnLeftBound + _spawnWidth), _spawnHeight, 0);

    }

    public void SetupTieBreak()
    {
        // delete all previously spawned SweetDeals
        foreach(SweetDeal sweetdeal in spawnedSweetDeals)
        {
            Destroy(sweetdeal.gameObject);
        }
        spawnedSweetDeals.Clear();
        // make sure only one new sweet deal spawns
        isPaused = true;
        // below was copy pasted from _spawn. But I replaced the spawn position with a preset coordinate
        Sprite randomSweetDealSprite = _getRandomSweetDealSprite();
        SweetDealPrefab.InitializeSprite(randomSweetDealSprite);
        Instantiate(SweetDealPrefab, new Vector3(0, _spawnHeight, 0), Quaternion.identity).GetComponent<SweetDeal>();
    }
}
