package clase;
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.util.ArrayList;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.security.Principal;
import java.io.FileWriter;
import java.io.BufferedWriter;
import java.io.IOException;

import javax.imageio.ImageIO;

public class InterfataMain {
    private int aux, cntApertiv, cntFelPrincipal, cntDesert;
    private String selectie;
    private String[] felPrincipal = new String[100], aperitiv = new String[100], desert = new String[100];
    private JFrame FereastraDeDeschidere;
    private Utilizator persoana;
    private String imagine = "false-2061131_1280.png";
    private ArrayList<Camere> list = new ArrayList<Camere>();
    private ArrayList listR = new ArrayList<Restaurant>();
    private boolean apasat;

    public InterfataMain(){ 
        FereastraDeDeschidere = new JFrame();
        ImageIcon iconita = new ImageIcon("Desktop - 20.png");
        FereastraDeDeschidere.setIconImage(iconita.getImage());
        FereastraDeDeschidere.setTitle("Hotel Firenze: Pagina de Deschidere");
        FereastraDeDeschidere.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        FereastraDeDeschidere.setSize(700, 300);
        FereastraDeDeschidere.setLocationRelativeTo(null);

        JPanel PanouPrincipal = new JPanel(new GridLayout(4, 1, 0, 0));
        PanouPrincipal.setBackground(new Color(255,230,145));
        
        JPanel rand1 = new JPanel();
        rand1.setBackground(new Color(255,230,145));
        JLabel text1 = new JLabel("Bun venit la Hotel Firenze");
        Font font = new Font("Cambria", Font.BOLD, 30);
        text1.setFont(font);
        rand1.add(text1);

        JPanel rand2 = new JPanel();
        rand2.setBackground(new Color(255,230,145));
        JLabel text2 = new JLabel("<html>Daca doriti sa va cazati apasa butonul <b>CREEAZA</b></html>");
        Font font1 = new Font("Cambria", Font.PLAIN, 20);
        text2.setFont(font1);
        rand2.add(text2);

        JPanel rand3 = new JPanel();
        rand3.setBackground(new Color(255,230,145));
        JLabel text3 = new JLabel("<html>Daca doriti sa mergeti doar la restaurant apasa butonul <b>URMATOR</b></html>");
        Font font2 = new Font("Cambria", Font.PLAIN,20);
        text3.setFont(font2);
        rand3.add(text3);

        JPanel rand4 = new JPanel();
        rand4.setBackground(new Color(255,230,145));
        JButton creeaza = new JButton("Creeaza");
        creeaza.setBackground(new Color(54,53,53));
        creeaza.setForeground(Color.WHITE);
        creeaza.setFont(new Font("Cambria", Font.BOLD,20));
        creeaza.setPreferredSize(new Dimension(130,50));
        creeaza.setFocusPainted(false);
        creeaza.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e){
                JFrame currentFrame = (JFrame) SwingUtilities.getWindowAncestor(creeaza);
                ImageIcon iconita2 = new ImageIcon("Desktop - 20.png");
                currentFrame.setIconImage(iconita2.getImage());
                currentFrame.dispatchEvent(new WindowEvent(currentFrame, WindowEvent.WINDOW_CLOSING));
                FereastraCreeazaCont();
            }
        });
        rand4.add(creeaza);
        JButton urmator = new JButton("Urmator");
        urmator.setBackground(new Color(54,53,53));
        urmator.setForeground(Color.WHITE);
        urmator.setFont(new Font("Cambria", Font.BOLD,20));
        urmator.setPreferredSize(new Dimension(130,50));
        urmator.setFocusPainted(false);
        urmator.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e){
                JFrame currentFrame = (JFrame) SwingUtilities.getWindowAncestor(urmator);
                currentFrame.dispatchEvent(new WindowEvent(currentFrame, WindowEvent.WINDOW_CLOSING));
                Urmator();
            }
        });
        rand4.add(urmator);

        
        PanouPrincipal.add(rand1);
        PanouPrincipal.add(rand2);
        PanouPrincipal.add(rand3);
        PanouPrincipal.add(rand4);
        FereastraDeDeschidere.add(PanouPrincipal);
    }
    public void show()
    {
        FereastraDeDeschidere.setVisible(true);
    }


    private void FereastraCreeazaCont() 
    {

        JFrame ferestra = new JFrame();
        SchimbareLogo(ferestra);
        ferestra.setTitle("Hotel Firenze: Creeaza cont");
        ferestra.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        ferestra.setSize(400, 300);
        ferestra.setLocationRelativeTo(null);

        JPanel PanouPrincipal = new JPanel(new GridLayout(5, 1));
        SchimbareCuloare(PanouPrincipal);


        JPanel rand1 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand1);
        JLabel text1 = new JLabel("Nume: ");
        setText(text1);
        rand1.add(text1);
        JTextField textField1 = new JTextField(20);
        rand1.add(textField1);

        JPanel rand2 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand2);
        JLabel text2 = new JLabel("Parola: ");
        setText(text2);
        rand2.add(text2);
        JTextField textField2 = new JTextField(20);
        rand2.add(textField2);

        JPanel rand3 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand3);
        JLabel text3 = new JLabel("Depunde o suma in portofelul contului: ");
        setText(text3);
        rand3.add(text3);
        JTextField textField3 = new JTextField(4);
        rand3.add(textField3);
        
        JPanel rand5 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand5);
        JLabel text5 = new JLabel("Numarul de persoane:");
        setText(text5);
        rand5.add(text5);
        JTextField textField4 = new JTextField(2);
        textField4.setLayout(new FlowLayout(FlowLayout.LEFT));
        rand5.add(textField4);

        JPanel rand4 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand4);
        JButton salveaza = new JButton("Salveaza");
        setButon(salveaza);
        salveaza.setLayout(new FlowLayout(FlowLayout.LEFT));
        salveaza.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e){
                String nr = textField3.getText();
                String parola = textField2.getText();
                String nume = textField1.getText();
                String nrP = textField4.getText();
                try{
                    int Nr = Integer.parseInt(nr);
                    int NrP = Integer.parseInt(nrP);
                    aux = NrP;
                    // fereastra modala
                    JFrame continuare = new JFrame("Continuare");
                    SchimbareLogo(continuare);
                    continuare.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                    continuare.setSize(300, 200);
                    continuare.setLocationRelativeTo(null);

                    JPanel panouMare = new JPanel(new GridLayout(2, 1));

                    JPanel panel1 = new JPanel();
                    SchimbareCuloare(panel1);
                    JLabel apas = new JLabel("Doriti sa continuati?");
                    apas.setFont(new Font("Cambria", Font.BOLD, 20));
                    panel1.add(apas);

                    JPanel panel2 = new JPanel();
                    SchimbareCuloare(panel2);
                    
                    JButton daButton = new JButton("Da");
                    setButon(daButton);
                    daButton.addActionListener(new ActionListener() {
                         public void actionPerformed(ActionEvent e){
                            persoana = Utilizator.Init(nume, parola);
                            persoana.setPortofel(Nr);
                            persoana.setNrPersoane(NrP);
                            JFrame currentFrame = (JFrame) SwingUtilities.getWindowAncestor(daButton);
                            currentFrame.dispatchEvent(new WindowEvent(currentFrame, WindowEvent.WINDOW_CLOSING));
                            ferestra.dispose();
                            AdaugareCamere();
                            
                         }
                    });
                    panel2.add(daButton);

                    JButton nuButton = new JButton("Nu");
                    setButon(nuButton);
                    nuButton.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent e)
                        {
                            continuare.dispose();
                        }
            
                    });
                    panel2.add(nuButton);

                    panouMare.add(panel1);
                    panouMare.add(panel2);
                    continuare.add(panouMare);
                    continuare.setVisible(true);
                }
                catch(NumberFormatException nu){
                    Eroare();
                }
            }
        });
        rand4.add(salveaza);


        PanouPrincipal.add(rand1);
        PanouPrincipal.add(rand2);
        PanouPrincipal.add(rand3);
        PanouPrincipal.add(rand5);
        PanouPrincipal.add(rand4);
        ferestra.add(PanouPrincipal);
        ferestra.setVisible(true);
    }

    private void Urmator() 
    {
        JFrame fereastra = new JFrame();
        SchimbareLogo(fereastra);
        fereastra.setTitle("Hotel Firenze: Selectie");
        fereastra.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        fereastra.setSize(300, 200);
        fereastra.setLocationRelativeTo(null);

        JPanel PanouPrincipal = new JPanel(new GridLayout(3, 1));
        SchimbareCuloare(PanouPrincipal);

        JPanel rand1 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand1);
        JLabel text1 = new JLabel("Depunde o suma in portofelul: ");
        setText(text1);
        rand1.add(text1);
        JTextField textField1 = new JTextField(4);
        rand1.add(textField1);

        JPanel rand3 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand3);
        JLabel text3 = new JLabel("Numarul de persoane");
        setText(text3);
        rand3.add(text3);
        JTextField textField3 = new JTextField(2);
        rand3.add(textField3);

        JPanel rand2 = new JPanel(new FlowLayout(FlowLayout.LEFT));
        SchimbareCuloare(rand2);
        JButton salveaza = new JButton("Salveaza");
        setButon(salveaza);
        salveaza.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e){
                String nr = textField1.getText();
                String nrP = textField3.getText();
                try{
                    int Nr = Integer.parseInt(nr);
                    int NrP = Integer.parseInt(nrP);

                    JFrame continuare = new JFrame("Continuare");
                    continuare.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                    continuare.setSize(300, 200);
                    continuare.setLocationRelativeTo(null);

                    JPanel panouMare = new JPanel(new GridLayout(2, 1));
                    SchimbareCuloare(panouMare);

                    JPanel panel1 = new JPanel();
                    SchimbareCuloare(panel1);
                    JLabel apas = new JLabel("Doriti sa continuati?");
                    apas.setFont(new Font("Cambria", Font.BOLD, 20));
                    panel1.add(apas);

                    JPanel panel2 = new JPanel();
                    SchimbareCuloare(panel2);

                    JButton daButton = new JButton("Da");
                    setButon(daButton);
                    daButton.addActionListener(new ActionListener() {
                         public void actionPerformed(ActionEvent e){
                            persoana = Utilizator.Init();
                            persoana.setPortofel(Nr);
                            persoana.setNrPersoane(NrP);
                            fereastra.dispose();
                            continuare.dispose();
                            aux = NrP;
                            Restaurant();
                         }
                    });
                    panel2.add(daButton);

                    JButton nuButton = new JButton("Nu");
                    setButon(nuButton);
                    nuButton.addActionListener(new ActionListener() {
                        public void actionPerformed(ActionEvent e)
                        {
                            continuare.dispose();
                        }
            
                    });
                    panel2.add(nuButton);

                    panouMare.add(panel1);
                    panouMare.add(panel2);
                    continuare.add(panouMare);
                    continuare.setVisible(true);

                    
                }
                catch(NumberFormatException nu)
                {
                    Eroare();
                }  
            }
        });
        rand2.add(salveaza);
        

        PanouPrincipal.add(rand1);
        PanouPrincipal.add(rand3);
        PanouPrincipal.add(rand2);
        fereastra.add(PanouPrincipal);
        fereastra.setVisible(true);
    }

    private void AdaugareCamere() 
    {
        JFrame frame = new JFrame("Selectare");
        SchimbareLogo(frame);
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        frame.setSize(600, 600);
        frame.setLocationRelativeTo(null);

        JPanel panelPrincipal = new JPanel(new GridLayout(5,1));
        SchimbareCuloare(panelPrincipal);

        JPanel panel5 = new JPanel();
        SchimbareCuloare(panel5);
        JLabel label2 = new JLabel( "Nivelele de confort ale camerelor:");
        label2.setFont(new Font("Cambria", Font.BOLD, 25));
        panel5.add(label2);

        panel5.setLayout(new BoxLayout(panel5, BoxLayout.Y_AXIS));

        String[] optiuni2 = {"Standard / 100 per persoana", "Mediu / 150 per persoana", "Ridicat / 300 per persoana"};

        for (int i = 0; i < optiuni2.length; i++)
        {
            String optiune = optiuni2[i];
            JLabel label5 = new JLabel(optiune);
            setText(label5);
            JPanel eticheta = new JPanel();
            SchimbareCuloare(eticheta);
            eticheta.add(label5);
            eticheta.setAlignmentX(Component.CENTER_ALIGNMENT);
            panel5.add(eticheta);
        }



        JPanel panel1 = new JPanel();
        SchimbareCuloare(panel1);
        JLabel text1 = new JLabel("Numarul de persoane : " + persoana.getNrPersoane());
        setText(text1);
        panel1.add(text1);
        JLabel text2 = new JLabel("     Portofelul contului : " + persoana.getPortofel());
        setText(text2);
        panel1.add(text2);

        JPanel panel2 = new JPanel();
        SchimbareCuloare(panel2);
        String[] optiuni = {"Standard", "Mediu", "Ridicat"};
        JComboBox<String> box = new JComboBox<>(optiuni);
        Font fontCurent = box.getFont();
        Font font = new Font(fontCurent.getName(), fontCurent.getStyle(), 15);
        box.setFont(font);
        box.setPreferredSize(new Dimension(200,50));
        box.setSize(20, 5);
        box.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
            {
                String da = (String) box.getSelectedItem();
                selectie = da;
                JOptionPane.showMessageDialog(null, "Optiune selectata " + selectie);
            }

        });
        panel2.add(box);


        JPanel panel3 = new JPanel();
        SchimbareCuloare(panel3);
        JLabel label = new JLabel ("Numarul de persoane cazate in camera : ");
        setText(label);
        panel3.add(label);
        JTextField text = new JTextField(3);
        panel3.add(text);

        JPanel panel4 = new JPanel();
        SchimbareCuloare(panel4);
        JButton salveaza = new JButton("Salveaza");
        setButon(salveaza);
        salveaza.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e){
                String nrP = text.getText();
                try{
                    int NrP = Integer.parseInt(nrP);
                    if (NrP > 5)
                    {
                        JOptionPane.showMessageDialog(null, "Nu poti avea mai mult de 5 persoane in camera");
                    }
                    else if (NrP > persoana.getNrPersoane()){
                        JOptionPane.showMessageDialog(null, "Numarul de persoane selectate in aceasta camera este mai mare decat persoanele ce trebuie cazate");
                    }
                    else if (selectie == null)
                    {
                        JOptionPane.showMessageDialog(null, "Nu ati selectat camera");
                    }
                    else{
                        
                        int suma = NrP * Camere.pret(selectie);
                        if (suma > persoana.getPortofel())
                        {
                            frame.dispose();
                            JFrame frame5 = new JFrame("Eroare");
                            SchimbareLogo(frame5);
                            frame5.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                            frame5.setSize(600, 300);
                            frame5.setLocationRelativeTo(null);

                            JPanel panelPrincipal = new JPanel(new GridLayout(2,1));

                            JPanel panel1 = new JPanel();
                            SchimbareCuloare(panel1);
                            JLabel label2 = new JLabel("Nu aveti destui bani in portofel, va rog sa adaugati mai multi bani");
                            label2.setFont(new Font("Cambria", Font.BOLD, 15));
                            panel1.add(label2);

                            JPanel panel2 = new JPanel();
                            SchimbareCuloare(panel2);
                            JButton buton = new JButton("Adauga");
                            setButon(buton);

    
                            buton.addActionListener(new ActionListener() {
                             public void actionPerformed(ActionEvent e){
                                frame5.dispose();
                                JFrame frame6 = new JFrame();
                                frame6.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                                frame6.setSize(400, 200);
                                frame6.setLocationRelativeTo(null);

                                JPanel panouPrincipal = new JPanel(new GridLayout(2,1));

                                JPanel panou1 = new JPanel();
                                SchimbareCuloare(panou1);
                                JLabel text = new JLabel("Adauga suma : ");
                                JTextField field = new JTextField(4);
                                panou1.add(text);
                                panou1.add(field);

                                JPanel panou2 = new JPanel();
                                SchimbareCuloare(panou2);
                                JButton ok = new JButton("Ok");
                                setButon(ok);
                                ok.addActionListener(new ActionListener() {
                                     public void actionPerformed(ActionEvent e){
                                        String numarPr = field.getText();
                                        try{
                                            int NumarPr = Integer.parseInt(numarPr);
                                            persoana.adugarePortofel(NumarPr);
                                            frame6.dispose();
                                            AdaugareCamere();
                                        }catch(NumberFormatException nu)
                                        {
                                            JOptionPane.showMessageDialog(null, "Nu ai introdus numar");
                                        }
                                     }
                                });
                                panou2.add(ok);



                                panouPrincipal.add(panou1);
                                panouPrincipal.add(panou2);
                                frame6.add(panouPrincipal);
                                frame6.setVisible(true);                            
                             }
                            });
                            panel2.add(buton);

                            panelPrincipal.add(panel1);
                            panelPrincipal.add(panel2);
                            frame5.add(panelPrincipal);
                            frame5.setVisible(true);
                        }
                        else{
                            list.add(new Camere(selectie, NrP));
                            persoana.ScaderePersoane(NrP);
                            persoana.scaderePortfel(suma);
                            frame.dispose();
                            if(persoana.getNrPersoane() == 0)
                            {
                                persoana.setNrPersoane(aux);
                                JFrame frameNou = new JFrame();
                                SchimbareLogo(frameNou);
                                frameNou.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                                frameNou.setSize(300, 200);
                                frameNou.setLocationRelativeTo(null);
                                JPanel panouMare = new JPanel(new GridLayout(2,1));

                                JPanel panou1 = new JPanel();
                                SchimbareCuloare(panou1);
                                JLabel label2 = new JLabel("Vreti sa mergeti la restaurant?");
                                panou1.add(label2);
                                
                                JPanel panou2 = new JPanel();
                                SchimbareCuloare(panou2);
                                JButton da = new JButton("Da");
                                setButon(da);
                                
                                da.addActionListener(new ActionListener() {
                                    public void actionPerformed(ActionEvent e){
                                        frameNou.dispose();
                                        Logare();
                                    }
                                });
                                panou2.add(da);

                                JButton nu = new JButton("Nu");
                                setButon(nu);
                                nu.addActionListener(new ActionListener(){
                                    public void actionPerformed(ActionEvent e){
                                        frameNou.dispose();
                                        FereastraFinal();
                                    }
                                });
                                panou2.add(nu);


                                panouMare.add(panou1);
                                panouMare.add(panou2);
                                frameNou.add(panouMare);
                                frameNou.setVisible(true);
                            }
                            else{
                                AdaugareCamere();
                            }
                        }
                    }
                }
                catch(NumberFormatException nu){
                    JOptionPane.showMessageDialog(null, "Nu ai introdus numar");
                }
            }
        });
        panel4.add(salveaza);

        panelPrincipal.add(panel5);
        panelPrincipal.add(panel1);
        panelPrincipal.add(panel2);
        panelPrincipal.add(panel3);
        panelPrincipal.add(panel4);
        frame.add(panelPrincipal);
        frame.setVisible(true);

    }
    
    private void Logare()
    {
        JFrame frame = new JFrame("Hotel Firenze: Beneficii");
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        frame.setSize(600, 400);
        frame.setLocationRelativeTo(null);
        SchimbareLogo(frame);

        JPanel panouPrincipal = new JPanel(new GridLayout(4, 1));
        JPanel panou1 = new JPanel();
        SchimbareCuloare(panou1);
        JLabel label = new JLabel("Daca doresti sa beneficiezi de 10% reducere, logheaza-te, altfel, apasa nu");
        label.setFont(new Font("Cambria", Font.BOLD, 15));
        panou1.add(label);

        JPanel panou2 = new JPanel();
        SchimbareCuloare(panou2);
        JLabel label2 = new JLabel("Nume: ");
        JTextField nume = new JTextField(20);
        panou2.add(label2);
        panou2.add(nume);

        JPanel panou3 = new JPanel();
        SchimbareCuloare(panou3);
        JLabel label3 = new JLabel("Parola: ");
        JTextField parola = new JTextField(20);
        panou3.add(label3);
        panou3.add(parola);


        JPanel panou4 = new JPanel();
        SchimbareCuloare(panou4);
        JButton logareButton = new JButton("Logare");
        setButon(logareButton);

        logareButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e){
                String nume2 = nume.getText();
                String parola2 = parola.getText();
                if (!(nume2.equals(persoana.getNume())) || !(parola2.equals(persoana.getParola())))
                {
                    JOptionPane.showMessageDialog(null, "Numele / parola sunt gresite");
                }
                else
                {
                    frame.dispose();
                    apasat = true;
                    Restaurant();
                }

            }
        });
        panou4.add(logareButton);

        JButton nuButton = new JButton("Nu");
        setButon(nuButton);
        nuButton.addActionListener(new ActionListener(){
            public void actionPerformed(ActionEvent e)
            {
                frame.dispose();
                Restaurant();
            }
        });
        panou4.add(nuButton);


        panouPrincipal.add(panou1);
        panouPrincipal.add(panou2);
        panouPrincipal.add(panou3);
        panouPrincipal.add(panou4);

        frame.add(panouPrincipal);
        frame.setVisible(true);
    }

    private void Eroare()
    {           
        JPanel panelMare = new JPanel();
        JPanel panel1 = new JPanel(new FlowLayout(FlowLayout.RIGHT));
        JFrame eroare = new JFrame();
        eroare.setTitle("eroare");
        eroare.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        eroare.setSize(300, 100);
        eroare.setLocationRelativeTo(null);

        JLabel text4 = new JLabel("Adaugati o valoare numerica");
        setText(text4);
        panel1.add(text4);

        try{
            ImageIcon imagine2 = new ImageIcon(imagine);
            Image imagineRedimensionata = imagine2.getImage().getScaledInstance(30, 30, Image.SCALE_SMOOTH);
            ImageIcon imagineNoua = new ImageIcon(imagineRedimensionata);
            JLabel label = new JLabel(imagineNoua);
            panelMare.add(label, BorderLayout.WEST); 
            panelMare.add(text4, BorderLayout.CENTER);

            eroare.add(panelMare);
            eroare.setVisible(true);
            eroare.setVisible(true);
        } catch(java.awt.image.ImagingOpException ex)
        {
            ex.printStackTrace();
        }
    }

    private void SchimbareCuloare(JPanel panel)
    {
        panel.setBackground(new Color(250,230,145));
    }

    private void setButon(JButton buton)
    {
        buton.setBackground(new Color(54,53,53));
        buton.setForeground(Color.WHITE);
        buton.setFont(new Font("Cambria", Font.BOLD,20));
        //buton.setPreferredSize(new Dimension(130,50));
        buton.setFocusPainted(false);
    }

    private void setText(JLabel label)
    {
        label.setFont(new Font("Cambria", Font.BOLD, 15));
    }

    private void Restaurant()
    {
        JFrame frame = new JFrame();
        SchimbareLogo(frame);
        frame.setTitle("Hotel Firenze : Restaurant");
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        frame.setSize(1300, 700);
        frame.setLocationRelativeTo(null);

        JPanel panouPrincipal = new JPanel(new GridLayout(3, 1, 0, 0));
        JPanel panou1 = new JPanel();
        SchimbareCuloare(panou1);
        JLabel label = new JLabel("Bine ati venit in restaurantul nostru ");
        panou1.add(label);

        String[] aperitiv1 = {"Nimic", "Bruschete / 15 lei ", "Capreze / 20 lei ", "Platou cu salamuri italiene / 25 lei "},
        felPrincipal2 = {"Nimic", "Pizza / 35 lei ", "Lasagna / 40 lei ", "Pasta Carbonara / 38 lei"},
        desert3 = {"Nimic", "Panna Cotta / 25 lei ", "Profiterol / 25 lei", "Tiramisu / 25 lei "};

        JPanel panou2 = new JPanel(new GridLayout(aux, 4));
        SchimbareCuloare(panou2);

        for (int i = 0; i < aux; i++)
        {
            JPanel panou = new JPanel();
            SchimbareCuloare(panou);
            JLabel label2 = new JLabel("Persoana nr" + (i + 1) + " a comandat :" );
            label2.setFont(new Font("Cambria", Font.BOLD,15));
            label2.setBorder(BorderFactory.createEmptyBorder(0, 100, 0, 0));
            panou2.add(label2);
            JComboBox<String> box1 = new JComboBox<>(aperitiv1);
            JComboBox<String> box2 = new JComboBox<>(felPrincipal2);
            JComboBox<String> box3 = new JComboBox<>(desert3);
            box1.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
                {
                    String da1 = (String) box1.getSelectedItem();
                    aperitiv[cntApertiv] = da1;
                    cntApertiv++;
                    JOptionPane.showMessageDialog(null, "Optiune selectata " + da1);
                 }
            });
            panou.add(box1);
            box2.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
                {
                    String da2 = (String) box2.getSelectedItem();
                    felPrincipal[cntFelPrincipal] = da2;
                    cntFelPrincipal++;
                    JOptionPane.showMessageDialog(null, "Optiune selectata " + da2);
                 }
            });
            panou.add(box2);
            box3.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
                {
                    String da3 = (String) box3.getSelectedItem();
                    desert[cntDesert] = da3;
                    cntDesert++;
                    JOptionPane.showMessageDialog(null, "Optiune selectata " + da3);
                 }
            });
            panou.add(box3);
            panou2.add(panou);

        }


        
        JPanel panou3 = new JPanel();
        SchimbareCuloare(panou3);
        JButton salvare = new JButton("Salveaza");
        salvare.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e)
                {   
                    if (cntApertiv < aux || cntFelPrincipal < aux || cntDesert < aux)
                    {
                        JOptionPane.showMessageDialog(null, "Nu ati selectat optiuni din meniu");
                    
                    }
                    else{

                        int suma = 0;
                        if (apasat)
                        {
                            suma = Calcul();
                            suma = suma - (suma * 10/100);
                        }
                        else
                        {
                            suma = Calcul();
                        }

                        if (suma > persoana.getPortofel())
                        {
                            frame.dispose();
                            JFrame frame5 = new JFrame("Eroare");
                            SchimbareLogo(frame5);
                            frame5.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                            frame5.setSize(600, 300);
                            frame5.setLocationRelativeTo(null);

                            JPanel panelPrincipal = new JPanel(new GridLayout(2,1));

                            JPanel panel1 = new JPanel();
                            SchimbareCuloare(panel1);
                            JLabel label2 = new JLabel("Nu aveti destui bani in portofel, va rog sa adaugati mai multi bani");
                            label2.setFont(new Font("Cambria", Font.BOLD, 15));
                            panel1.add(label2);

                            JPanel panel2 = new JPanel();
                            SchimbareCuloare(panel2);
                            JButton buton = new JButton("Adauga");
                            setButon(buton);

    
                            buton.addActionListener(new ActionListener() {
                             public void actionPerformed(ActionEvent e){
                                frame5.dispose();
                                JFrame frame6 = new JFrame();
                                frame6.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
                                frame6.setSize(400, 200);
                                frame6.setLocationRelativeTo(null);

                                JPanel panouPrincipal = new JPanel(new GridLayout(2,1));

                                JPanel panou1 = new JPanel();
                                SchimbareCuloare(panou1);
                                JLabel text = new JLabel("Adauga suma : ");
                                JTextField field = new JTextField(4);
                                panou1.add(text);
                                panou1.add(field);

                                JPanel panou2 = new JPanel();
                                SchimbareCuloare(panou2);
                                JButton ok = new JButton("Ok");
                                setButon(ok);
                                ok.addActionListener(new ActionListener() {
                                     public void actionPerformed(ActionEvent e){
                                        String numarPr = field.getText();
                                        try{
                                            int NumarPr = Integer.parseInt(numarPr);
                                            persoana.adugarePortofel(NumarPr);
                                            frame6.dispose();
                                            Resetare();
                                            Restaurant();
                                        }catch(NumberFormatException nu)
                                        {
                                            JOptionPane.showMessageDialog(null, "Nu ai introdus numar");
                                        }
                                     }
                                });
                                panou2.add(ok);



                                panouPrincipal.add(panou1);
                                panouPrincipal.add(panou2);
                                frame6.add(panouPrincipal);
                                frame6.setVisible(true);                            
                             }
                            });
                            panel2.add(buton);

                            panelPrincipal.add(panel1);
                            panelPrincipal.add(panel2);
                            frame5.add(panelPrincipal);
                            frame5.setVisible(true);
                        }
                        else if (list.isEmpty())
                        {
                            for (int i = 0; i < aux; i++)
                            {
                                listR.add(new Restaurant(aperitiv[i], felPrincipal[i], desert[i]));
                                
                            }
                            Restaurant afisare = (Restaurant)listR.get(0);
                            System.out.println(afisare.Afisare());
                            System.out.println(afisare.Afisare(1));
                            ScriereFisier();
                            ScriereBazaDeDate();
                            frame.dispose();
                            FereastraFinal();
                        }
                        else
                        {
                            System.out.println("Caz cazat");
                            for (int i = 0; i < list.size(); i++)
                            {
                                Camere a = list.get(i);
                                for(int j = 0; j < a.getNrPersoane(); j++)
                                {
                                    listR.add(new Restaurant(a, aperitiv[j], felPrincipal[j], desert[j]));
                                }
                            }
                            Restaurant afis = (Restaurant)listR.get(0);
                            System.out.println(afis.Afisare());
                            System.out.println(afis.Afisare(1));
                            ScriereFisier();
                            ScriereBazaDeDate();
                            frame.dispose();
                            FereastraFinal();
                        }  
                    }    
                }
            });

        panou3.add(salvare);

        panouPrincipal.add(panou1);
        panouPrincipal.add(panou2);
        panouPrincipal.add(panou3);
        frame.add(panouPrincipal);
        frame.setVisible(true);
    }

    private int Calcul(){
        int suma = 0;
        for (int i = 0; i < cntApertiv; i++)
        {
            if(aperitiv[i].equals("Nimic"))
            {
                suma += 0;
            }
            else if (aperitiv[i].equals("Bruschete / 15 lei "))
            {
                suma += 15;
            }
            else if (aperitiv[i].equals("Capreze / 20 lei "))
            {
                suma += 20;
            }
            else{
                suma += 25;
            }

            if(felPrincipal[i].equals("Nimic"))
            {
                suma += 0;
            }
            else if (felPrincipal[i].equals("Pizza / 35 lei "))
            {
                suma += 35;
            }
            else if (felPrincipal[i].equals("Lasagna / 40 lei "))
            {
                suma += 40;
            }
            else{
                suma += 38;
            }

            if (desert[i].equals("Nimic"))
            {
                suma += 0;
            }
            else if (desert[i].equals("Panna Cotta / 25 lei "))
            {
                suma += 25;
            }
            else if (desert[i].equals("Profiterol / 25 lei"))
            {
                suma += 25;
            }
            else{
               suma += 25;
            }
        }
        return suma;
    }

    private void Resetare(){
        for (int i = 0; i < aperitiv.length; i++)
        {
            aperitiv[i] = null;
        }
        cntApertiv = 0;

        for (int i = 0; i < felPrincipal.length; i++)
        {
            felPrincipal[i] = null;
        }
        cntFelPrincipal = 0;

        for (int i = 0; i < desert.length; i++)
        {
            desert[i] = null;
        }
        cntDesert = 0;
    }

    public void SchimbareLogo(JFrame frame)
    {
        ImageIcon iconita = new ImageIcon("Desktop - 20.png");
        frame.setIconImage(iconita.getImage());
    }

    public void FereastraFinal() {
        JFrame finalFrame = new JFrame("Hotel Firenze: Final");
        SchimbareLogo(finalFrame);
        finalFrame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        finalFrame.setSize(700, 300);
        finalFrame.setLocationRelativeTo(null);

        JPanel panelPrincipal = new JPanel(new GridLayout(2, 1));

        JPanel panel1 = new JPanel();
        SchimbareCuloare(panel1);
        JLabel label = new JLabel("Va multumim!");
        label.setFont(new Font("Cambria", Font.BOLD, 35));
        panel1.add(label);

        JPanel panel3 = new JPanel();
        SchimbareCuloare(panel3);
        JLabel label3 = new JLabel("Grazzie a tutti");
        label3.setFont(new Font("Cambria", Font.BOLD, 27));
        panel3.add(label3);

    
        panelPrincipal.add(panel1);
        panelPrincipal.add(panel3);
        finalFrame.add(panelPrincipal);
        finalFrame.setVisible(true);
    }

    private void ScriereFisier()
    {
        String numeFisier = "fisier.txt";
        try{
            FileWriter fileWriter = new FileWriter(numeFisier, true);
            BufferedWriter buffer = new BufferedWriter(fileWriter);

            for (int i = 0; i < listR.size(); i++)
            {
                Restaurant res = (Restaurant)listR.get(i);
                buffer.newLine();
                buffer.write(res.toString());
            }

            buffer.close();
            fileWriter.close();
            System.out.println("Datele au fost scrise in fisier cu succes");
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }


    }

    private void ScriereBazaDeDate()
    {
        try{
            BufferedWriter writer = new BufferedWriter(new FileWriter("Proiect.session.sql", true));

            String insertStatement = "INSERT INTO Cont VALUES (id, nume, parola, numarPersoane)" + " " + " 1 " + persoana.getNume() + " " + persoana.getParola()+ " " + persoana.getNrPersoane();
            writer.write(insertStatement);
            writer.newLine();
            writer.close();
        }catch(IOException e){
            e.printStackTrace();
        }
    }
    
}
