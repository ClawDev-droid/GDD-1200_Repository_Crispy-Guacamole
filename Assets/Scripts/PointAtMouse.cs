using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
public class PointAtMouse : MonoBehaviour
{
    public Camera _Camera;
    public Transform Parent;
    public float maxAngleRight = 90;
    public float maxAngleLeft = 90;
    //public Transform _transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_Camera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current != null)
        {

            _pointAtMouse();
            
            //Vector2 mousePos = _Camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            
            
            
            
            
            
                   
            
    }
    void _pointAtMouse()
    {
        Ray _Ray = _Camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane _RelPlane = new Plane(Vector3.forward, transform.position);
        if (_RelPlane.Raycast(_Ray, out float rayDistance))
        {
            // get angle of mouse and convert to degrees
            Vector3 _target = _Ray.GetPoint(rayDistance) ; 
            Vector3 _transform = transform.position;
            Vector3 dir = _transform - _target;
            //Debug.Log(Parent.localEulerAngles);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) ;
             // Subtract 90 degrees to align with the sprite's forward direction
            //Debug.Log (angle);
            /*if (angle > 180)
                {
                    angle = 180;
                }
            if (angle < -180)
                {
                    angle = -180;
                }*/

            float ParentMod = Parent.localEulerAngles.z%360;
            if (Parent.localEulerAngles.z%360 > 90)
                {
                    ParentMod = ParentMod - 360;
                }
                
            if((angle - ParentMod) > 90 )
                {
                    angle -= 360;
                    //Debug.Log("1");
                }
                
                
            //Debug.Log (angle+  ", " + ParentMod+ ", " + (angle - ParentMod) + ", R" + (-90 - maxAngleRight) + ", L" + (-90 - maxAngleLeft));  
            
            if (angle - ParentMod < -90 - maxAngleRight)
                {
                    //angle = maxAngleRight - 90 ;
                    transform.localEulerAngles = new Vector3(0, 0, -maxAngleRight) ;
                }
                else
                {
                    if (angle - ParentMod > -90 + maxAngleLeft)
                    {
                        
                        transform.localEulerAngles = new Vector3(0, 0, maxAngleLeft) ;
                    }
                        else
                        {
                        
                        transform.localEulerAngles = new Vector3(0, 0, angle + 90) - Parent.localEulerAngles;
                        }
                }
        
            //Debug.Log(angle);
        }
        }
    }
}
