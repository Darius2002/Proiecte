package clase;
public class Utilizator{
    private String nume, parola;
    private int portofel, nrPersoane;
    private static Utilizator iniUtilizator;

    public static Utilizator Init(String nume, String parola)
    {
        if (iniUtilizator == null)
        {
            iniUtilizator = new Utilizator(nume, parola);
        }
        return iniUtilizator;
    }

    public static Utilizator Init()
    {
        if (iniUtilizator == null)
        {
            iniUtilizator = new Utilizator();
        }
        return iniUtilizator;
    }


    private Utilizator(String nume, String parola)
    {
        this.nume = nume;
        this.parola = parola;
    }

    private Utilizator()
    {

    }

    public void setPortofel(int portofel) {
        this.portofel = portofel;
    }

    public void setNrPersoane(int nrPersoane) {
        this.nrPersoane = nrPersoane;
    }

    public void adugarePortofel(int suma)
    {
        portofel += suma;
    }
    public int getPortofel() {
        return portofel;
    }
    public int getNrPersoane() {
        return nrPersoane;
    }
    public String getNume()
    {
        return nume;
    }
    public String getParola()
    {
        return parola;
    }

    public void ScaderePersoane(int nr){
        nrPersoane -= nr;
    }

    public void scaderePortfel(int nr)
    {
        portofel -= nr;
    }
}
