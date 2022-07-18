using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SkeletonController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private NavMeshAgent agent;
    
    public Image healthBar;
    public Canvas canvas;
    
    private SkeletonAnimation skeletonAnimation;
    private PlayerController playerController;

    [SerializeField] private float _currentHealth;
    [SerializeField] private float _totalHealth;
    [SerializeField] private bool _isDead = false;
    [SerializeField] private bool _rangePlayer = false;


    public float currentHealth { get => _currentHealth; set => _currentHealth = value; }
    public float totalHealth { get => _totalHealth; set => _totalHealth = value; }
    public bool isDead { get => _isDead; set => _isDead = value; }
    public bool rangePlayer { get => _rangePlayer; set => _rangePlayer = value; }

    void Start()
    {
        _currentHealth = _totalHealth;

        playerController = FindObjectOfType<PlayerController>();
        skeletonAnimation = FindObjectOfType<SkeletonAnimation>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDead)
        {
            if (_rangePlayer)
            {
                agent.isStopped = false;
                agent.SetDestination(playerController.transform.position);

                Flip();

                if (Vector2.Distance(transform.position, playerController.transform.position) <= agent.stoppingDistance)
                {
                    skeletonAnimation.ChooseAnimation(2);
                }
                else
                {
                    skeletonAnimation.ChooseAnimation(1);
                }
            }
            else{
                agent.isStopped = true;
                skeletonAnimation.ChooseAnimation(0);
            }
     
        }
        
    }

    private void Flip()
    {
        float posX = playerController.transform.position.x - transform.position.x;
        if(posX > 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        if(posX < 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    
    }

}
