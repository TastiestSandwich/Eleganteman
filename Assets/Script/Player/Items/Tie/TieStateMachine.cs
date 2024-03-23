using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieStateMachine : StateMachine
{
    public TieController TieController { get; private set; }
    public InputReader InputReader { get; private set; }
    public PlayerAbilities PlayerAbilities;

    public bool drawGrabRadius = false;
    public Grabbed? grabbed = null;
    public float desiredLength;

    public List<GizmoCircle> gizmoCircles = new();

    void Start()
    {
        this.TieController = GetComponent<TieController>();
        this.InputReader = GetComponent<InputReader>();

        SwitchState(new TieIdleState(this));
    }

    private void OnDrawGizmosSelected()
    {
        if (drawGrabRadius)
        {
            /*
            Gizmos.color = Color.blue;
            Vector3 tipPosition = TieController.ropeSegments[TieController.ropeSegments.Count - 1].posNow;
            Gizmos.DrawSphere(tipPosition, PlayerAbilities.tieGrabAbility.grabObjectRadius);
            */
            foreach(GizmoCircle circle in gizmoCircles)
            {
                Gizmos.color = circle.color;
                Gizmos.DrawSphere(circle.position, circle.radius);
            }
        }
    }

    public struct Grabbed
    {
        public Transform transform;
        public Vector3 offset;

        public Grabbed(Transform transform, Vector3 offset)
        {
            this.transform = transform;
            this.offset = offset;
        }
    }

    public struct GizmoCircle
    {
        public GizmoCircle(Vector3 position, float radius, Color color)
        {
            this.position = position;
            this.radius = radius;
            this.color = color;
        }
        public Vector3 position;
        public float radius;
        public Color color;
    }

    public void EnableGizmoCircles()
    {
        this.gizmoCircles = new();
        this.drawGrabRadius = true;
    }

    public void AddGizmoCircle(Vector3 position, float radius, Color color)
    {
        GizmoCircle circle = new GizmoCircle(position, radius, color);
        gizmoCircles.Add(circle);
    }
}
