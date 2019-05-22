using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
