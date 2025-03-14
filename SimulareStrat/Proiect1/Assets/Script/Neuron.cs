using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Neuron : MonoBehaviour
{
    [Header ("Slider")]
    [SerializeField] private Text nrLegaturiAfisare; 
    [SerializeField] private Slider slider;

    [Header("Vector")]
    [SerializeField] private GameObject vector;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ScrollRect scroll;

    [Header("Afisare pas 1")]
    [SerializeField] private Text rezultat;

    [Header("Next")]
    [SerializeField] private GameObject functii;


    private int nrLegaturi, legaturiaux;
    private GameObject[] vecPrefab;
    private float pozY = 211.236f, poziteScroll;
    private string nume;

    private float Gin;

    private void Awake()
    {
        poziteScroll = scroll.verticalNormalizedPosition;
        legaturiaux = nrLegaturi;
        vecPrefab = new GameObject[50];
        nume = "Suma";
    }

    private void Update()
    {
        nrLegaturi = ((int)(slider.value * 50));
        nrLegaturiAfisare.text = nrLegaturi.ToString();

        if (legaturiaux != nrLegaturi)
        {
            DeleteScroll();
            legaturiaux = nrLegaturi;
            Scroll();
        }

        if(nrLegaturi != 0)
        {
            if (nume == "Suma")
            {
                Suma();

            }
            else if (nume == "Prouds")
            {
                Produs();
            }
            else if (nume == "Max")
            {
                Max();
            }
            else if (nume == "Min")
            {
                Min();
            }
        }
        else
        {
            rezultat.text = "0.000000000000";
        }
    }
    
    private void Scroll()
    {
        for(int i = 0; i < nrLegaturi; i++)
        {
            GameObject instanta = Instantiate(prefab);
            vecPrefab[i] = instanta;
            instanta.transform.SetParent(vector.transform);
            instanta.transform.localPosition =  new Vector3(-230.5669f, (pozY - 100 * i), 0);
        }
        
        ScrollUpdate();
    }

    private void DeleteScroll()
    {
        for(int i = 0; i < vecPrefab.Length; i++)
        {
            Destroy(vecPrefab[i]);
        }
        ScrollUpdate();
    }

    private void ScrollUpdate()
    {
        scroll.verticalNormalizedPosition = poziteScroll;
    }

    public void Suma()
    {
        float suma = 0f;

        for(int i = 0;i < vecPrefab.Length; i++)
        {
            if (vecPrefab[i] != null)
            {
                ValoriXsiW aux = vecPrefab[i].GetComponent<ValoriXsiW>();
                if (aux != null)
                {
                    suma += aux.GetX() * aux.GetW();
                }
            }
        }

        rezultat.text = suma.ToString("F12");
        Gin = suma;
        nume = "Suma";
    }


    public void Produs()
    {
        float produs = 1f;

        for (int i = 0; i < vecPrefab.Length; i++)
        {
            if (vecPrefab[i] != null)
            {
                ValoriXsiW aux = vecPrefab[i].GetComponent<ValoriXsiW>();
                if (aux != null)
                {
                    produs *= aux.GetX() * aux.GetW();
                }
            }
        }

        rezultat.text = produs.ToString("F12");
        Gin = produs;
        nume = "Prouds";
    }

    public void Max()
    {
        float max = float.MinValue, calcul = 0;

        for (int i = 0; i < vecPrefab.Length; i++)
        {
            if (vecPrefab[i] != null)
            {
                ValoriXsiW aux = vecPrefab[i].GetComponent<ValoriXsiW>();
                if (aux != null)
                {
                    calcul = aux.GetX() * aux.GetW();

                    if(calcul > max)
                    {
                        max = calcul;
                    }
                }
            }
        }

        rezultat.text = max.ToString("F12");
        Gin = max;
        nume = "Max";
    }

    public void Min()
    {
        float min = float.MaxValue, calcul = 0;

        for (int i = 0; i < vecPrefab.Length; i++)
        {
            if (vecPrefab[i] != null)
            {
                ValoriXsiW aux = vecPrefab[i].GetComponent<ValoriXsiW>();
                if (aux != null)
                {
                    calcul = aux.GetX() * aux.GetW();

                    if (calcul < min)
                    {
                        min = calcul;
                    }
                }
            }
        }

        rezultat.text = min.ToString("F12");
        Gin = min;
        nume = "Min";
    }

    public float GetGin()
    {
        return Gin;
    }

    public void Next()
    {
        gameObject.SetActive(false);
        functii.SetActive(true);
    }

}
