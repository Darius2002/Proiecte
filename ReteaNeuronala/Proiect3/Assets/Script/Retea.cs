using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.Arm;

public class Retea : MonoBehaviour
{
    [SerializeField] private PreluareDate pag1;
    [SerializeField] private Pagina2 pag2;
    private List<Masina> dateIntrare;
    private List<Masina> dateTestare;
    private List<Neuron> neuroniIntare = new List<Neuron>();
    private List<Neuron> neuroniStrat1 = new List<Neuron>();
    private List<Neuron> neuroniStrat2 = new List<Neuron>();
    private List<Neuron> neuroniStrat3 = new List<Neuron>();
    private List<Neuron> neuroniStratOut = new List<Neuron>();
    private int nrStraturi, nrNeuroni1, nrNeuroni2, nrNeuroni3, nrEpoci;
    private double eroareaAdmisa;
    private double rataInvatare;
    private List<double> eroripas = new List<double>();
    private List<double> eroareEpoca = new List<double>();
    private List<double> eroareStrat1 = new List<double>();
    private List<double> eroareStrat2 = new List<double>();
    private List<double> eroareStrat3 = new List<double>();
    private List<double> eroareStratOut = new List<double>();
    private List<double> iesireStratIntrare = new List<double>();
    private List<double> iesireStrat1 = new List<double>();
    private List<double> iesireStrat2 = new List<double>();
    private List<double> iesireStrat3 = new List<double>();
    private List<double> iesireStratOut = new List<double>();
    private List<List<Neuron>> retea = new List<List<Neuron>>();
    private bool caratina = true;

    List<Neuron> testareIntrare, testareStrat1, testareStrat2, testareStrat3, testareOut;



    [SerializeField] private LineRenderer lineRenderer;
    private float inaltimeMax = 5f, latimeEcran = 17f;
    [SerializeField] private float factorDeScalare = 10f;
    [SerializeField] private float offsetX = -1.0f;

    [SerializeField] private GameObject gPag3;
    [SerializeField] private GameObject gPag2;

    [SerializeField] private Text nrEpoca;
    [SerializeField] private Text nrEpocaEroare;
    [SerializeField] private Text nrEroareAbsoluta;
    [SerializeField] private Text nrProcent;
    [SerializeField] private Text nrEpocaEroare1;

    private void Update()
    {
        if (!caratina)
        {
            Testare();
            caratina = true;
            neuroniIntare.Clear();
            neuroniStrat1.Clear();
            neuroniStrat2.Clear();
            neuroniStrat3.Clear();
            neuroniStratOut.Clear();
            testareIntrare.Clear();
            testareStrat1.Clear();
            if(testareStrat2 != null)
            {
                testareStrat2.Clear();
                if(testareStrat3 != null)
                {
                    testareStrat3.Clear();
                }
            }
            testareOut.Clear();
            eroareEpoca.Clear();
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        dateIntrare = pag1.VectorIntare();
        dateTestare = pag1.GetTestare();
        nrStraturi = pag2.GetnrStraturi();
        nrNeuroni1 = pag2.GetnrNeuroni1();
        nrNeuroni2 = pag2.GetnrNeuroni2();
        nrNeuroni3 = pag2.GetnrNeuroni3();
        nrEpoci = pag2.GetNrEpoci();
        eroareaAdmisa = pag2.GetEroareaAdmisa();
        rataInvatare = pag2.GetRata();
        StartCoroutine(Calcul());
    }
    private IEnumerator Calcul()
    {
        CreareSiInitializare();
        nrEroareAbsoluta.text = "0";
        nrProcent.text = "0";
        double eroareEpocaPrecedenta = double.MaxValue;
        for (int j = 0; j < nrEpoci; j++)
        {
            for (int i = 0; i < dateIntrare.Count; i++)
            {
                Masina m = dateIntrare[i];
                NeuroniIntare(m);
                CalculareSumasiSigm();
                CalculEroarePas(m);
                CalculEroapreNeuronOut(m);
                CalculEroapreNeuron();
            }

            Actualizare();
            CalculEroareEpoca();
            Debug.Log($"Epoca {j + 1}, Eroare medie: {eroareEpoca[j]}");

            if (eroareEpoca[j] > eroareEpocaPrecedenta)
            {
                //Debug.Log("Procesul a fost oprit deoarece eroare de epoca a incept sa creasca");
                caratina = false;
                yield break;
            }

            eroareEpocaPrecedenta = eroareEpoca[j];
            ActualizareGrafic(eroareEpoca);

            SalvareRetea();

            iesireStratIntrare.Clear();
            iesireStrat1.Clear();
            iesireStrat2.Clear();
            iesireStrat3.Clear();
            iesireStratOut.Clear();
            eroripas.Clear();
            eroareStratOut.Clear();
            eroareStrat1.Clear();
            eroareStrat2.Clear();
            eroareStrat3.Clear();

            yield return null;
        }

        caratina = false;
    }


    private void ActualizareGrafic(List<double> erori)
    {
        lineRenderer.positionCount = erori.Count;
        float pasX = latimeEcran / Mathf.Max(erori.Count - 1, 1);
        nrEpocaEroare1.text = erori[0].ToString();
        if (erori[0] < 0.09f)
        {
            factorDeScalare = 100f;
        }

        for (int i = 0; i < erori.Count; i++)
        {
            nrEpoca.text = "Eroare pe epoca " + (i+1).ToString() + " :";
            nrEpocaEroare.text = erori[i].ToString();
            float x = i * pasX + offsetX;
            float y = Mathf.Clamp((float)erori[i] * factorDeScalare, 0, inaltimeMax);
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }
    private void Testare()
    {
        testareIntrare = retea[0];
        testareStrat1 = retea[1];
        if(retea.Count >= 4)
        {
            testareStrat2 = retea[2];
            if(retea.Count == 5)
            {
                testareStrat3 = retea[3];
                testareOut = retea[4];
            }
            else
            {
                 testareOut = retea[3];
            }
        }
        else
        {
            testareOut = retea[2];
        }

        double cnt = 0, eroareAbsoluta = 0, eroare = 0;
        for (int i = 0; i < dateTestare.Count; i++)
        {
            Masina m = dateTestare[i];
            NeuroniIntareTestare(m, testareIntrare);
            CalculTestare();
            Neuron neuron = testareOut[0];
            //Debug.Log("Valoare retea: " + neuron.iesire + " valoare tinta: " + m.NPret);
            eroareAbsoluta +=  Math.Abs(neuron.iesire - m.NPret);
            eroare =  Math.Abs(neuron.iesire - m.NPret);
            if (eroare <= eroareaAdmisa)
            {
                cnt++;
            }
        }
        double absolut = eroareAbsoluta / dateTestare.Count;
        double admisa = cnt / dateTestare.Count;
        nrEroareAbsoluta.text = (absolut * 100).ToString();
        nrProcent.text = (admisa * 100).ToString();
        Debug.Log("Eroare absoluta: " +  absolut * 100 + " Eroare pe eroare admisa: " + admisa * 100);
    }

    private void SalvareRetea()
    {
        retea.Clear();
        List<Neuron> list0 = neuroniIntare.Select(item => (Neuron)item.Clone()).ToList();
        List<Neuron> list1 = neuroniStrat1.Select(item => (Neuron)item.Clone()).ToList();
        retea.Add(list0);
        retea.Add(list1);
        if (neuroniStrat2.Count > 0)
        {
            List<Neuron> list2 = neuroniStrat2.Select(item => (Neuron)item.Clone()).ToList();
            retea.Add(list2);
            if (neuroniStrat3.Count > 0)
            {
                List<Neuron> list3 = neuroniStrat3.Select(item => (Neuron)item.Clone()).ToList();
                retea.Add(list3);
            }
        }
        List<Neuron> list4 = neuroniStratOut.Select(item => (Neuron)item.Clone()).ToList();
        retea.Add(list4);
    }

    private void Afisare()
    {
        for (int i = 0; i < retea.Count; i++)
        {
            List<Neuron> strat = retea[i];
            for (int j = 0; j < strat.Count; j++)
            {
                Neuron neuron = strat[j];
                Debug.Log("Strat " + i + " Neuron " + j +  " valoare iesier " + neuron.iesire);
            }
            Debug.Log("\n");
        }
    }

    private void Creare(int nrNeuroni, List<Neuron> salvare)
    {
        for (int i = 0; i < nrNeuroni; i++)
        {
            Neuron neuron = new Neuron();
            salvare.Add(neuron);
        }
    }

    private void InitializareW(int nrW, List<Neuron> list)
    {
        foreach (Neuron neuron in list)
        {
            neuron.InitializareW(nrW);
        }
    }

    private void CreareSiInitializare()
    {
        Creare(6, neuroniIntare);
        Creare(1, neuroniStratOut);
        if (nrStraturi >= 1)
        {
            Creare(nrNeuroni1, neuroniStrat1);
            if (nrStraturi >= 2)
            {
                Creare(nrNeuroni2, neuroniStrat2);
                if (nrStraturi == 3)
                {
                    Creare(nrNeuroni3, neuroniStrat3);
                }
            }
        }

        InitializareW(neuroniIntare.Count, neuroniStrat1);
        if (neuroniStrat2.Count > 0)
        {
            InitializareW(neuroniStrat1.Count, neuroniStrat2);

            if (neuroniStrat3.Count > 0)
            {
                InitializareW(neuroniStrat2.Count, neuroniStrat3);
                InitializareW(neuroniStrat3.Count, neuroniStratOut);
            }
            else
            {
                InitializareW(neuroniStrat2.Count, neuroniStratOut);
            }

        }
        else
        {
            InitializareW(neuroniStrat1.Count, neuroniStratOut);
        }
    }

    private void NeuroniIntare(Masina m)
    {
        for (int i = 0; i < neuroniIntare.Count; i++)
        {
            Neuron neuron = neuroniIntare[i];
            if (i == 0)
            {
                neuron.iesire = m.NAn;
            }
            else if (i == 1)
            {
                neuron.iesire = m.NMile;
            }
            else if (i == 2)
            {
                neuron.iesire = m.NConsum;
            }
            else if (i == 3)
            {
                neuron.iesire = m.NCapacitate;
            }
            else if (i == 4)
            {
                neuron.iesire = m.NTransmisie;
            }
            else if (i == 5)
            {
                neuron.iesire = m.NCombustibil;
            }
            iesireStratIntrare.Add(neuron.iesire);
        }
    }


    private void NeuroniIntareTestare(Masina m, List<Neuron> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Neuron neuron = list[i];
            if (i == 0)
            {
                neuron.iesire = m.NAn;
            }
            else if (i == 1)
            {
                neuron.iesire = m.NMile;
            }
            else if (i == 2)
            {
                neuron.iesire = m.NConsum;
            }
            else if (i == 3)
            {
                neuron.iesire = m.NCapacitate;
            }
            else if (i == 4)
            {
                neuron.iesire = m.NTransmisie;
            }
            else if (i == 5)
            {
                neuron.iesire = m.NCombustibil;
            }
        }
    }
    private void CalculIesire(List<Neuron> listaCurenta, List<Neuron> listaPrecedenta)
    {
        for(int i = 0;i < listaCurenta.Count;i++)
        {
            Neuron neuron = listaCurenta[i];
            neuron.Suma(listaPrecedenta);
            neuron.Sigmoid();

        }
    }
    private void CalculareSumasiSigm()
    {
        CalculIesire(neuroniStrat1, neuroniIntare);
        SalvareIesire(neuroniStrat1, iesireStrat1);
        if (neuroniStrat2.Count > 0)
        {
            CalculIesire(neuroniStrat2, neuroniStrat1);
            SalvareIesire(neuroniStrat2, iesireStrat2);
            if (neuroniStrat3.Count > 0)
            {
                CalculIesire(neuroniStrat3, neuroniStrat2);
                SalvareIesire(neuroniStrat3 , iesireStrat3);
                CalculIesire(neuroniStratOut, neuroniStrat3);
            }
            else
            {
                CalculIesire(neuroniStratOut, neuroniStrat2);
            }
        }
        else
        {
            CalculIesire(neuroniStratOut, neuroniStrat1);
        }
        SalvareIesire(neuroniStratOut , iesireStratOut);
    }

    private void CalculTestare()
    {
        CalculIesire(testareStrat1, testareIntrare);
        if (testareStrat2 != null)
        {
            CalculIesire(testareStrat2,testareStrat1);
            if (testareStrat3 != null)
            {
                CalculIesire(testareStrat3, testareStrat2);
                CalculIesire(testareOut, testareStrat3);
            }
            else
            {
                CalculIesire(testareOut, testareStrat2);
            }
        }
        else
        {
            CalculIesire(testareOut, testareStrat1);
        }
    }
    
    private void CalculEroarePas(Masina m)
    {
        for (int i = 0; i < neuroniStratOut.Count; i++)
        {
            Neuron neuron = neuroniStratOut[i];
            double eroarePas =  0.5 * Math.Pow((m.NPret - neuron.iesire), 2);
            eroripas.Add(eroarePas);
        }
    }

    private void CalculEroapreNeuronOut(Masina m)
    {
        foreach(Neuron neuron in neuroniStratOut)
        {
            double eroare = (-m.NPret + neuron.iesire) * neuron.iesire * (1 - neuron.iesire);
            eroareStratOut.Add(eroare);
        }
    }
    private void CalculEroapreNeuron()
    {
        Neuron neuronout = neuroniStratOut[0];
        if(neuroniStrat3.Count > 0)
        {
            for (int i = 0;i < neuroniStrat3.Count; i++)
            {
                Neuron neuron = neuroniStrat3[i];
                double eroare = (neuronout.w[i] * eroareStratOut[0]) * neuron.iesire * (1 - neuron.iesire); 
                eroareStrat3.Add(eroare);
                neuron.eroare = eroare;
            }

            for (int i = 0; i < neuroniStrat2.Count; i++)
            {
                Neuron neuron = neuroniStrat2[i];
                double sum = 0; 


                for (int j = 0;j < neuroniStrat3.Count; j++)
                {
                    Neuron neuronPrecedent = neuroniStrat3[j];

                    sum += neuronPrecedent.w[i] * eroareStrat3[j];
                }
                double eroare = sum * neuron.iesire * (1 - neuron.iesire);
                eroareStrat2.Add(eroare);
                neuron.eroare = eroare;
            }

            for (int i = 0; i < neuroniStrat1.Count; i++)
            {
                Neuron neuron = neuroniStrat1[i];
                double sum = 0;

                for (int j = 0; j < neuroniStrat2.Count; j++)
                {
                    Neuron neuronPrecedent = neuroniStrat2[j];

                    sum += neuronPrecedent.w[i] * eroareStrat2[j];
                }
                double eroare = sum * neuron.iesire * (1 - neuron.iesire);
                eroareStrat1.Add(eroare);
                neuron.eroare= eroare;
            }
        }
        else if (neuroniStrat2.Count > 0)
        {
            for (int i = 0; i < neuroniStrat2.Count; i++)
            {
                Neuron neuron = neuroniStrat2[i];
                double eroare = (neuronout.w[i] * eroareStratOut[0]) * neuron.iesire * (1 - neuron.iesire);
               eroareStrat2.Add(eroare);
               neuron.eroare = eroare;
            }

            for (int i = 0; i < neuroniStrat1.Count; i++)
            {
                Neuron neuron = neuroniStrat1[i];
                double sum = 0;

                for (int j = 0; j < neuroniStrat2.Count; j++)
                {
                    Neuron neuronPrecedent = neuroniStrat2[j];

                    sum += neuronPrecedent.w[i] * eroareStrat2[j];
                }
                double eroare = sum * neuron.iesire * (1 - neuron.iesire);
                eroareStrat1.Add(eroare);
                neuron.eroare = eroare;
            }

        }
        else
        {
            for (int i = 0; i < neuroniStrat1.Count; i++)
            {
                Neuron neuron = neuroniStrat1[i];
                double eroare = (neuronout.w[i] * eroareStratOut[0]) * neuron.iesire * (1 - neuron.iesire);
                eroareStrat1.Add(eroare);
                neuron.eroare = eroare;
            }
        }
    }

    private void SalvareIesire(List<Neuron> lisa, List<double> listaDeSalvat)
    {
        foreach (Neuron neuron in lisa)
        {
            listaDeSalvat.Add(neuron.iesire);
        }
    }

    private void Actualizare()
    {
        for (int i = 0; i < neuroniStrat1.Count; i++)
        {
            Neuron neuron = neuroniStrat1[i];
            for (int j = 0; j < neuroniIntare.Count; j++)
            {
                double a = -rataInvatare * (1d
                    / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStrat1, iesireStratIntrare, neuroniStrat1.Count, neuroniIntare.Count);
                neuron.w[j] = neuron.w[j] + a;
            }
        }

        if(neuroniStrat2.Count > 0)
        {
            for (int i = 0; i < neuroniStrat2.Count; i++)
            {
                Neuron neuron = neuroniStrat2[i];
                for (int j = 0; j < neuroniStrat1.Count; j++)
                {
                    neuron.w[j] = neuron.w[j] - rataInvatare * (1d / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStrat2, iesireStrat1, neuroniStrat2.Count, neuroniStrat1.Count);

                }
            }

            if(neuroniStrat3.Count > 0)
            {
                for (int i = 0; i < neuroniStrat3.Count; i++)
                {
                    Neuron neuron = neuroniStrat3[i];
                    for (int j = 0; j < neuroniStrat2.Count; j++)
                    {
                        neuron.w[j] = neuron.w[j] - rataInvatare * (1d / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStrat3, iesireStrat2, neuroniStrat3.Count, neuroniStrat2.Count);

                    }
                }
                for (int i = 0; i < neuroniStratOut.Count; i++)
                {
                    Neuron neuron = neuroniStratOut[i];
                    for (int j = 0; j < neuroniStrat3.Count; j++)
                    {
                        neuron.w[j] = neuron.w[j] - rataInvatare * (1d / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStratOut, iesireStrat3, neuroniStratOut.Count, neuroniStrat3.Count);

                    }
                }

            }
            else
            {
                for (int i = 0; i < neuroniStratOut.Count; i++)
                {
                    Neuron neuron = neuroniStratOut[i];
                    for (int j = 0; j < neuroniStrat2.Count; j++)
                    {
                        neuron.w[j] = neuron.w[j] - rataInvatare * (1d / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStratOut, iesireStrat2, neuroniStratOut.Count, neuroniStrat2.Count);

                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < neuroniStratOut.Count; i++)
            {
                Neuron neuron = neuroniStratOut[i];
                for (int j = 0; j < neuroniStrat1.Count; j++)
                {
                    double nr = -rataInvatare * (1d / dateIntrare.Count) * SumaStratEroareIesire(i, j, eroareStratOut, iesireStrat1, neuroniStratOut.Count, neuroniStrat1.Count);
                    neuron.w[j] = neuron.w[j] + nr;

                }
            }
        }
    }

    private double SumaStratEroareIesire(int nrNeuronStrat1, int nrNueroniIesireIntrare, List<double> listaErori, List<double> listIesir, int nrNeuroniEroare, int nrNueroniIesire)
    {
        double sum = 0;
        for (int i = 0; i < dateIntrare.Count; i++)
        {
            sum += listaErori[i * nrNeuroniEroare + nrNeuronStrat1] * listIesir[i *  nrNueroniIesire + nrNueroniIesireIntrare];
        }
        return sum;
    } 

    private void CalculEroareEpoca()
    {
        double sum = 0;
        for (int i = 0; i < eroripas.Count; i++)
        {
            sum += eroripas[i];
        }
        eroareEpoca.Add(sum/eroripas.Count);
    }

    public void Btn()
    {
        gPag3.SetActive(false);
        gPag2.SetActive(true);
    }
}
