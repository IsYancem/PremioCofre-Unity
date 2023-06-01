using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AbrirCofre()
    {
        anim.SetBool("isClosed", true);
    }

    public void CerrarCofre()
    {
        anim.SetBool("isClosed", false);
    }
}
