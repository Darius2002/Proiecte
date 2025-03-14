import clase.InterfataMain;
import javax.swing.SwingUtilities;
public class Main {
    public static void main(String args[]){
        SwingUtilities.invokeLater(new Runnable() {
            @Override
            public void run(){
                InterfataMain main = new InterfataMain();
                main.show();
            }
        });
    }
}
