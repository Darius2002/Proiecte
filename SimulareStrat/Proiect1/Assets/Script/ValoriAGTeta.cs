using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValoriAGTeta : MonoBehaviour
{
    [SerializeField] private InputField numarA, numarG, numarTeta;
    [SerializeField] private GameObject A, G,Teta;
    private float a, g, teta;

    private void Update()
    {
     
        string txtA = numarA.text, txtG = numarG.text, txtTeta = numarTeta.text;
        float auxA, auxG, auxTeta;

        if (float.TryParse(txtA, out auxA))
        {
            a = auxA;
        }
        if (float.TryParse(txtG, out auxG))
        {
            g = auxG;
        }
        if (float.TryParse(txtTeta, out auxTeta))
        {
            teta = auxTeta;
        }
    }

    private void Up(InputField numar, float val)
    {
        string nr = numar.text;
        if (float.TryParse(nr, out val))
        {
            if (val > 0 && val != -0.05f)
            {
                val += val * 0.10f;
            }
            else if (val < 0 && val != -0.05f)
            {
                val -= val * 0.10f;
            }
            else
            {
                val = 0.10f;
            }
            numar.text = val.ToString("F2");
        }
        else
        {
            val = 0.10f;
            numar.text = val.ToString("F2");
        }
    }

    private void Down(InputField numar, float val)
    {
        string nrx = numar.text;
        if (float.TryParse(nrx, out val))
        {
            if (val < 0 && val != 0.05f)
            {
                val += val * 0.10f;
            }
            else if (val > 0 && val != 0.05f)
            {
                val -= val * 0.10f;
            }
            else
            {
                val = -0.10f;
            }
            numar.text = val.ToString("F2");
        }
        else
        {
            val = -0.10f;
            numar.text = val.ToString("F2");
        }
    }


    public void Upa()
    {
        Up(numarA, a);
    }

    public void DownA()
    {
        Down(numarA, a);
    }

    public void Upg()
    {
        Up(numarG, g);
    }

    public void DownG()
    {
        Down(numarG, g);
    }

    public void Upteta()
    {
        Up(numarTeta, teta);
    }

    public void DownTeta()
    {
        Down(numarTeta, teta);
    }

    public float GetA()
    {
        return a;
    }

    public float GetG()
    {
        return g;
    }
    public float GetTeta()
    {
        return teta;
    }

    public void SetActivA(bool val)
    {
      A.SetActive(val);
    }

    public void SetActivG(bool val)
    {
        G.SetActive(val);
    }

    public void SetActivTeta(bool val)
    {
        Teta.SetActive(val);
    }
}
