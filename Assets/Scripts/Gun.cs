using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject rocket;
    public float speed = 20f;
    PlayerCtrl playerctrl;
    // Start is called before the first frame update
    void Start()
    {
       playerctrl = transform.root.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(playerctrl.bFaceRight)
            {
                GameObject bulletinstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, 0));
                Rigidbody2D bi = bulletinstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(speed, 0);
            }
            else
            {
                GameObject bulletinstance = Instantiate(rocket, transform.position, Quaternion.Euler(0, 0, -180));
                Rigidbody2D bi = bulletinstance.GetComponent<Rigidbody2D>();
                bi.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
