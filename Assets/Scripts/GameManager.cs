using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    private float PlayerHP;
    private bool hasWon = false;
    public Health PlayerHealthManager;
    public PlayerTrigger WinConCheck;
    private Scene CurrentScene;
    public Scene GameScene;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Player = GameObject.FindWithTag("Player");
        PlayerHealthManager = Player.GetComponent<Health>();
        WinConCheck = Player.GetComponent<PlayerTrigger>();
        GameScene = SceneManager.GetActiveScene();
    }
    
    private void Update()
    {
        checkscene();
    }
    
    private void checkscene()
    {
        CurrentScene = SceneManager.GetActiveScene();
        if (CurrentScene == GameScene)
        {
            PlayerHP = PlayerHealthManager._currentHealth;
        //Debug.Log(PlayerHP);
            if(PlayerHP <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            hasWon = WinConCheck.hasWon;
            if(hasWon == true)
            {
                SceneManager.LoadScene("Win");
            }
        }
    }
}
