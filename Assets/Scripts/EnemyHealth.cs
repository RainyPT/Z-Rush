using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Variavel que contem o valor inicial da vida
    private float health = 200f;

    //guetter/setter do atributo Health
    public float Health
    {
        get { return health; }
        set { health = value; }
    }

    void Update()
    {
        //se o inimigo tiver 0 de vida ou menos, o seu gameobject é destruido
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }
}
