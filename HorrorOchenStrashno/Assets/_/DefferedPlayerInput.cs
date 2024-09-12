using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefferedPlayerInput : MonoBehaviour
{
    PlayerInput m_PlayerInput = null;
    PlayerInput m_realPlayerInput = null;
    CloneSpawner m_spawner;

    string m_InputOverrideNameJump = "Jump";
    string m_InputOverrideNameDir = "Move";

    [SerializeField] int m_recordTime = 3;  
    [SerializeField] int m_beforeDeathTime = 3;

    [SerializeField] GameObject m_deathEffect;
    [SerializeField] Image m_image;

    bool[] m_Button;
    Vector2[] m_Direct;

    int iter = 0;
    int tickTime = 0;

    liveState currentState;
    
    enum liveState
    {
        waitToRecord,
        record,
        waitToReplay,
        replay,
        waitToDie
    }

    void Start()
    {
        m_realPlayerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
        m_PlayerInput = gameObject.GetComponent<PlayerInput>();
        m_spawner = m_realPlayerInput.GetComponent<CloneSpawner>();
        m_image = GameObject.Find("TimeBar_rec").GetComponent<Image>();
        

        m_PlayerInput.GetDirectionInput(m_InputOverrideNameDir).SetOverride(true, Vector2.zero);
        m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, false);

        tickTime = m_recordTime * 50;
        m_Button = new bool[tickTime];
        m_Direct = new Vector2[tickTime];

        currentState = liveState.waitToRecord;
        FillImage(1);

        var inst = Instantiate(m_deathEffect, transform.position, Quaternion.identity);
        Destroy(inst, 3);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentState == liveState.waitToRecord)
            {
                StartRecord();
            }
            else if (currentState == liveState.waitToReplay)
            {
                StartReplay();
            }
        }
    }
    private void FixedUpdate()
    {
        
        if (currentState == liveState.record) {
            m_Button[iter] = m_realPlayerInput.GetButton("Jump").m_IsPressed;
            m_Direct[iter] = m_realPlayerInput.GetDirectionInput("Move").m_RawInput;
            FillImage(1 - (float)iter / tickTime);
            iter++;
            if (iter == tickTime)
            {
                currentState = liveState.waitToReplay;
                FillImage(1);
                Debug.Log("end record");
            }
        }
        if (currentState == liveState.replay)
        {
            m_PlayerInput.GetButton(m_InputOverrideNameJump).SetOverride(true, m_Button[iter]);
            m_PlayerInput.GetDirectionInput(m_InputOverrideNameDir).SetOverride(true, m_Direct[iter]);
            FillImage(1 - (float)iter / tickTime);
            iter++;
            if(iter == tickTime)
            {
                currentState = liveState.waitToDie;
                FillImage(1);
                StartCoroutine(Die());
                Debug.Log("end replay");
            }
        }
    }

    public void StartRecord()
    {
        iter = 0;
        currentState = liveState.record;
        
        Debug.Log("start record");
    }
    public void StartReplay()
    {
        iter = 0;
        currentState = liveState.replay;
        
        Debug.Log("start replay");
    }

    void FillImage(float i)
    {
        m_image.fillAmount = i;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(m_beforeDeathTime);
        
        m_spawner.KillClone();

        FillImage(1);

        var inst = Instantiate(m_deathEffect, transform.position, Quaternion.identity);
        Destroy(inst, 3);

        Destroy(gameObject);
    }
}
