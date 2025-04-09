using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{
    private string encryptedHealt;
    public Text text;
    public GameObject end;

    private void Start()
    {
        encryptedHealt = AESHelper.Encrypt("100");    
    }

    private void Update()
    {
        int healt = int.Parse(AESHelper.Decrypt(encryptedHealt));
        text.text = "Viata Curenta: " + healt;

        if(healt <= 0)
        {
            Time.timeScale = 0;
            end.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mob"))
        {
            int healt = int.Parse(AESHelper.Decrypt(encryptedHealt));
            healt -= 10;
            encryptedHealt = AESHelper.Encrypt(healt.ToString());
        }
    }

    public void BtnEnd()
    {
        Application.Quit();
    }

   public void SetHealt(int nr)
    {
        encryptedHealt = AESHelper.Encrypt(nr.ToString());
    }

    public int GetHealt()
    {
        return int.Parse(AESHelper.Decrypt(encryptedHealt));
    }

}
