using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Pagina2 : MonoBehaviour
{
    [SerializeField] private InputField nrNeuroni;
    [SerializeField] private InputField eroare;
    [SerializeField] private InputField epoci;
    [SerializeField] private InputField rata;
    [SerializeField] private Dropdown selectareNrStratuir;
    [SerializeField] private Dropdown selectateStratCurent;
    [SerializeField] private GameObject Calcul;
    [SerializeField] private GameObject pag3;
    private int stratCurent, nrNeuroni1, nrNeuroni2, nrNeuroni3, nrStraturi, nrEpoci;
    private double eroareVal;
    private double rataInvatare;

    private void Start()
    {
        eroare.text = "0";
        epoci.text = "0";
    }

    private void Update()
    {
        int aux = 0;
        double eroareAux = 0;
        if (stratCurent == 1)
        {
            if(int.TryParse(nrNeuroni.text, out aux))
            {
                if(aux < 0)
                {
                    aux = 0;
                    nrNeuroni.text = nrNeuroni1.ToString();
                }
                if (aux != nrNeuroni1 && aux != 0)
                {
                   
                    nrNeuroni1 = aux;
                    nrNeuroni.text = nrNeuroni1.ToString();
                }
            }
        }
        else if (stratCurent == 2)
        {
            if (int.TryParse(nrNeuroni.text, out aux))
            {
                if (aux < 0)
                {
                    aux = 0;
                    nrNeuroni.text = nrNeuroni2.ToString();
                }
                if (aux != nrNeuroni2 && aux != 0)
                {
                    nrNeuroni2 = aux;
                    nrNeuroni.text = nrNeuroni2.ToString();
                }
            }
        }
        else if (stratCurent == 3)
        {
            if (int.TryParse(nrNeuroni.text, out aux))
            {
                if (aux < 0)
                {
                    aux = 0;
                    nrNeuroni.text = nrNeuroni3.ToString();
                }
                if (aux != nrNeuroni3 && aux != 0)
                {
                    nrNeuroni3 = aux;
                    nrNeuroni.text = nrNeuroni3.ToString();
                }
            }
        }

        if (double.TryParse(eroare.text, out eroareAux))
        {
            if (eroareVal != eroareAux && eroareAux >= 0)
            {
                eroareVal = eroareAux;
            }
            else if (eroareAux < 0)
            {
                eroare.text = eroareVal.ToString();
            }
        }

        if (int.TryParse(epoci.text, out aux))
        {
            if (nrEpoci != aux && aux >= 0)
            {
                nrEpoci = aux;
            }
            else if (aux < 0)
            {
                epoci.text = nrEpoci.ToString();
            }
        }

        if (double.TryParse(rata.text, out eroareAux))
        {
            if (rataInvatare != eroareAux && eroareAux >= 0)
            {
                rataInvatare = eroareAux;
            }
            else if (eroareAux < 0)
            {
                rata.text = rataInvatare.ToString();
            }
           
           
        }
    }

    public void SelectareStrat(int val)
    {
        if (val == 1)
        {
            stratCurent = 1;
            nrNeuroni.text = nrNeuroni1.ToString();
        }
        else if (val == 2)
        {
            stratCurent = 2;
            nrNeuroni.text = nrNeuroni2.ToString();
        }
        else if (val == 3)
        {
            stratCurent = 3;
            nrNeuroni.text = nrNeuroni3.ToString();
        }
    }

    public void NrStraturi(int val)
    {
        if (val == 1)
        {
            nrStraturi = 1;
            selectateStratCurent.options.Add(new Dropdown.OptionData("1"));
        }
        else if (val == 2)
        {
            nrStraturi = 2;
            selectateStratCurent.options.Add(new Dropdown.OptionData("1"));
            selectateStratCurent.options.Add(new Dropdown.OptionData("2"));
        }
        else if (val == 3)
        {
            nrStraturi = 3;
            selectateStratCurent.options.Add(new Dropdown.OptionData("1"));
            selectateStratCurent.options.Add(new Dropdown.OptionData("2"));
            selectateStratCurent.options.Add(new Dropdown.OptionData("3"));
        }
        selectateStratCurent.RefreshShownValue();
        selectareNrStratuir.interactable = false;
        selectateStratCurent.interactable = true;
        nrNeuroni.interactable = true;
    }

    public void BtnNext()
    {
        gameObject.SetActive(false);
        pag3.SetActive(true);
        Calcul.SetActive(true);
    }

    public int GetnrStraturi()
    {
        return nrStraturi;
    }
    public int GetnrNeuroni1()
    {
        return nrNeuroni1;
    }
    public int GetnrNeuroni2()
    {
        return nrNeuroni2;
    }
    public int GetnrNeuroni3()
    {
        return nrNeuroni3;
    }
    public int GetNrEpoci()
    {
        return nrEpoci;
    }

    public double GetEroareaAdmisa()
    {
        return eroareVal;
    }

    public double GetRata()
    {
        return rataInvatare;
    }
}
