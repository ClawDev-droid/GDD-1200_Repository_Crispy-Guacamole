using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{

    public GameObject target;
    public Canvas _Canvas;
    public Slider SliderBar;
    public CollidableController CollCont;
    public Camera PlayerCam; 
    public float _health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log(gameObject.name + " Has Arrived");
    }
    void Start()
    {
        //_health = CollCont.MaxHealth;
        
         // assign health to the Health Script
        
        
        // set sider max to max health 
        SliderBar.maxValue = _health;
        PlayerCam = GameObject.FindWithTag("Camera").GetComponent<Camera>();
        _Canvas.worldCamera = PlayerCam;    
    }

    // Update is called once per frame
    
 

   
    private void Update()
    {
        
        SliderBar.value = (CollCont.GetCurrentHealth());
    }
}
