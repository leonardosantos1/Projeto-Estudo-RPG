using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private PlayerController player;
    private Animator _animator;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;


    [SerializeField] private bool _isHitting;
    [SerializeField] private float timeCount;
    [SerializeField] private float recoveryTime = 1f;

    [SerializeField] private SkeletonAnimation skeletonAnimation;


        // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = FindObjectOfType<SkeletonAnimation>();
        player = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_isHitting)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= recoveryTime)
            {
                _isHitting = false;
                timeCount = 0f;
            }
        }


        if(player.rigidbody.velocity.sqrMagnitude > 0)
        {
            if (player.isRunning)
            {
                _animator.SetInteger("transition", 2);

            }else if (player.isRolling)
            {
                if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerRolling"))
                {
                    _animator.SetTrigger("isRoll");

                }
            }
            else{
                _animator.SetInteger("transition", 1);
            }
           
        }
        else{
            _animator.SetInteger("transition", 0);
        }

        if (player.isCutting)
        {
            _animator.SetInteger("transition", 3);
        }

        if (player.isDigging)
        {
            _animator.SetInteger("transition", 4);
        }

        if (player.isWatering)
        {
            _animator.SetInteger("transition", 5);
        }

    }

    public void OnHit()
    {
        if (!_isHitting)
        {
            _animator.SetTrigger("Hurt");
            _isHitting = true;
        }
    }

    public void Attack()
    {

        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

        if (hit != null)
        {
            hit.GetComponentInChildren<SkeletonAnimation>().OnHit();
            Debug.Log("Esta no inimigo");
        }
        else
        {
            Debug.Log("nao Esta no player");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }


}
