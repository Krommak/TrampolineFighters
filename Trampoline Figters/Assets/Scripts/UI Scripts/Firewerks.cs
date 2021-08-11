using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firewerks : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject firePrefab;
    void Start()
    {
        StartCoroutine(FirewerksGen());
    }

    private IEnumerator FirewerksGen()
    {
        Vector3 leftDownPoint = cam.ScreenToWorldPoint(Vector3.zero);
        float posX = leftDownPoint.y;
        float posY = leftDownPoint.z;
        Vector3 posForFirewerk = new Vector3(Random.Range(posX * -2, posX), Random.Range(posX, posX * -2), -5f);
        GameObject res = Instantiate(firePrefab, posForFirewerk, Quaternion.identity);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(FirewerksGen());
    }
}
