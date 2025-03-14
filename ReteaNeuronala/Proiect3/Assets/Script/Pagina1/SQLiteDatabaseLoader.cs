using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SQLite;
using UnityEngine.UIElements.Experimental;
using System;
public class PreluareDate : MonoBehaviour
{
    [SerializeField] private GameObject pag2;
    private string dbFileName = "Masini.db", persistentDbPath, marca;
    private List<Masina> Masini = new List<Masina>();
    private List<Masina> Testare = new List<Masina>();


    private int AnMax = int.MinValue, AnMin = int.MaxValue, PretMax = int.MinValue, PretMin = int.MaxValue, MileMax = int.MinValue, MileMin = int.MaxValue;
    private double ConsumMax = double.MinValue, ConsumMin = double.MaxValue, CapacitateMax = double.MinValue, CapacitateMin = double.MaxValue;
    private double mAn, nAn, mPret, nPret, mMile, nMile, mConsum, nConsum, mCapacitate, nCapacitate;


    void Start()
    {
        persistentDbPath = Path.Combine(Application.persistentDataPath, dbFileName);

        if (!File.Exists(persistentDbPath))
        {
            Debug.Log("Baza de date nu exista in persistentDataPath. O copiez din StreamingAssets.");
            CopyDatabase();
        }
        else
        {
            var db = new SQLiteConnection(persistentDbPath);
        }
    }

    private void Update()
    {
        if (marca != null)
        {
            var db = new SQLiteConnection(persistentDbPath);
            if (marca == "Audi")
            {
                var query = db.Table<audi>().ToList();
                ExtractData(query);
            }
            else if (marca == "Bmw")
            {
                var query = db.Table<bmw>().ToList();
                ExtractData(query);
            }
            else if (marca == "Ford")
            {
                var query = db.Table<ford>().ToList();
                ExtractData(query);
            }
            else if (marca == "Opel")
            {
                var query = db.Table<opel>().ToList();
                ExtractData(query);
            }
            else if (marca == "VW")
            {
                var query = db.Table<vw>().ToList();
                ExtractData(query);
            }
            else
            {
                var query = db.Table<merc>().ToList();
                ExtractData(query);
            }
            marca = null;
        }
    }

    void CopyDatabase()
    {
        string sourcePath = Path.Combine(Application.streamingAssetsPath, dbFileName);

        if (File.Exists(sourcePath))
        {
            File.Copy(sourcePath, persistentDbPath);
        }
        else
        {
            Debug.LogError("Fisierul bazei de date nu a fost gasit în StreamingAssets.");
        }
    }

    void ExtractData<T>(List<T> query) where T : IVehicul
    {


        if (query.Count == 0)
        {
            return;
        }
        else
        {
            foreach (var masina in query)
            {
                Inregistrare(masina);

            }
            mAn =  Calculm(AnMin, AnMax);
            nAn = Calculn(AnMin, AnMax);
            mPret = Calculm(PretMin, PretMax);
            nPret = Calculn(PretMin, PretMax);
            mMile = Calculm(MileMin, MileMax);
            nMile = Calculn(MileMin, MileMax);
            mConsum = Calculm(ConsumMin, ConsumMax);
            nConsum = Calculn(ConsumMin, ConsumMax);
            mCapacitate = Calculm(CapacitateMin, CapacitateMax);
            nCapacitate = Calculn(CapacitateMin, CapacitateMax);

            foreach (Masina masina in Masini)
            {
                masina.NAn = mAn * masina.An + nAn;
                masina.NPret = mPret * masina.Pret + nPret;
                masina.NMile = mMile * masina.Mile + nMile;
                masina.NConsum = mConsum * masina.Consum + nConsum;
                masina.NCapacitate = mCapacitate * masina.Capacitate + nCapacitate;
                  /*  Debug.Log("An= " + masina.NAn +
                 ", Pret= " + masina.NPret +
                 ", Mile= " + masina.NMile +
                 ", Consum= " + masina.NConsum +
                 ", Capacitate= " + masina.NCapacitate + 
                 ", Transmisie= " + masina.NTransmisie + 
                 ", Conbustibil= " + masina.NCombustibil);
                 */
                if (masina.NAn < 0 || masina.NAn > 1)
                {
                    if (masina.NAn > 1.000000000000001)
                    {
                        masina.NAn = 1;
                    }
                    else
                    {
                        break;
                    }
                }
                if (masina.NConsum < 0 || masina.NConsum > 1)
                {
                    if (masina.NConsum < 1.000000000000001)
                    {
                        masina.NConsum = 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            int nrTestare = Masini.Count * 30 / 100;
            for(int i = 0; i < nrTestare; i++)
            {
                int random = UnityEngine.Random.Range(0, Masini.Count);
                Masina masina = Masini[random];
                Testare.Add(masina);
                Masini.RemoveAt(random);
            }
            gameObject.SetActive(false);
            pag2.SetActive(true);
        }
    }

    private int ConversieInt(string txt)
    {
        int aux = 0;
        if (int.TryParse(txt, out aux))
        {
            return aux;
        }
        return 0;
    }

    private double ConversieDouble(string txt)
    {
        double aux = 0;
        if (double.TryParse(txt, out aux)) { return aux; }
        return 0;
    }

    private void Inregistrare<T>(T masina) where T : IVehicul
    {
        Masina stocare = new Masina();
        stocare.An = ConversieInt(masina.An);
        stocare.Pret = ConversieInt(masina.Pret);
        if (masina.Transmisie == "Automatic")
        {
            stocare.NTransmisie = 0.5;
        }
        else if (masina.Transmisie == "Manual")
        {
            stocare.NTransmisie = 0.75;
        }
        else
        {
            stocare.NTransmisie = 1;
        }
        stocare.Mile = ConversieInt(masina.Mile);

        if (masina.Combustibil == "Diesel")
        {
            stocare.NCombustibil = 1;
        }
        else if (masina.Combustibil == "Petrol")
        {
            stocare.NCombustibil = 0.75;
        }
        else if (masina.Combustibil == "Hybrid")
        {
            stocare.NCombustibil = 0.5;
        }
        else if (masina.Combustibil == "Electric")
        {
            stocare.NCombustibil = 0.25;
        }
        else
        {
            stocare.NCombustibil = 0;
        }
        stocare.Consum = ConversieDouble(masina.Consum);
        stocare.Capacitate = ConversieDouble(masina.CapacitateCilindrica);
        Masini.Add(stocare);
        MinMax(stocare);
    }

    public void Selectare(int val)
    {
        if (val == 1)
        {
            marca = "Audi";
        }
        else if (val == 2)
        {
            marca = "Bmw";
        }
        else if (val == 3)
        {
            marca = "Ford";
        }
        else if (val == 4)
        {
            marca = "Opel";
        }
        else if (val == 5)
        {
            marca = "VW";
        }
        else
        {
            marca = "Mercedes";
        }

    }

    private void MinMax(Masina masina)
    {

        if (masina.An > AnMax)
        {
            AnMax = masina.An;
        }
        else if (masina.An < AnMin)
        {
            AnMin = masina.An;
        }

        if (masina.Pret > PretMax)
        {
            PretMax = masina.Pret;
        }
        else if (masina.Pret < PretMin)
        {
            PretMin = masina.Pret;
        }

        if (masina.Mile > MileMax)
        {
            MileMax = masina.Mile;
        }
        else if (masina.Mile < MileMin)
        {
            MileMin = masina.Mile;
        }

        if (masina.Consum > ConsumMax)
        {
            ConsumMax = masina.Consum;
        }
        else if (masina.Consum < ConsumMin)
        {
            ConsumMin = masina.Consum;
        }

        if (masina.Capacitate > CapacitateMax)
        {
            CapacitateMax = masina.Capacitate;
        }
        else if (masina.Capacitate < CapacitateMin)
        {
            CapacitateMin = masina.Capacitate;
        }
        
    }
    
    private double Calculm(double x, double y) 
    {
        return ((0-1)/(x-y));
    }

    private double Calculn(double x, double y)
    {
        return ((x * 1 - 0 * y) / (x - y));
    }

    public List<Masina> VectorIntare()
    {
        return Masini;
    }

    public List<Masina> GetTestare()
    {
        return Testare;
    }
    
}




public interface IVehicul
{
    string An { get; }
    string Pret { get; }
    string Transmisie { get; }
    string Mile { get; }
    string Combustibil { get; }
    string Consum { get; }
    string CapacitateCilindrica { get; }
}

public class audi : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}

public class bmw : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}
public class ford : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}

public class merc : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}

public class opel : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}

public class vw : IVehicul
{
    public string An { get; set; }
    public string Pret { get; set; }
    public string Transmisie { get; set; }
    public string Mile { get; set; }
    public string Combustibil { get; set; }
    public string Consum { get; set; }
    public string CapacitateCilindrica { get; set; }

}