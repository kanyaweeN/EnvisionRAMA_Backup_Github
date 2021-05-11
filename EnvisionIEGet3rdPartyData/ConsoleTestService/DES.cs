using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace ConsoleTestService
{
	public class DES
	{
		public static string GetMd5Hash(string input)
		{
			// Convert the input string to a byte array and compute the hash.
			byte[] data = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(input));

			// Create a new Stringbuilder to collect the bytes
			// and create a string.
			StringBuilder sBuilder = new StringBuilder();

			// Loop through each byte of the hashed data 
			// and format each one as a hexadecimal string.
			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			// Return the hexadecimal string.
			return sBuilder.ToString();
		}
		public DES()
		{

			string param = @"path=/Session/Working%20Studies/AccessionNumber=20120821MR0002&username=pacs_adm&password=pacsMSMC@1";
			try
			{
				TripleDES threedes = new TripleDESCryptoServiceProvider();

				threedes.Key = StringToByte("test", 24); // convert to 24 characters - 192 bits
				threedes.IV =StringToByte("12345678");
				byte[] key = threedes.Key;
				byte[] IV = threedes.IV;

				ICryptoTransform encryptor = threedes.CreateEncryptor(key, IV);

				MemoryStream msEncrypt = new MemoryStream();
				CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

				// Write all data to the crypto stream and flush it.
				csEncrypt.Write(StringToByte(param), 0, StringToByte(param).Length);
				csEncrypt.FlushFinalBlock();

				// Get the encrypted array of bytes.
				byte[] encrypted = msEncrypt.ToArray();

				string encrypt = ByteToString(encrypted);

				ICryptoTransform decryptor = threedes.CreateDecryptor(key, IV);

				// Now decrypt the previously encrypted message using the decryptor
				MemoryStream msDecrypt = new MemoryStream(encrypted);
				CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);

				string decrypt = ByteToString(csDecrypt);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public static byte[] StringToByte(string StringToConvert)
		{

			char[] CharArray = StringToConvert.ToCharArray();
			byte[] ByteArray = new byte[CharArray.Length];
			for (int i = 0; i < CharArray.Length; i++)
			{
				ByteArray[i] = Convert.ToByte(CharArray[i]);
			}
			return ByteArray;
		}
		public static byte[] StringToByte(string StringToConvert, int length)
		{

			char[] CharArray = StringToConvert.ToCharArray();
			byte[] ByteArray = new byte[length];
			for (int i = 0; i < CharArray.Length; i++)
			{
				ByteArray[i] = Convert.ToByte(CharArray[i]);
			}
			return ByteArray;
		}
		public static string ByteToString(CryptoStream buff)
		{
			string sbinary = "";
			int b = 0;
			do
			{
				b = buff.ReadByte();
				if (b != -1) sbinary += ((char)b);

			} while (b != -1);
			return (sbinary);
		}
		public static string ByteToString(byte[] buff)
		{
			string sbinary = "";
			for (int i = 0; i < buff.Length; i++)
			{
				sbinary += buff[i].ToString("X2"); // hex format
			}
			return (sbinary);
		}
	}
}
