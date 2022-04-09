using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float distanceFromPlayer;
    public Object bala;
    public Transform firingPoint;

    private float shootDelay = 1f;
    void Update()
    {
        //Vai buscar o valor da distancia entre o player e o inimigo ao script EnemyMoviment
        distanceFromPlayer = GetComponent<EnemyMoviment>().onDistance;
        //se o local player estiver "in range" e o delay for igual ou menor que 0
        if (distanceFromPlayer < 10f && shootDelay <= 0)
        {
            //instancia uma bala na posição de disparo
            Instantiate(bala, firingPoint.position, firingPoint.rotation);
            //Aumenta o delay para o seu valor original
            shootDelay = 1f;
        }
        //baixa o valor do delay a cada frame
        shootDelay -= Time.deltaTime;
    }
}
