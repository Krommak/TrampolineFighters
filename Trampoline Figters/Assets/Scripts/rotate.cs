using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float y;
    void FixedUpdate()
    {
        transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0, y, 0), 0.1f);
    }
}
