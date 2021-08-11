using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    float force = 4f;
    public float pivot;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.name == "Player" || collision.transform.root.name == "IICharacter")
        {
            Rigidbody character = collision.transform.root.gameObject.GetComponent<Rigidbody>();

            if (character.GetComponent<BaseCharacter>().flying == false)
            {
                character.velocity = Vector3.zero;
                character.AddForce(((this.transform.up * force) + (new Vector3(pivot, 0, 0) * force / 6)), ForceMode.Impulse);
            }
            character.GetComponent<BaseCharacter>().flying = true;

            // Kri
            if (collision.transform.root.name == "IICharacter")
            {
                collision.transform.root.gameObject.GetComponent<IIRotate>().SetPos();
            }
            //

            character.GetComponent<BaseCharacter>().flying = true;
            character.GetComponent<BaseCharacter>().CC.enabled = false;
            character.GetComponent<BaseCharacter>().isHit = false;
           // character.GetComponent<BaseCharacter>().startFight();
        }


    }
}