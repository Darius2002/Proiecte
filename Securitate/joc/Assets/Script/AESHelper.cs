using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class AESHelper : MonoBehaviour
{
    private static string key;
    private static string iv;

    private void Start()
    {
        GenerateKeyAndIv();
    }

    public static void GenerateKeyAndIv()
    {
        using (Aes aes = Aes.Create())
        {
            aes.KeySize = 256; 
            aes.BlockSize = 128;

            aes.GenerateKey();  
            aes.GenerateIV();   

            key = Convert.ToBase64String(aes.Key); 
            iv = Convert.ToBase64String(aes.IV);   
        }
    }

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key); 
            aes.IV = Convert.FromBase64String(iv);    

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            return Convert.ToBase64String(encryptedBytes);  
        }
    }

    
    public static string Decrypt(string encryptedText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);  
            aes.IV = Convert.FromBase64String(iv);   

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes); 
        }
    }
}
