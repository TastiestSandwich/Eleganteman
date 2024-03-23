using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowtieShieldController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RaiseShield()
    {
        gameObject.SetActive(true);
    }

    public void LowerShield()
    {
        gameObject.SetActive(false);
    }
}
