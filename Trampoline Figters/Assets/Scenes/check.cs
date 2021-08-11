using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Collider myCollider = collision.contacts[0].thisCollider;
        collision.transform.root.gameObject.GetComponent<check>().checkName(myCollider.name);
    }

    public void checkName(string name)
    {
        Debug.Log(name);
    }
}
