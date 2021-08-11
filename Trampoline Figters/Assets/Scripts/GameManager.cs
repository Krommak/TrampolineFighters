using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform [] pos;
    [SerializeField]
    GameObject characterPrefab, IIPrefab;
    
    // новые переменные
    [SerializeField] public GameObject [] tramplines;
    [SerializeField] public NewLevel newLevelScript;
    //

    void Start()
    {
    }
}
