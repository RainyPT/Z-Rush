using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoviment : MonoBehaviour
{
    private Transform bulletPos;
    private float bulletTime=1f;
    void Start()
    {
        //bulletPos toma o valor da posição da bala
        bulletPos = gameObject.transform;
    }

    void Update()
    {
        //no momento em que a bala é instanciada
        if (bulletTime > 0)
        {
            //mudar a posição da bala(para á frente) gradualmente.
            bulletPos.position += transform.forward * 50 * Time.deltaTime;
            //Baixar o valor de bullet time(delay até ser destruida) a cada frame
            bulletTime -= Time.deltaTime;
        }
        else//até passar 1 segundo
        {
            //destruir o objecto para não ficar a voar pelo mapa eternamente
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        //se colidir com um inimigo
        if (col.gameObject.tag == "enemy")
        {
            //tira 50 de vida ao inimigo
            col.gameObject.GetComponent<EnemyHealth>().Health -= 50f;
        }
        if (col.gameObject.name == "localplayer")//se colidir com o localplayer
        {
            //tira 10 de vida ao jogador local
            col.gameObject.GetComponent<PlayerHealth>().Health -= 10f;
        }
        //destruir
        Destroy(gameObject);
    }
}
