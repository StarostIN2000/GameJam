using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefferedPlayerInput : MonoBehaviour
{
    [SerializeField] PlayerInput m_PlayerInput = null;
    [SerializeField] PlayerInput m_realPlayerInput = null;

    [SerializeField] string m_InputOverrideNameJump = "";

    [SerializeField] string m_InputOverrideNameDir = "";
    [SerializeField] int m_recordTime = 3;
    Vector2 m_Direction = Vector2.zero;   
    
    bool[] m_Button;
    Vector2[] m_Direct;

    int iter = 0;
    bool isGet = false;
    bool isSet = false;
    bool isReady = false;

    public void GuiButtonDown()
    {
        m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, true);
    }
    public void GuiButtonUp()
    {
        m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, false);
    }
    

    void Start()
    {
        m_PlayerInput.GetDirectionInput(m_InputOverrideNameDir).SetOverride(true, Vector2.zero);
        m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, false);

        m_Button = new bool[m_recordTime * 50];
        m_Direct = new Vector2[m_recordTime * 50];

    }

    private void FixedUpdate()
    {       
        if (isGet && iter < m_Button.Length) {
            m_Button[iter] = m_realPlayerInput.GetButton("Jump").m_IsPressed;
            m_Direct[iter] = m_realPlayerInput.GetDirectionInput("Move").m_RawInput;
            iter++;
            return;
        }
        if (isSet && iter < m_Button.Length)
        {
            m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, m_Button[iter]);
            m_PlayerInput.GetDirectionInput(m_InputOverrideNameDir).SetOverride(true, m_Direct[iter]);
            iter++;
            return;
            
        }
        isReady = true;
    }

    public void Record()
    {
        if (!isReady) { return; }
        iter = 0;
        isGet = true;
        isSet = false;
        isReady = false;
    }
    public void Replay()
    {
        if (!isReady) { return; }
        iter = 0;
        isGet = false;
        isSet = true;
        isReady = false;
    }
}
