using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //variavel com o valor inicial da vida do jogador local
    private float health = 100f;
    //guetter/setter da variavel health
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    void Update()
    {
        //se o jogador local tiver 0 ou menos de vida
        if (health <= 0)
        {
            //Destroi o seu gameobject
            Destroy(gameObject);
        }
    }
}
