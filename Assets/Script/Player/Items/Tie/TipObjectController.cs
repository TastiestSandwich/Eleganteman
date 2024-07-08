using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipObjectController : MonoBehaviour
{
    public TieController TieController;

    public int rotationOffset = 3;
    public int faceTipOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetLocation();
    }

    void SetLocation()
    {
        Vector3 facePosition = TieController.ropeSegments[TieController.segmentLength - faceTipOffset].posNow;
        Vector3 almostTipPosition = TieController.ropeSegments[TieController.segmentLength - rotationOffset].posNow;

        this.transform.position = facePosition;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, (this.transform.position - almostTipPosition));
    }

    public void toggle(bool enabled)
    {
        this.gameObject.SetActive(enabled);
    }
}
