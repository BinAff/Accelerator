using System;

namespace BinAff.Utility.Cryptography
{

    public abstract class Server
    {

        public String EncryptionKey { get; set; }

        public Server()
        {
            this.EncryptionKey = "B1n@ry@ff@1r5";
        }

        public abstract String Encrypt(String unencryptedString);
        public abstract String Decrypt(String encryptedString);

    }

}
