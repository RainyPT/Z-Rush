using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{

    Animator anim;
    public Transform target;
    private CharacterController controller;
    private float speed = 2f;
    private float gravity = -9.8f;
    Vector3 velocity;
    private bool isMoving = false;
    private bool isShoot = false;
    public GameObject gun;

    public float onDistance;
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Se o jogador local ainda estiver vivo
        if(GameObject.Find("localplayer")!=null)
            //calcula a distancia entre o inimigo e o jogador
            onDistance = Vector3.Distance(GameObject.Find("localplayer").transform.position, gameObject.transform.position);
       // se estiver perto do jogador
        if (onDistance < 20f) //Moving Player In Real Time
        {
            if (onDistance > 10f)
            {

                float step = speed * Time.deltaTime; // calcula a distancia que se tem de mover
                //move o inimigo para mais perto do jogador local, via o seu character controller.
                controller.Move(new Vector3((GameObject.Find("localplayer").transform.position.x - this.transform.position.x), 0, GameObject.Find("localplayer").transform.position.z - this.transform.position.z).normalized * step);
                //Atua a força da gravidade para manter o inimigo no chão
                velocity.y += gravity * Time.deltaTime;
                //está a mover-se
                isMoving = true;
                // mas não realiza a animação de disparar
                isShoot = false;
                anim.SetBool("Speed", isMoving);
                anim.SetBool("Shoot", isShoot);
                //ativa a arma e dispara
                gun.SetActive(true);
            }
            else//se estiver muito perto
            {
                //dispara
                isShoot = true;
                //para de se mover
                isMoving = false;
                //realiza animações de disparo e para a animação de andar
                anim.SetBool("Speed", isMoving);
                anim.SetBool("Shoot", isShoot);
                //ativa a arma e dispara
                gun.SetActive(true);

            }
        }
        else
        { //Player Is Not Moving
            isMoving = false;
            isShoot = false;
            anim.SetBool("Speed", isMoving);
            gun.SetActive(false);
        }
        if (onDistance < 20f) //Player Rotation In Real Time
        {
            //calcula a distancia entre o target e o inimigo
            Vector3 direct = target.position - transform.position;
            //calcula o angulo de rotação
            Quaternion rotate = Quaternion.LookRotation(direct, Vector3.up);
            //transforma para um angulo de "euler"
            rotate.eulerAngles = new Vector3(transform.rotation.x, rotate.eulerAngles.y, transform.rotation.z);
            //aponta para o jogador local
            transform.rotation = rotate;
        }
    }
}
