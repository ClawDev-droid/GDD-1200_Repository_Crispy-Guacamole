using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    private float PlayerHP;
    public Health PlayerHealthManager;
    private Scene CurrentScene;
    private Scene GameScene;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
        }
    }
}
