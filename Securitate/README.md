Acest proiect simuleaza doua tipuri de atacuri asupra unei aplicatii Unity. Initial am dezvoltat o
aplicatie Unity in care nu am implementat nicio metoda de protectie, primul atac exploateaza
vulnerabilitatile legate de modul de stocare a variabilelor, folosind tool‑uri de citire a memoriei din
exteriorul aplicatiei, modificarea lor a fost foarte usoara. Pentru a combate aceste tipuri de atac am
criptat variabilele critice folosind algoritmul AES fara a afecta performanta aplicatiei. Al doilea tip de
atac exploateaza modul de compilare a aplicatiei, folosind tool‑uri de reverse engineering care
permit accesul la intregul cod sursa din exteriorul aplicatiei. Pentru a rezolva acesta problema, am
schimbat modul de compilare al aplicatiei pentru a creste dificultatea atacurilor de tip reverse
engineering.
