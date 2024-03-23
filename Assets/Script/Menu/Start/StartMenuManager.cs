using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    public TieController TieController;
    public GameObject TieFace;

    public Transform PlayPoint;
    public Transform OptionsPoint;
    public Transform ExitPoint;

    public GameObject PlayLine;
    public GameObject OptionsLine;
    public GameObject ExitLine;

    private InputReader InputReader;
    private TiePointMenuAnimation moveAnimation;

    private Vector3[] points;
    private GameObject[] lines;
    private int selectedPoint;

    // Start is called before the first frame update
    void Start()
    {
        this.InputReader = GetComponent<InputReader>();
        this.points = new Vector3[3] { PlayPoint.position, OptionsPoint.position, ExitPoint.position };
        this.lines = new GameObject[3] { PlayLine, OptionsLine, ExitLine };

        foreach(GameObject line in lines)
            line.SetActive(false);

        this.selectedPoint = 0;

        SelectPoint();
        SetFaceLocation();

        InputReader.OnMenuUp += MoveUp;
        InputReader.OnMenuDown += MoveDown;
        InputReader.OnMenuOkStarted += Accept;
    }

    private void OnDisable()
    {
        InputReader.OnMenuUp -= MoveUp;
        InputReader.OnMenuDown -= MoveDown;
        InputReader.OnMenuOkStarted -= Accept;
    }

    // Update is called once per frame
    void Update()
    {
        SetFaceLocation();
    }

    void SetFaceLocation()
    {
        Vector3 tipPosition = TieController.GetTipPosition();
        Vector3 almostTipPosition = TieController.ropeSegments[TieController.segmentLength - 3].posNow;

        TieFace.transform.position = tipPosition;
        TieFace.transform.rotation = Quaternion.LookRotation(Vector3.forward, (TieFace.transform.position - almostTipPosition));
    }

    void SelectPoint()
    {
        Vector3 newPoint = points[selectedPoint];

        moveAnimation = TieController.TieAnimator.tiePointMenuAnimation;
        moveAnimation.SetPoint(true, newPoint, TieController.ropeSegments[0].posNow);
        TieController.TieAnimator.SetAnimation(moveAnimation);

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].SetActive(i == selectedPoint);
        }
    }

    void MoveDown()
    {
        if (selectedPoint >= (points.Length - 1))
            return;

        selectedPoint += 1;
        SelectPoint();
    }

    void MoveUp()
    {
        if (selectedPoint <= 0)
            return;

        selectedPoint -= 1;
        SelectPoint();
    }

    void Accept()
    {
        switch(selectedPoint)
        {
            case 0:
                AcceptStart();
                return;
            case 1:
                AcceptOptions();
                return;
            case 2:
                AcceptExit();
                return;
            default:
                return;
        }
    }

    void AcceptStart()
    {
        SceneManager.LoadScene("TestLevel");
    }

    void AcceptOptions()
    {
        Debug.Log("Options");
    }

    void AcceptExit()
    {
        Application.Quit();
    }
}
