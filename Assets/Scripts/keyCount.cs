using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCount : MonoBehaviour
{
    public static int keyCatched = 0;

    public GameObject text;

    void Update()
    {
        //se o jogador apanhar todas as chaves
        if (keyCatched>=5)
        {
            //mostra o texto de acabar o jogo
            text.SetActive(true);
        }
    }
    //Função chamada sempre que o jogador apanha uma chave
    public static void oneMoreKeyCatched()
    {
        //incrementa keyCatched
        keyCatched++;
        //se for par
        if(keyCatched % 2 == 0)
        {
            //inicia a musica "Preston1"
            GameObject.FindObjectOfType<AudioManager>().Play("Preston1");
        }
        else//se for impar
        {
            //inicia a musica "Preston2"
            GameObject.FindObjectOfType<AudioManager>().Play("Preston2");
        }
    }
}
