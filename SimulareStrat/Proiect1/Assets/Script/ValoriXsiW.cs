using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValoriXsiW : MonoBehaviour
{
    [SerializeField] private InputField numarX, numarW;
    private float x, w;


    private void Update()
    {
        string nrx = numarX.text;
        string nrw = numarW.text;
        float auxx, auxw;

        if (float.TryParse(nrx, out auxx )) 
        {
            x = auxx;
        }
        if (float.TryParse(nrw, out auxw)) 
        {
            w = auxw;
        }
    }

    public void Upx()
    {
        string nrx = numarX.text;
        if (float.TryParse(nrx, out x))
        {
            if (x > 0 && x != -0.05f)
            {
                x += x * 0.10f;
            }
            else if (x < 0 && x != -0.05f)
            {
                x -= x * 0.10f;
            }
            else
            {
                x = 0.10f;
            }
            numarX.text = x.ToString("F2");
        }
        else
        {
            x = 0.10f;
            numarX.text = x.ToString("F2");
        }
    }
    public void Downx()
    {
        string nrx = numarX.text;
        if (float.TryParse(nrx, out x))
        {
            if (x < 0 && x != 0.05f)
            {
                x += x * 0.10f;
            }
            else if(x > 0 && x != 0.05f) 
            {
                x -= x * 0.10f;
            }
            else
            {
                x = -0.10f;
            }
            numarX.text = x.ToString("F2");
        }
        else
        {
            x = -0.10f;
            numarX.text = x.ToString("F2");
        }
    }
    
    public void Upw()
    {
        string nrw = numarW.text;
        if (float.TryParse(nrw, out w))
        {
            if (w > 0 && w != -0.05f)
            {
                w += w * 0.10f;
            }
            else if (w < 0 && w != -0.05f)
            {
                w -= w * 0.10f;
            }
            else
            {
                w = 0.10f;
            }
            numarW.text = w.ToString("F2");
        }
        else
        {
            w = 0.10f;
            numarW.text = w.ToString("F2");
        }
    }
    public void Downw()
    {
        string nrw = numarW.text;
        if (float.TryParse(nrw, out w))
        {
            if (w < 0 && w != 0.05f)
            {
                w += w * 0.10f;
            }
            else if (w > 0 && w != 0.05f)
            {
                w -= w * 0.10f;
            }
            else
            {
                  w = -0.10f;
            }
            numarW.text = w.ToString("F2");
        }
        else
        {
            w = -0.10f;
            numarW.text = w.ToString("F2");
        }
    }

    public float GetX()
    {
        return x;
    }

    public float GetW()
    {
        return w;
    }
}
