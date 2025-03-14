package clase;

import clase.Camere;
public class Restaurant  extends Camere{
    private boolean ANimic, ABruschete, ACapreze, ASalam,
    PNimic, PPizza, PLasagna, PPaste, DNimic, DPanna, DProfi,
    DTira;

    public Restaurant(Camere aux, String Aperitiv, String Principal, String Desert)
    {
        super(aux);

        if(Aperitiv.equals("Nimic"))
        {
            ANimic = true;
        }
        else if (Aperitiv.equals("Bruschete / 15 lei "))
        {
            ABruschete = true;
        }
        else if (Aperitiv.equals("Capreze / 20 lei "))
        {
            ACapreze = true;
        }
        else{
            ASalam = true;
        }

        if(Principal.equals("Nimic"))
        {
            PNimic = true;
        }
        else if (Principal.equals("Pizza / 35 lei "))
        {
            PPizza = true;
        }
        else if (Principal.equals("Lasagna / 40 lei "))
        {
            PLasagna = true;
        }
        else{
            PPaste = true;
        }

        if (Desert.equals("Nimic"))
        {
            DNimic = true;
        }
        else if (Desert.equals("Panna Cotta / 25 lei "))
        {
            DPanna = true;
        }
        else if (Desert.equals("Profiterol / 25 lei"))
        {
            DProfi = true;
        }
        else{
            DTira = true;
        }
    }

    public Restaurant(String Aperitiv, String Principal, String Desert){
        super();

        if(Aperitiv.equals("Nimic"))
        {
            ANimic = true;
        }
        else if (Aperitiv.equals("Bruschete / 15 lei "))
        {
            ABruschete = true;
        }
        else if (Aperitiv.equals("Capreze / 20 lei "))
        {
            ACapreze = true;
        }
        else{
            ASalam = true;
        }

        if(Principal.equals("Nimic"))
        {
            PNimic = true;
        }
        else if (Principal.equals("Pizza / 35 lei "))
        {
            PPizza = true;
        }
        else if (Principal.equals("Lasagna / 40 lei "))
        {
            PLasagna = true;
        }
        else{
            PPaste = true;
        }

        if (Desert.equals("Nimic"))
        {
            DNimic = true;
        }
        else if (Desert.equals("Panna Cotta / 25 lei "))
        {
            DPanna = true;
        }
        else if (Desert.equals("Profiterol / 25 lei"))
        {
            DProfi = true;
        }
        else{
            DTira = true;
        }
    }

    public String Afisare()
    {
        return super.Afisare() + " persoane";
    }

    public String Afisare(int i){
        return "Acesta este " + super.Afisare() + "de persoane";
    }

    @Override
    public String toString() {
        return super.toString() + " Comanda Aperitiv: Nimic : " +
        ANimic + " Bruschete = " + ABruschete + " Capreze = " 
        + ACapreze + " Platou salam = " + ASalam 
        + " Comanda Fel Principal: Nimic :" + PNimic 
        + " Pizza = " + PPizza + " Lasagna = " + PLasagna + " Paste = " 
        + PPaste + " Desert: Nimic : " + DNimic + " Panna Cotta = " 
        + DPanna + " Profiterol = " + DProfi + " Tiramisu = " + DTira;
    }
}
