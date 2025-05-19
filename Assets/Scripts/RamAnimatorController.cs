using UnityEngine;

public class RamAnimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdle() => animator.Play("Idle");

    public void PlayAttack() => animator.CrossFade("Combat_Unarmed_Attack", 0.25f);

    public void PlayHit() => animator.CrossFade("Combat_Unarmed_Hit", 0.1f);

    public void PlayDeath() => animator.CrossFade("Death", 0.25f);
}
