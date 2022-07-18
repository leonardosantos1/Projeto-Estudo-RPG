using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnimation playerAnimation;
    private SkeletonController skeletonController;

    [SerializeField] private Collider2D _collider;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = FindObjectOfType<PlayerAnimation>();
        _animator = GetComponent<Animator>();
        skeletonController = GetComponentInParent<SkeletonController>();
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    public void ChooseAnimation(int value)
    {
        _animator.SetInteger("transition", value);
    }

    public void Attack()
    {
        if (!skeletonController.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, radius, playerLayer);

            if (hit != null)
            {
                playerAnimation.OnHit();

            }
            else
            {
                Debug.Log("nao Esta no player");

            }
        }
    }

    public void OnHit()
    {
        if (!skeletonController.isDead)
        {
            skeletonController.currentHealth--;
            _animator.SetTrigger("Hurt");
            skeletonController.healthBar.fillAmount = skeletonController.currentHealth / skeletonController.totalHealth;

            if (skeletonController.currentHealth <= 0)
            {
                OnDeath();
                _collider.enabled = false;
                skeletonController.isDead = true;
                Destroy(skeletonController.canvas.gameObject);
            }
        }
    
    }

    public void OnDeath()
    {
        _animator.SetTrigger("Death");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, radius);
    }

}
