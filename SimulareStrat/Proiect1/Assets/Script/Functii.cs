using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Functii : MonoBehaviour
{

    [SerializeField] private  GameObject pagina1;
    [SerializeField] private GameObject valoriCalcul;
    [SerializeField] private Text afisare;
    [SerializeField] private Text rezultatlFinal;
    [SerializeField] private Text GinAf;

    private Neuron gin;
    private ValoriAGTeta valori;
    private string nume, final;
    private float e = 2.718281828459f;

    private void Awake()
    {
        gin = pagina1.GetComponent<Neuron>();
        valori = valoriCalcul.GetComponent<ValoriAGTeta>();
        valori.SetActivA(false);
        valori.SetActivG(false);
        valori.SetActivTeta(false);
        nume = "Treapta";
        final = "Real";
    }


    private void Update()
    {
        if(nume == "Treapta")
        {
            Treapta();
        }
        if(nume == "Sigmoidala")
        {
            Sigmoidala();
        }
        if(nume == "Signum")
        {
            Signum();
        }
        if(nume == "Tanh")
        {
            Tanh();
        }
        if(nume == "Liniara")
        {
            Liniara();
        }
        if(final == "Real")
        {
            Real();
        }
        if(final == "Binar")
        {
            Binar();
        }
        GinAf.text = gin.GetGin().ToString();
    }

    public void Treapta()
    {
        valori.SetActivA(false);
        valori.SetActivG(false);
        valori.SetActivTeta(true);
        nume = "Treapta";

        if (gin.GetGin() >= valori.GetTeta())
        {
            afisare.text = "1";
        }
        else
        {
           afisare.text="0";
        }


    }

    public void Sigmoidala()
    {
        valori.SetActivA(false);
        valori.SetActivG(true);
        valori.SetActivTeta(false);
        nume = "Sigmoidala";

        float aux = 1 / (1 + Mathf.Pow(e, (-valori.GetG() * gin.GetGin())));
        afisare.text = aux.ToString("F12");
    }

    public void Signum()
    {
        valori.SetActivA(false);
        valori.SetActivG(false);
        valori.SetActivTeta(true);
        nume = "Signum";

        if(gin.GetGin() >= valori.GetTeta())
        {
            afisare.text = "1";
        }
        else
        {
            afisare.text="-1";
        }
    }

    public void Tanh()
    {
        valori.SetActivA(false);
        valori.SetActivG(true);
        valori.SetActivTeta(false);
        nume = "Tanh";

        float aux = (Mathf.Pow(e, (valori.GetG() * gin.GetGin())) - Mathf.Pow(e, (-valori.GetG() * gin.GetGin()))) /
            (Mathf.Pow(e, (valori.GetG() * gin.GetGin())) + Mathf.Pow(e, (-valori.GetG() * gin.GetGin())));
        afisare.text = aux.ToString("F12");
    }

    public void Liniara()
    {
        valori.SetActivA(true);
        valori.SetActivG(false);
        valori.SetActivTeta(false);
        nume = "Liniara";

        if( gin.GetGin() >= valori.GetA())
        {
            afisare.text = "1";
        }
        else if (gin.GetGin() < valori.GetA() && gin.GetGin() > (-valori.GetA()))
        {
           float aux = gin.GetGin()/valori.GetA();
           afisare.text = aux.ToString("F12");
        }
        else if (gin.GetGin() <= (-valori.GetA()))
        {
            afisare.text = "-1";
        }
    }

    public void Real()
    {
        final = "Real";
        rezultatlFinal.text = afisare.text;
    }

    public void Binar()
    {
        final = "Binar";
        if (nume == "Sigmoidala")
        {
            float aux;
            if (float.TryParse(afisare.text, out aux))
            {
                if(aux >= 0.5f)
                {
                    rezultatlFinal.text = "1";
                }
                else 
                {
                    rezultatlFinal.text="0";
                }
            }
        }
        else if (nume == "Tanh" || nume == "Liniara")
        {
            float auxx;
            if (float.TryParse(afisare.text, out auxx))
            {
                if (auxx >= 0)
                {
                    rezultatlFinal.text = "1";
                }
                else
                {
                    rezultatlFinal.text = "0";
                }
            }
        }
        else
        {
            rezultatlFinal.text = afisare.text;
        }
    }
    public void Back()
    {
        gameObject.SetActive(false);
        pagina1.SetActive(true);
    }


}
