using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefferedPlayerInput : PlayerInput
{
    internal override void Reset()
    {
        m_CharacterController = transform.GetComponent<CharacterControllerBase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
