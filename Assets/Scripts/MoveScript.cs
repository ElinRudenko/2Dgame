using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    //[SerializeField]
    private float speed = 2.5f;

    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
