using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewLevel : MonoBehaviour
{
    [SerializeField] GameObject iiCharacter, iiRagdoll;
    [SerializeField] Transform iiPos, playerPos;
    public void StartNewLevel(GameObject[] tramps, GameObject player)
    {
        foreach (GameObject tramp in tramps)
        {
            StartCoroutine(TramplineDown(tramp));
        }
        StartCoroutine(BackToStartPosition(iiCharacter, iiRagdoll, iiPos, player, playerPos));
    }

    private IEnumerator TramplineDown(GameObject tramp)
    {
        float trampStartPosZ = tramp.transform.position.z;
        float trampStartPosY = tramp.transform.position.y;
        tramp.transform.DOLocalMoveZ(tramp.transform.position.z -10f, 1f).SetEase(Ease.InOutBack);
        yield return new WaitForSeconds(1f);
        tramp.transform.position = new Vector3(tramp.transform.position.x, trampStartPosY, tramp.transform.position.z + 30);
        tramp.transform.DOLocalMoveZ(trampStartPosZ, 1.5f, false).SetEase(Ease.InOutBack);
    }

    private IEnumerator BackToStartPosition(GameObject IICharacter, GameObject ragDoll, Transform iiPos, GameObject player, Transform playerPos)
    {
        yield return new WaitForSeconds(2f);
        IICharacter.SetActive(true);
        
        ragDoll.SetActive(false);
        IICharacter.transform.position = iiPos.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = playerPos.position;
        
        IICharacter.GetComponent<Rigidbody>().useGravity = true;
        IICharacter.GetComponent<Rigidbody>().velocity = Vector3.zero;
        IICharacter.isStatic = true;
        IICharacter.GetComponent<BoxCollider>().enabled = true;
        foreach(GameObject go in IICharacter.GetComponent<BaseCharacter>().fightModel)
        {
            go.SetActive(true);
        }
        
    }
}

