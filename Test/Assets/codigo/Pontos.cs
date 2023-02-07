using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pontos : MonoBehaviour
{
    private BOLA sc;
    private GameObject bola;
    public float pontos=0;
    public float melhor_pontuacao=0;
    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Sphere");
        sc = bola.GetComponent<BOLA>();
    }

    // Update is called once per frame
    void Update()
    {   
        this.GetComponent<TextMeshPro>().text = string.Format("{0:D2}:{1:D2}",(int)pontos/60,(int)pontos%60);

        if(sc.timer < 3 && sc.respawn == false)
        {
            pontos = 0;
        }

        if(sc.timer >= 3 && sc.respawn == false){
            sc.ImInGame = true;
            pontos += Time.deltaTime;
        }
        
        if (sc.respawn == true && pontos > melhor_pontuacao)
        {
            melhor_pontuacao = pontos;
        }
    }
}
