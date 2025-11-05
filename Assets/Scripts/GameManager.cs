using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Objects")]
    public Camera mainCamera;
    public Level level;
    [Header("Prefabs")]
    public Controller playerControllerPrefab;
    public Pawn playerPawn;
    [Header("Game Data")]
    public AnimationCurve healthDifficultyCurve;
    public AnimationCurve damageDifficultyCurve;
    public float maxEnemyHealth;
    public float minEnemyHealth;
    public int currentLevel;
    public float maxLevels;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float EnemyHealthBasedOnDifficulty ( float level )
    {
        float levelPercent = currentLevel / maxLevels;
        float difficultyPercent = healthDifficultyCurve.Evaluate( levelPercent );

        float healthRange = maxEnemyHealth - minEnemyHealth;
        float healthAboveMinimum = difficultyPercent * healthRange;

        return minEnemyHealth + healthAboveMinimum;
    }

}
