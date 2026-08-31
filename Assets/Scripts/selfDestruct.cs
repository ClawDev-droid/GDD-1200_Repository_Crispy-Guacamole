using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public float lifetime = 1;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

   
}
