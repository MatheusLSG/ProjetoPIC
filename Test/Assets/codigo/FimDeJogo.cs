using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FimDeJogo : MonoBehaviour
{
    private BOLA sc;
    private GameObject bola;
    private Pontos pt;

    private GameObject tempo;
    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Sphere");
        sc = bola.GetComponent<BOLA>();
        tempo = GameObject.Find("Tempo");
        pt = tempo.GetComponent<Pontos>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sc.timer > 3 && sc.respawn == false)
        {
            this.GetComponent<TextMeshProUGUI>().alpha = 0;
            tempo.GetComponent<TextMeshPro>().alpha = 1;
        }

        if(sc.timer < 3 && sc.respawn == false)
        {
            if(sc.timer < 3){
                this.GetComponent<TextMeshProUGUI>().text = string.Format("{0}",(3-(int)sc.timer));
            }else{
                this.GetComponent<TextMeshProUGUI>().text = string.Format("VAI!");
            }
            this.GetComponent<TextMeshProUGUI>().alpha = 1;
            tempo.GetComponent<TextMeshPro>().alpha = 0;
        }
        
        if (sc.respawn == true)
        {
            this.GetComponent<TextMeshProUGUI>().text = string.Format("Fim de Jogo!\n\n\nSeu Tempo: {0:D2}:{1:D2}\nMelhor Tempo: {2:D2}:{3:D2}\n\n\nPressione 'Enter' para reiniciar\n",(int)pt.pontos/60,(int)pt.pontos%60,(int)pt.melhor_pontuacao/60,(int)pt.melhor_pontuacao%60);
            this.GetComponent<TextMeshProUGUI>().alpha = 1;
            tempo.GetComponent<TextMeshPro>().alpha = 0;
        }
        

    }
}
