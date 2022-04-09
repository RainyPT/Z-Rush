using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    //muda o texto do objecto UIText.Este objecto é responsavel por mostrar as indicações no inicio do jogo
    public static void setText(string newText)
    {
        GameObject.Find("UIText").GetComponent<Text>().text = newText;
    }
    //O nome foi um bocado mal escolhido mas o indicationText é o texto por baixo das indicações iniciais,
    //que diz que o utilizador tem de disparar para mudar o texto.
    //Assim que o utilizador ver todas as indicações, esse texto desaparece graças a esta função.
    public static void clearIndicationText()
    {
        GameObject.Find("indicationText").GetComponent<Text>().text = "";
    }
}
