using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieStateMachine : StateMachine
{
    public TieController TieController { get; private set; }
    public InputReader InputReader { get; private set; }
    public PlayerAbilities PlayerAbilities;

    public bool drawGrabRadius = true;
    public Grabbed? grabbed = null;
    public float desiredLength;

    public List<GizmoCircle> gizmoCircles = new();
    public GizmoBox? gizmoBox = null;

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
            
            Gizmos.color = Color.blue;
            Vector3 tipPosition = TieController.ropeSegments[TieController.ropeSegments.Count - 1].posNow;
            Gizmos.DrawSphere(tipPosition, (tipPosition - TieController.transform.position).magnitude * Mathf.Tan(PlayerAbilities.tieGrabAbility.grabObjectAngle / 2));
            
            foreach(GizmoCircle circle in gizmoCircles)
            {
                Gizmos.color = circle.color;
                Gizmos.DrawSphere(circle.position, circle.radius);
            }
        }

        if (gizmoBox.HasValue)
        {
            GizmoBox box = gizmoBox.Value;
            Gizmos.color = Color.green;
            Gizmos.DrawCube(box.position, box.size);
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

    public struct GizmoBox
    {
        public GizmoBox(Vector3 position, Vector3 size)
        {
            this.position = position;
            this.size = size;
        }
        public Vector3 position;
        public Vector3 size;
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

    public void SetGizmoBox(Vector2 position, Vector2 size)
    {
        this.gizmoBox = new GizmoBox(position, size);
    }

    public void EraseGizmoBox()
    {
        this.gizmoBox = null;
    }
}
