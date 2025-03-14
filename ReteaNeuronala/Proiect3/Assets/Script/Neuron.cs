using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Neuron
{
    public double x, activare, iesire, gin, eroare;
    public List<double> w = new List<double>();
    public Neuron()
    {

    }

    public Neuron(Neuron neuron)
    {
        this.x = neuron.x;
        this.activare = neuron.activare;
        this.iesire = neuron.iesire;
        this.gin = neuron.gin;
        this.eroare = neuron.eroare;
        this.w = new List<double>(neuron.w);
    }



    public void InitializareW(int nrW)
    {
        for (int i = 0; i < nrW; i++)
        {
            double random = Random.Range(-1f, 1f);
            w.Add(random);
        }
    }


    public void Suma(List<Neuron> neuroniPrecedenti)
    {
        gin = 0;
        for (int i = 0; i < neuroniPrecedenti.Count; i++)
        {
            Neuron neuron = neuroniPrecedenti[i];
            gin +=  neuron.iesire * w[i];
        }
    }

    public void Sigmoid()
    {
        activare = 1 / (1 + Math.Pow(Math.E, -gin));
        iesire = activare;
    }

    public object Clone()
    {
        return new Neuron(this);
    }
}
