using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIRotate : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed = 1;
    float targetPosX;

    void Start()
    {
        targetPosX = Random.Range(0, 5);
    }
    void FixedUpdate()
    {
        if (!this.gameObject.GetComponent<BaseCharacter>().isPause)
        {
            Vector3 targetDirection = new Vector3(targetPosX, 0, 0);
            transform.Rotate(targetDirection);
        }
    }

    public void SetPos()
    {
        targetPosX = Random.Range(0, 5);
    }
}
