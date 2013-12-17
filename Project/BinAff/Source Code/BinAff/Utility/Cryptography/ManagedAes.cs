using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BinAff.Utility.Cryptography
{

    public sealed class ManagedAes : Server
    {

        private const String ENCRYPTION_PASSWORD = "BinAff@1";

        public override String Encrypt(String unencryptedString)
        {
            Byte[] utfdata = UTF8Encoding.UTF8.GetBytes(unencryptedString);
            Byte[] saltBytes = UTF8Encoding.UTF8.GetBytes(this.EncryptionKey);

            // Our symmetric encryption algorithm

            // We're using the PBKDF2 standard for password-based key generation
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(ENCRYPTION_PASSWORD, saltBytes);

            AesManaged aes = new AesManaged();
            // Setting our parameters
            aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
            aes.KeySize = aes.LegalKeySizes[0].MaxSize;

            aes.Key = rfc.GetBytes(aes.KeySize / 8);
            aes.IV = rfc.GetBytes(aes.BlockSize / 8);

            // Encryption
            ICryptoTransform encryptTransf = aes.CreateEncryptor();

            // Output stream, can be also a FileStream
            MemoryStream encryptStream = new MemoryStream();
            CryptoStream encryptor = new CryptoStream(encryptStream, encryptTransf, CryptoStreamMode.Write);

            encryptor.Write(utfdata, 0, utfdata.Length);
            encryptor.Flush();
            encryptor.Close();

            // Showing our encrypted content
            Byte[] encryptBytes = encryptStream.ToArray();
            //string encryptedString = UTF8Encoding.UTF8.GetString(encryptBytes, 0, encryptBytes.Length);
            String encryptedString = Convert.ToBase64String(encryptBytes);

            return encryptedString;
        }

        public override String Decrypt(String encryptedString)
        {
            String decryptedString = null;
            try
            {
                if (encryptedString == null) return null;
                Byte[] encryptBytes = Convert.FromBase64String(encryptedString);
                Byte[] saltBytes = Encoding.UTF8.GetBytes(this.EncryptionKey);

                // Our symmetric encryption algorithm
                AesManaged aes = new AesManaged();

                // We're using the PBKDF2 standard for password-based key generation
                Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(ENCRYPTION_PASSWORD, saltBytes);

                // Setting our parameters
                aes.BlockSize = aes.LegalBlockSizes[0].MaxSize;
                aes.KeySize = aes.LegalKeySizes[0].MaxSize;

                aes.Key = rfc.GetBytes(aes.KeySize / 8);
                aes.IV = rfc.GetBytes(aes.BlockSize / 8);

                // Now, decryption
                ICryptoTransform decryptTrans = aes.CreateDecryptor();

                // Output stream, can be also a FileStream
                MemoryStream decryptStream = new MemoryStream();
                CryptoStream decryptor = new CryptoStream(decryptStream, decryptTrans, CryptoStreamMode.Write);

                decryptor.Write(encryptBytes, 0, encryptBytes.Length);
                decryptor.Flush();
                decryptor.Close();

                // Showing our decrypted content
                Byte[] decryptBytes = decryptStream.ToArray();
                decryptedString = UTF8Encoding.UTF8.GetString(decryptBytes, 0, decryptBytes.Length);
            }
            catch
            {
                decryptedString = null;
            }
            return decryptedString;
        }

    }

}
