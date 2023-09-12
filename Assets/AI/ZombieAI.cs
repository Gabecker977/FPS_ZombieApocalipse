using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ZombieAI : MonoBehaviour
{
     private enum EnemyType {SegurancaAeroporto=1,ControleAeroporto=2,CarregadorDeMalas
    ,Executivo,LiderDeTorcida,Palhaco,Fazendeiro
    ,MulherFazendeira,Bombeiro,JogadorDeFutebol,
    Avo,MoradorDeAreaLivre,Industrial,Mecanico,
    PoliciaMontada,Piloto,Gangster,Prisioneiro,
    TrabalhadorEstrada,Ladrao,Corredor,PapaiNoel,
    AtendenteLoja,Soldado,JogadorBasket,
    Turista,Caminhoneiro,Random};
    [SerializeField] private Transform target;
    [SerializeField] private EnemyType enemyType=EnemyType.Random;
    [SerializeField, Range(5f,100f)] private float speed=5f;
    [SerializeField, Range(0f,5f)] private float distanceToHit=2f;
    [SerializeField] private bool canAtack=true;
    private Rigidbody rb;
    private Animator animator;
    private Health health;
    private void Start() {
        health=GetComponent<Health>();
        health.OnDie+=()=>Destroy(gameObject);
        health.OnTakeDamege+=()=>Debug.Log("Damege");
        rb=GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        if(target==null){
            target=GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(enemyType==EnemyType.Random) enemyType=(EnemyType)Random.Range(1,27);

        transform.GetChild(((int)enemyType+1)).gameObject.SetActive(true);
    }
    private void Update() {
        if(Vector3.Distance(transform.position,target.position)<distanceToHit&&canAtack){
            animator.SetBool("Ataque",true);
        }else animator.SetBool("Ataque",false);
    }
    private void FixedUpdate() {
        if(Vector3.Distance(transform.position,target.position)>distanceToHit){
            Vector3 dir = target.transform.position - transform.position;
            rb.MovePosition(rb.position+(dir.normalized*Time.deltaTime*speed));
            
            //rb.MoveRotation(Quaternion.LookRotation(dir));
            FaceTarget();
        }
    }

  


    private void FaceTarget()
    {
        //Rotate speed
        float rotateSpeed = 5f;
        Vector3 directionToPlayer = target.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        //Look the X and Z axis only
        targetRotation.x = 0;
        targetRotation.z = 0;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }



}
