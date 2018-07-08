using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum gameState
{
    MainMenu, GameStarted, GameOver 
};
public class GameManager : MonoBehaviour {

    public static GameManager shared;

    [SerializeField] private GameObject player;
    [SerializeField] private Camera startMenuCamera;
    [SerializeField] private SpawnWave spawnWave;
    [SerializeField] private SpawnerIdle spawnerIdle;

    private Health playerHealth;
    private gameState GameState;
    private bool isPlayerDead = false;
    private Coroutine idlePlayerMenu;

	// Use this for initialization
	void Start () {

        if (shared == null)
            shared = this;
        else if (shared != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        playerHealth = player.GetComponent<Health>();
        GameState = gameState.MainMenu;
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.touches[0].phase == TouchPhase.Began && GameState == gameState.MainMenu)
            startGame();
	}

    private void gameStateListener()
    {
        if(GameState == gameState.MainMenu)
        {
            
        }
    }

    private void idlePlayer()
    {
        Animator anim = player.GetComponent<Animator>();

    }

    IEnumerator idlePlayerAnim()
    {
        yield return null;
    }

    private void startGame()
    {
        GameState = gameState.GameStarted;
        startMenuCamera.enabled = false;
        Camera.main.enabled = true;
        spawnWave.enabled = true;
    }

    public void gameOver()
    {
        GameState = gameState.GameOver;
    }
}
