using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundCheck))]
public class EnemyController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public GroundCheck Ground;

    public int Facing { get; private set; }
    
    void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.Ground = GetComponent<GroundCheck>();
        this.Facing = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void Flip()
    {
        this.Facing = -1 * Facing;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
