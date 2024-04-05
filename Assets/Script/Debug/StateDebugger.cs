using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateDebugger : MonoBehaviour
{
    public StateMachine stateMachine;
    public TMPro.TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentScale = this.transform.parent.localScale;
        Vector3 localScale = this.transform.localScale;
        if (parentScale.x * localScale.x < 0)
        {
            localScale.x *= -1;
            this.transform.localScale = localScale;
        } 
        this.textBox.text = this.stateMachine.stateName;
    }
}
