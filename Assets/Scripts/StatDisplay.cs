using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    public GameManager _GameManager;
    public Canvas _Canvas;
    public TextMeshProUGUI _ScoreText;
    //public Slider SliderBar;
    public CollidableController CollCont;
    public ScoreTracker _ScoreTracker;
    public Camera PlayerCam; 
    public string ScoreDisplayText = "Score: ";
    public bool FindCam = false;
    public bool FindScore = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if ((PlayerCam == null) && FindCam == true)
        {
            PlayerCam = GameObject.FindWithTag("Camera").GetComponent<Camera>();
        }
        if (_ScoreTracker == null && FindScore == true)
        {
            _ScoreTracker = GameObject.FindWithTag("GameManager").GetComponent<ScoreTracker>();
        }
        
        _Canvas.worldCamera = PlayerCam;



    }

    // Update is called once per frame
    void Update()
    {
        string _score = _ScoreTracker.Score.ToString();
        var _ScoreDisplayText = ScoreDisplayText + _score;
        _ScoreText.text = _ScoreDisplayText;
    }
}
