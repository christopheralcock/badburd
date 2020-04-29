using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour
{


  [SerializeField] GameObject _cloudParticlePrefab;
  [SerializeField] bool flying;
    public Animator Animator;
    public CinemachineTargetGroup targetGroup;
    public int flyLevel;


    private void Awake()
    {
        targetGroup = FindObjectOfType<CinemachineTargetGroup>();
        flyLevel = FindObjectOfType<SceneConfig>().flyLevel;
    }

    private void Update()
    {
        if (transform.position.y <= flyLevel)
        {
            flying = true;
            Animator.SetBool("flying", flying);
            }

        if (flying == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = -1;
        }

        if (transform.position.y > 10)
        {
            targetGroup.RemoveMember(transform);
            Debug.Log("enemy went high");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
      if (collision.contacts[0].normal.y<.2){
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
      }
    }
}
