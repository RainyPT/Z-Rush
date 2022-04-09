using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public Object bala;
    public Transform firingPoint;

    private float shootDelay = 1f;

    public TimeManager time;
    public int shootTimes=0;

    void Update()
    {
        //se o utilizador clicar no "gatilho" do controller esquerdo e o delay de disparo for igual ou menor que 0
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0f && shootDelay <= 0)
        {
            //incrementa a variavel que conta as vezes que o utilizador dispara
            shootTimes++;
            //instancia uma bala no firing point (ponta do cano da arma)
            Instantiate(bala, firingPoint.position, firingPoint.rotation);
            //iguala o shoot delay a 1 segundo
            shootDelay = 1f;
        }
        //diminui o valor de shootDelay
        shootDelay -= Time.deltaTime;
        //Se o utilizador disparar
        switch (shootTimes)
        {
            case 1://uma vez
                //texto de indicações é igual a "Grab all the keys to win!!"
                TextManager.setText("Grab all the keys to win!!");
                break;
            case 2:
                //texto de indicações é igual a "To use SLOW MOTION, press the switch on your belt!"
                TextManager.setText("To use SLOW MOTION, press the switch on your belt!");
                break;
            case 3:
                //texto de indicações é igual a "Start by grabbing the blue key!"
                TextManager.setText("Start by grabbing the blue key!");
                break;
            case 4:
                //texto de indicações é igual a "" e limpa o texto que diz ao utilizador que tem de disparar para mostrar
                //novas indicações.
                TextManager.setText("");
                TextManager.clearIndicationText();
                break;

        }
        //se a tecla "seta para cima" for premida(Makey Makey Emulation)
         if (Input.GetKeyDown(KeyCode.UpArrow)) {
            //Inicia o slow motion
             time.DoSlowTime();
         }
    }
}
