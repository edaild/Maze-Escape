using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Payer : MonoBehaviour
{
    public float Speed;
    float Hinput;
    float Vinput;

    Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Inputget();
        Move();
        Turn();
    }
    void Inputget()
    {
        Hinput = Input.GetAxisRaw("Horizontal");
        Vinput = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        moveVec = new Vector3(Hinput, 0, Vinput).normalized;

        transform.position += moveVec * Speed * Time.deltaTime ;

    }
    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "trick cube")
        {
            print("함정 입니다.");
        }

        if(collision.gameObject.tag =="Finish")
        {
           gameObject.SetActive(false);
            print("Finish");
        }
    }
}
