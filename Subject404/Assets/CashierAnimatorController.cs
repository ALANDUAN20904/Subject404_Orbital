using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class CashierAnimatorController : MonoBehaviour
{
    public Transform objectToLookAt;
    public float headWeight;
    public float bodyWeight;
    public float eyesWeight;
    public float clampWeight;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtPosition(objectToLookAt.position);
        animator.SetLookAtWeight(1f,bodyWeight,headWeight,eyesWeight,clampWeight);
    }
}
