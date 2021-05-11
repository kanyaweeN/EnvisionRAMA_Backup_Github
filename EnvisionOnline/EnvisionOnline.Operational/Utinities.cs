using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;

namespace EnvisionOnline.Operational
{
    public static class Utilities
    {
        public static bool IsHaveData(DataSet data)
        {
            if (data != null)
            {
                foreach (DataTable item in data.Tables)
                {
                    if (IsHaveData(item))
                        return true;
                }
            }

            return false;
        }
        public static bool IsHaveData(DataTable data) { return (data != null && data.Rows.Count > 0); }
        public static bool IsHaveData(DataView data) { return (data != null && data.Count > 0); }
        public static bool IsHaveData(DataRow[] data) { return (data != null && data.Length > 0); }
        public static bool IsHaveData(object[] data) { return (data != null && data.Length > 0); }
        public static bool IsHaveData(string[] data)
        {
            if (data != null)
            {
                foreach (string item in data)
                {
                    if (!string.IsNullOrEmpty(item))
                        return true;
                }
            }

            return false;
        }

        public static DataTable arrayRowsToDataTable(DataTable dataTableClone, DataRow[] rows)
        {
            foreach (DataRow row in rows)
                dataTableClone.ImportRow(row);
            return dataTableClone;
        }
        public static string Encrypt(string txt)
        {
            string plainText = txt;
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                  // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128


            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }
        public static string Decrypt(string txt)
        {
            string cipherText = txt;
            string passPhrase = "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                  // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128
            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our ciphertext into a byte array.
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                       0,
                                                       plainTextBytes.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert decrypted data into a string. 
            // Let us assume that the original plaintext string was UTF8-encoded.
            string plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                       0,
                                                       decryptedByteCount);

            // Return decrypted string.   
            return plainText;
        }
        public static DateTime ToDateTime(object value)
        {
            string temp = value.ToString();

            DateTime result;

            if (!DateTime.TryParse(temp, out result))
                result = DateTime.MinValue;
            else if (result.Year > 2400)
                result = result.AddYears(-543);

            return result;
        }
        public static DateTime ToDateTime(string value, string format)
        {
            DateTime result;

            if (!DateTime.TryParseExact(value, format, null, DateTimeStyles.None, out result))
                result = DateTime.MinValue;
            else if (result.Year > 2400)
                result = result.AddYears(-543);

            return result;
        }
        public static string ToStringDatetimeTH(string format,DateTime date)
        {
            CultureInfo InvC = new CultureInfo("th-TH");
            String TH_datetimeFormat = date.ToString(format, InvC);

            return TH_datetimeFormat;
        }
        public static DataTable filterModalityByClinic(DataTable dtModality, string enc_type)
        {
            DataTable dtt = new DataTable();
            if (enc_type == "VIP" || enc_type == "PM")
            {
                DataRow[] rows = dtModality.Select("DEFAULT_SESSION='P'");
                dtt = arrayRowsToDataTable(dtModality.Clone(), rows);
                if (dtt.Rows.Count == 0)
                    dtt = dtModality.Copy();
            }
            else if (enc_type == "RGL")
            {
                DataRow[] rows = dtModality.Select("DEFAULT_SESSION = 'R'");
                dtt = arrayRowsToDataTable(dtModality.Clone(), rows);
                if (dtt.Rows.Count == 0)
                    dtt = dtModality.Copy();
            }
            else
            {
                DataRow[] rows = dtModality.Select("DEFAULT_SESSION <> 'P'");
                dtt = arrayRowsToDataTable(dtModality.Clone(), rows);
                if (dtt.Rows.Count == 0)
                    dtt = dtModality.Copy();
            }

            return dtt;
        }

        public static int setSizePopup(PopupModule module, setSize value)
        {
            switch (module)
            {
                case PopupModule.checkFirstLogin:
                    switch (value)
                    {
                        case setSize.Width: return 515; break;
                        case setSize.Height: return 450; break;
                    }
                    break;
                case PopupModule.Alert:
                    switch (value)
                    {
                        case setSize.Width: return 400; break;
                        case setSize.Height: return 200; break;
                    }
                    break;
                case PopupModule.ClinicalIndication:
                    switch (value)
                    {
                        case setSize.Width: return 750; break;
                        case setSize.Height: return 500; break;
                    }
                    break;
            }
            return 0;
        }
        public enum PopupModule
        {
            checkFirstLogin,
            Alert,
            ClinicalIndication,
            ClinicalText
        }
        public enum setSize
        {
            Width,
            Height
        }
    }
}
