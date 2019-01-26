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
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            //pc.TakeDamage();
        }
        if(collision.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
