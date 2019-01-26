using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_ForwardsPlayerSpeed;
	[SerializeField] private float m_BackwardsPlayerSpeed;
	[SerializeField] private float m_SidewaysPlayerSpeed;
	[SerializeField] private float m_JumpPlayerSpeed;

	private bool m_ForwardPressed;
	private bool m_BackPressed;
	private bool m_RightPressed;
	private bool m_LeftPressed;
	private bool m_JumpPressed;

	private float m_GroundDistance;
	private bool m_IsGrounded;
	private Rigidbody m_Rigidbody;

	private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{

		// moving depending on the keyinput
		if (Input.GetKey(KeyCode.W))
		{
			m_ForwardPressed = true;
		}
		else
		{
			m_ForwardPressed = false;
		}
		if (Input.GetKey(KeyCode.S))
		{
			m_BackPressed = true;
		}
		else
		{
			m_BackPressed = false;
		}
		if (Input.GetKey(KeyCode.A))
		{
			m_LeftPressed = true;
		}
		else
		{
			m_LeftPressed = false;
		}
		if (Input.GetKey(KeyCode.D))
		{
			m_RightPressed = true;
		}
		else
		{
			m_RightPressed = false;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			m_JumpPressed = true;
		}
		else
		{
			m_JumpPressed = false;
		}

		if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
		{
			m_IsGrounded = true;
		}
		else
		{
			m_IsGrounded = false;
		}
	}

	private void FixedUpdate()
	{
		// moving depending on the keyinput
		if (m_ForwardPressed)
		{
			transform.Translate(Vector3.forward * m_ForwardsPlayerSpeed * Time.deltaTime);

		}
		if (m_BackPressed)
		{
			transform.Translate(Vector3.forward * -m_BackwardsPlayerSpeed * Time.deltaTime);

		}
		if (m_LeftPressed)
		{
			transform.Translate(Vector3.left * m_SidewaysPlayerSpeed * Time.deltaTime);
		}
		if (m_RightPressed)
		{
			transform.Translate(Vector3.right * m_SidewaysPlayerSpeed * Time.deltaTime);
		}
		if (m_JumpPressed && m_IsGrounded == true)
		{
			m_Rigidbody.AddForce(Vector3.up * m_JumpPlayerSpeed, ForceMode.Impulse);
		}
	}
}
