using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform[] _sensors;
    [SerializeField] private LayerMask _groundCheckLayerMask;

    [SerializeField] private float _groundCheckDistance = 0.2f;
    [SerializeField] private Color _groundHit;
    [SerializeField] private Color _groundMiss;

    public bool OnGround { get; private set; }
    public float Friction { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = RaycastFromAllSensors();
    }

    private bool RaycastFromAllSensors()
    {
        foreach (var sensor in _sensors)
        {
            if (RaycastFromSensor(sensor)) return true;
        }

        return false;
    }
    
    private bool RaycastFromSensor(Transform sensor)
    {
        RaycastHit2D hit;
        var position = sensor.position;
        var forward = sensor.forward;
        hit = Physics2D.Raycast(position, forward, _groundCheckDistance, _groundCheckLayerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(position, forward * _groundCheckDistance, _groundHit);
            Friction = hit.collider.friction;
            return true;
        }
        else
        {
            Debug.DrawRay(position, forward * _groundCheckDistance, _groundMiss);
        }
        return false;
    }
}
