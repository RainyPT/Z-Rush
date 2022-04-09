using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Script : MonoBehaviour
{

    public GameObject Door;
    //se houver alguma colisão
    private void OnTriggerEnter(Collider other)
    {
        //se a colisão for com o local player
        if (other.gameObject.name == "localplayer")
        {
            //incrementa o numero de chaves apanhadas
            keyCount.oneMoreKeyCatched();
            //destroi a porta associada á chave
            Destroy(Door);
            //destroi a chave em si
            Destroy(gameObject);
        }
    }
}
