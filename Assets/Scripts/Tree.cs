using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private int treeHealth;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider2D _collider;

    [SerializeField] private GameObject WoodPrefab;
    [SerializeField] private ParticleSystem leafsParticle;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnHit()
    {
        treeHealth -= 1; 
        if(treeHealth > 0)
        {
            _animator.SetTrigger("isCutting");
            leafsParticle.Play();

        }
        else if (treeHealth <= 0)
        {
            _animator.SetTrigger("cut");
            _collider.enabled = false;
            Instantiate(WoodPrefab, transform.position, transform.rotation);
            //leafsParticle.enableEmission = false;

        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Axe":
                if(treeHealth > 0)
                {
                    OnHit();
                }    
                break;
        }
    }

}
