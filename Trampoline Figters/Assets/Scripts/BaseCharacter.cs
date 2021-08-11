using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private Transform Ls, Rs, La, Ra, Ll, Rl, Ldl, Rdl;
    [SerializeField] private string nameHip;
    [SerializeField] public float xPos;
    [SerializeField] Rigidbody rb;
    [SerializeField] private Vector3 startRotate;
    [SerializeField] private Transform[] rotateModel, ragdollRotate;
    [SerializeField] private GameObject ragdollModel;
    [SerializeField] public GameObject[] fightModel;
    [SerializeField] public CapsuleCollider CC;
    [SerializeField] private float pivot;
    [SerializeField] private BaseCharacter IIBC;
    [SerializeField] private bool timerActive;
    [SerializeField] private GameObject endGamePanel;

    //новые переменные

    [SerializeField] GameManager gameManager;
    private GameObject[] tramplines;
    private NewLevel newLevelScript;

    // переменные паузы

    public bool isPause = false;

    private Vector3 charVelocity;

    //
    [SerializeField] private Material[] materials;
    [SerializeField] SkinnedMeshRenderer SMeshRenderer;
    [SerializeField] private Material[] byteMaterial;
    [SerializeField] private GameObject blood;
    public int hp;
    private int myDamage;
    private bool isRagdoll;
    float yRot, zRot;
    public class positionsPlayer { public Vector3 LS, RS, LA, RA, LL, RL, LDL, RDL; };
    positionsPlayer pos1 = new positionsPlayer { LS = new Vector3(-17, 34, 79), RS = new Vector3(70, -25, 77), LA = new Vector3(33, 0, 0), RA = new Vector3(0, 0, 37), LL = new Vector3(-90, 0, 180), RL = new Vector3(26, 0, -180), LDL = new Vector3(-50, -2, 2), RDL = new Vector3(-6, 0, -1) };
    positionsPlayer pos2 = new positionsPlayer { LS = new Vector3(-14, 43, 76), RS = new Vector3(68, -23, 54), LA = new Vector3(33, 0, 0), RA = new Vector3(0, 0, 30), LL = new Vector3(-31, 0, 180), RL = new Vector3(19, 0, -180), LDL = new Vector3(-16, 0, 1), RDL = new Vector3(-48, 0, -2) };
    positionsPlayer nowPos = new positionsPlayer();
    public bool isHit;
    private Vector3 hitVelocity;
    public bool falling, flying;


    private void Start()
    {
        startFight();
        changePos(pos2);
        //Дополнено
        if(this.gameObject.name == "Player")
        {
            GetComponent<Animator>().enabled = false;
        }
        newLevelScript = gameManager.newLevelScript;
        tramplines = gameManager.tramplines;
        Pause();
        //
    }

    //Kri
    public void Pause()
    {
        if (!isPause)
        {
            isPause = true;
            charVelocity = GetComponent<Rigidbody>().velocity;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            isPause = false;
            this.GetComponent<Rigidbody>().isKinematic = false;
            this.GetComponent<Rigidbody>().velocity = charVelocity;
        }
    }
    //

    public void startFight()
    {
        byteMaterial = new Material[SMeshRenderer.materials.Length];
        byteMaterial = SMeshRenderer.materials;
        for (int a = 0; a < byteMaterial.Length; a++)
        {
            byteMaterial[a] = materials[0];
        }
        SMeshRenderer.materials = byteMaterial;
    }

    public void changeColorBody(string name)
    {
        Debug.Log(name + gameObject.name);
        byteMaterial = new Material[SMeshRenderer.materials.Length];
        byteMaterial = SMeshRenderer.materials;
        switch (name)
        {
            case "HEAD":
                {
                    byteMaterial[0] = materials[2];
                    break;
                }
            case "LL":
                {
                    byteMaterial[6] = materials[2];

                    break;
                }
            case "RL":
                {
                    byteMaterial[12] = materials[2];
                    break;
                }
            case "RDL":
                {

                    byteMaterial[11] = materials[2];
                    break;
                }
            case "RDDL":
                {
                    byteMaterial[10] = materials[2];
                    break;
                }
            case "LDL":
                {
                    byteMaterial[5] = materials[2];
                    break;
                }
            case "LDDL":
                {
                    byteMaterial[4] = materials[2];
                    break;

                }
            case "SPINE":
                {
                    byteMaterial[3] = materials[2];
                    break;
                }
            case "LS":
                {
                    byteMaterial[7] = materials[2];
                    break;
                }
            case "RS":
                {
                    byteMaterial[13] = materials[2];
                    break;
                }
            case "LA":
                {
                    byteMaterial[1] = materials[2];
                    break;
                }
            case "RA":
                {
                    byteMaterial[8] = materials[2];
                    break;
                }
            case "LDA":
                {
                    byteMaterial[2] = materials[2];
                    break;
                }
            case "RDA":
                {
                    byteMaterial[9] = materials[2];
                    break;
                }
            case "layer":
                {
                    byteMaterial[3] = materials[2];
                    break;
                }
            case "ICharacter":
                {
                    byteMaterial[3] = materials[2];
                    break;
                }

        }
        SMeshRenderer.materials = byteMaterial;
    }
    public void goBack()
    {
        if (!isRagdoll)
        {
            isHit = true;
            flying = false;
            rb.velocity = Vector3.zero;
            rb.DOMoveX(xPos, 0.6f).OnComplete(() => { CC.enabled = true; });
        }
    }

    public void setAnchors()
    {

    }

    public void goRagdoll()
    {
        isRagdoll = true;
        ragdollModel.transform.position = transform.position;
        ragdollModel.transform.eulerAngles = transform.eulerAngles;
        for (int i = 0; i < rotateModel.Length; i++)
        {
            ragdollRotate[i].localEulerAngles = rotateModel[i].localEulerAngles;
        }
        rb.useGravity = false;
        gameObject.isStatic = true;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        foreach (GameObject go in fightModel)
        {
            go.SetActive(false);
        }
        ragdollModel.SetActive(true);
        ragdollModel.GetComponent<Rigidbody>().velocity = rb.velocity;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.name == nameHip && !isHit)
        {
            hitVelocity = rb.velocity * 20;
            Physics.gravity = new Vector3(0, -9.81f, 0);
            Collider myCollider = collision.contacts[0].thisCollider;
            if (myCollider.name != "Player" && myCollider.name != "IICharacter")
            {
                myDamage = int.Parse(myCollider.name.Substring(0, 1));
            }
            else
            {
                myDamage = 0;
            }
            collision.transform.root.gameObject.GetComponent<BaseCharacter>().checkName(myCollider, GetComponent<BaseCharacter>(), collision.contacts[0].point);

        }
    }
    public void clearDoTween()
    {
        DOTween.Clear();
    }
    private bool endgame;

    public void changePos(positionsPlayer pos)
    {
        nowPos = pos;
    }
    private bool win;
    private void FixedUpdate()
    {
        if (Mathf.Abs(gameObject.transform.position.x) < Mathf.Abs(pivot) && !timerActive)
        {
            timerActive = true;
            StartCoroutine(timefall());
        }
        if (!win)
        {
            //Ls.localEulerAngles = nowPos.LS;
            //Rs.localEulerAngles = nowPos.RS;
            //La.localEulerAngles = nowPos.LA;
            //Ra.localEulerAngles = nowPos.RA;
            //Ll.localEulerAngles = nowPos.LL;
            //Rl.localEulerAngles = nowPos.RL;
            //Ldl.localEulerAngles = nowPos.LDL;
            //Rdl.localEulerAngles = nowPos.RDL;
        }
    }
    public void gameend()
    {
        clearDoTween();
        rb.mass = 10;

        rb.velocity = Vector3.zero;
        rb.velocity = new Vector3(-pivot * 5, 5, hitVelocity.z);
        Debug.Log(new Vector3(hitVelocity.x * 2.5f, hitVelocity.y / 3, hitVelocity.z));

        if(this.gameObject.name == "Player")
        {
            win = true;
            endGamePanel.SetActive(true);
            this.gameObject.transform.DOLocalMove(Vector3.zero, 1.5f);
            GetComponent<Animator>().enabled = true;
        }

    }
    IEnumerator timefall()
    {
        Physics.gravity = new Vector3(0, Physics.gravity.x / 5, 0);
        rb.velocity = rb.velocity / 5;
        yield return new WaitForSeconds(2f);
        timerActive = false;
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    public void checkName(Collider name, BaseCharacter BC, Vector3 point)
    {
        int damage;
        if (name.name != "Player" && name.name != "IICharacter")
        {
            damage = int.Parse(name.name.Substring(0, 1));
        }
        else
        {
            damage = 0;
        }
        if (myDamage > damage)
        {
            BC.changeColorBody(name.name.Substring(1));
        }
        else if (myDamage < damage)
        {
            hp -= damage;
            GameObject bl = Instantiate(blood);
            blood.transform.position = point;
        }
        if (hp > 0)
        {
            BC.goBack();

        }
        else
        {
            clearDoTween();
            goRagdoll();
            BC.gameend();
        }
    }
}
