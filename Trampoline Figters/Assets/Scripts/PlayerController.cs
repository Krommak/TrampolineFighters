using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform LSJ, RSJ, LAJ, RAJ, LLJ, RLJ, LDLJ, RDLJ;
    
    public class positionsPlayer { public float LS, RS, LA, RA, LL, RL, LDL, RDL; }
    [SerializeField] public positionsPlayer pos1 = new positionsPlayer { LS = 110f, RS = -60f, LA = 0, RA = 90f, LL = 0f, RL = 0f, LDL = 0f, RDL = 0f };
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
        }
    }
    


}
