using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed = 2;
    void Update()
    {
        transform.position += new Vector3(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
    }
}
