package clase;
public class Camere implements Iinterfata{
    private boolean standard, mediu, ridicat;
    static final int PretStandard = 100 , PretMediu = 150, PretRidicat = 300, NrMAXpersoane = 5;
    private int nrPersoane;
    
    public Camere(String s, int nrPersoane){
        this.nrPersoane = nrPersoane;
        if (s.equals("Standard"))
        {
            standard = true;
        }
        else if (s.equals("Mediu"))
        {
            mediu = true;
        }
        else 
        {
            ridicat = true;
        }
    }
    public Camere(Object o)
    {   
        if(o == null || !(o instanceof Camere))
        {
            return;
        }
        else{
            Camere aux = (Camere) o;
            this.mediu = aux.mediu;
            this.nrPersoane = aux.nrPersoane;
            this.standard = aux.standard;
            this.ridicat = aux.ridicat;
        }
    }

    public Camere(){

    }
   @Override
    public String Afisare(){
        return "Numarul maxim " + NrMAXpersoane;
    }
    static int pret(String s)
    {
         if (s.equals("Standard"))
        {
            return PretStandard;
        }
        else if (s.equals("Mediu"))
        {
           return PretMediu;
        }
        else 
        {
          return PretRidicat;  
        }
    }

    public int getNrPersoane() {
        return nrPersoane;
    }
    
    @Override
    public String toString() {
        return "Tipul de camera standard: " + standard + " mediu: " 
        + mediu + " ridicat: " + ridicat 
        + " si numarul de persoane cazate este " + nrPersoane;
    }
}
