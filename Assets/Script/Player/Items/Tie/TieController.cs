using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TieController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public LineRenderer outlineRend;
    public Transform targetDir;
    public TieAnimator TieAnimator;
    public TipObjectController FaceController;
    public int Facing = 1;

    public List<RopeSegment> ropeSegments = new List<RopeSegment>();
    public float ropeSegLen = 0.1f;
    public float defaultRopeSegLen = 0.1f;
    public int segmentLength = 10;
    public float drag = 0.1f;
    public float gravity = -2;

    //TODO have a boolean for length calculation mode -> either fixed or cooldown based.
    private bool isFixedLengthMode = false;
    public float tieCooldownPercentage = 1;
    public float tieCooldownRecovery = 0.01f;
    public float maxCooldownPercentage = 1;

    public float[] baseColor = { 0.014f, 0.78f, 0.91f };

    void Awake()
    {
        this.TieAnimator = GetComponent<TieAnimator>();
        Vector3 ropeStartPoint = targetDir.position;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.DrawRope();
        this.TieAnimator.AdvanceAnimTime(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        this.RecoverCooldown();
        this.CalculateRopeLength();
        this.Simulate();
    }

    private void Simulate()
    {
        // SIMULATION
        Vector3 forceGravity = new Vector3(0f, gravity, 0f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity * (1 - drag);
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        //Constraint to Neck
        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = targetDir.position;
        this.ropeSegments[0] = firstSegment;

        //Animation Constraints
        this.ropeSegments = TieAnimator.SetAnimationConstraints(this.ropeSegments, this.ropeSegLen);

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = dist - ropeSegLen;
            Vector3 changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            Vector3 changeAmount = changeDir * error;

            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        outlineRend.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
        outlineRend.SetPositions(ropePositions);
    }

    public void ResetTieLocation()
    {
        TieAnimator.SetAnimation(null);
        Vector3 ropeStartPoint = targetDir.position;

        for (int i = 0; i < segmentLength; i++)
        {
            RopeSegment segment = new RopeSegment(ropeStartPoint);
            ropeSegments[i] = segment;
            ropeStartPoint.y -= ropeSegLen;
        }
    }

    public void Flip()
    {
        this.Facing = -1 * Facing;
    }

    public Vector3 GetTipPosition()
    {
        return ropeSegments[segmentLength - 1].posNow;
    }

    public void ChangeHealthIndicator(int currentHealth, int maxHealth)
    {
        float percent = baseColor[1] * currentHealth / maxHealth;
        Debug.Log("The percent is " + percent);
        Color color = Color.HSVToRGB(baseColor[0], percent, baseColor[2]);
        ChangeColor(color);
    }

    public void ChangeColor(Color color)
    {
        Debug.Log("Changing color");
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    private void CalculateRopeLength()
    {
        if(!this.isFixedLengthMode)
        {
            this.ropeSegLen = defaultRopeSegLen * tieCooldownPercentage;
        }
    }

    public void SetFixedTieLength(float tieLength)
    {
        this.isFixedLengthMode = true;
        this.ropeSegLen = tieLength;
    }

    public void DisableFixedLength()
    {
        this.isFixedLengthMode = false;
    }

    private void RecoverCooldown()
    {
        this.tieCooldownPercentage += tieCooldownRecovery * Time.fixedDeltaTime;
        if (tieCooldownPercentage >= maxCooldownPercentage)
        {
            this.tieCooldownPercentage = maxCooldownPercentage;
        }
    }

    public void ConsumeCooldown()
    {
        this.tieCooldownPercentage = 0;
    }

    public bool isAtMaxCooldown()
    {
        return this.tieCooldownPercentage >= maxCooldownPercentage;
    }
}

public struct RopeSegment
{
    public Vector3 posNow;
    public Vector3 posOld;

    public RopeSegment(Vector3 pos)
    {
        this.posNow = pos;
        this.posOld = pos;
    }
}
