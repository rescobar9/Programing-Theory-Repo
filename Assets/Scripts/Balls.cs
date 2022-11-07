using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Specialized;

public class Balls : MonoBehaviour
{
    public Vector3 startForce;
    [SerializeField] private float m_MovePower = 5;
    [SerializeField] private bool m_UseTorque = true;
    [SerializeField] private float m_MaxAngularVelocity = 25;
    [SerializeField] private float m_JumpPower = 2;

    private const float k_GroundRayLength = 1f;
    private Rigidbody m_Rigidbody;
    

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
        GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 moveDirection, bool jump)
    {
        if (m_UseTorque)
        {
            m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x) * m_MovePower);
        }
        else
        {
            m_Rigidbody.AddForce(moveDirection * m_MovePower);
        }

        if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
        {
            m_Rigidbody.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
        }
    }

    
}
