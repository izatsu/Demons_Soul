using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dökkálfar_Run : StateMachineBehaviour
{
    public int attackCount = 0;
    public int maxAttackCount = 3;

    private List<AttackType> attackList = new List<AttackType>() { AttackType.attack1, AttackType.attack2, AttackType.attack3 };
    private int currentAttackIndex = 0;

    private Transform playerTransform;
    private Transform bossTransform;
    public float distanceThreshold = 5f;
    public float speed = 5f;
    public float attackDistance = 3f;
    public float speedRotation = 180;




    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossTransform = animator.gameObject.transform;
        attackCount = 0;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerTransform != null)
        {
            float distance = Vector3.Distance(playerTransform.position, bossTransform.position);

            if (distance > distanceThreshold)
            {
                animator.SetBool("idle", true);
                animator.SetBool("run", false);
            }
            else
            {
                animator.SetBool("idle", false);
                animator.SetBool("run", true);

                Vector3 direction = playerTransform.position - bossTransform.position;


                bossTransform.position = Vector3.MoveTowards(bossTransform.position,
                                                             playerTransform.position, speed * Time.deltaTime);

            }
            if (Vector3.Distance(animator.transform.position, playerTransform.transform.position) < attackDistance)
            {

                if (attackCount >= maxAttackCount)
                {
                    ExecuteSpecialAttack(animator);
                    attackCount = 0;
                }

                else
                {
                    AttackType attackType = attackList[currentAttackIndex];
                    ExecuteAttack(animator, attackType);
                    currentAttackIndex = (currentAttackIndex + 1) % attackList.Count;
                    attackCount++;
                }
            }
        }

    }
    private void ExecuteAttack(Animator animator, AttackType attackType)
    {

        switch (attackType)
        {
            case AttackType.attack1:
                animator.SetTrigger("Attack1");
                break;
            case AttackType.attack2:
                animator.SetTrigger("Attack2");
                break;
            case AttackType.attack3:
                animator.SetTrigger("Attack3");
                break;
        }
    }

    private void ExecuteSpecialAttack(Animator animator)
    {
        animator.SetTrigger("AttackCombo");

    }
}
public enum AttackType
{
    attack1,
    attack2,
    attack3
}
