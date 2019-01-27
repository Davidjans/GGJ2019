using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    private Vector3 m_Direction;

    public void SetDirection(Vector3 dir)
    {
        m_Direction = dir;
    }

    private void Update()
    {
        transform.position += m_Direction.normalized * Time.deltaTime * 10f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerManager pc = collision.gameObject.GetComponent<PlayerManager>();
            pc.TakeDamage(20);
        }
        else if(collision.gameObject.tag == "Door")
        {
            DoorHealth dh = collision.gameObject.GetComponent<DoorHealth>();
            dh.TakeDamage(10);
        }
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
