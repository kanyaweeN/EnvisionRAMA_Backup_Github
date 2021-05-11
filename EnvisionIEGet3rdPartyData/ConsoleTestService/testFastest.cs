using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ConsoleTestService
{
	public class testFastest
	{
		public testFastest()
		{
			int LONG_STRING_LENGTH = 100 * 1024;
			int MANY_STRING_COUNT = 1024;
			int MANY_STRING_LENGTH = 100;

			var source = GetRandomBytes(LONG_STRING_LENGTH);

			List<byte[]> manyString = new List<byte[]>(MANY_STRING_COUNT);
			for (int i = 0; i < MANY_STRING_COUNT; ++i)
			{
				manyString.Add(GetRandomBytes(MANY_STRING_LENGTH));
			}

			var algorithms = new Dictionary<string, Func<byte[], string>>();
			algorithms["BitConvertReplace"] = BitConv;
			algorithms["StringBuilder"] = StringBuilderTest;
			algorithms["LinqConcat"] = LinqConcat;
			algorithms["LinqJoin"] = LinqJoin;
			algorithms["LinqAgg"] = LinqAgg;
			algorithms["ToHex"] = ToHex;
			algorithms["ByteArrayToHexString"] = ByteArrayToHexString;

			Console.WriteLine(" === Long string test");
			foreach (var pair in algorithms)
			{
				TimeAction(pair.Key + " calculation", 500, () =>
				{
					pair.Value(source);
				});
			}

			Console.WriteLine(" === Many string test");
			foreach (var pair in algorithms)
			{
				TimeAction(pair.Key + " calculation", 500, () =>
				{
					foreach (var str in manyString)
					{
						pair.Value(str);
					}
				});
			}
		}

		// Define other methods and classes here
		static void TimeAction(string description, int iterations, Action func)
		{
			var watch = new Stopwatch();
			watch.Start();
			for (int i = 0; i < iterations; i++)
			{
				func();
			}
			watch.Stop();
			Console.Write(description);
			Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
		}

		//static byte[] GetRandomBytes(int count) {
		//  var bytes = new byte[count];
		//  (new Random()).NextBytes(bytes);
		//  return bytes;
		//}
		static Random rand = new Random();
		static byte[] GetRandomBytes(int count)
		{
			var bytes = new byte[count];
			rand.NextBytes(bytes);
			return bytes;
		}


		static string BitConv(byte[] data)
		{
			return BitConverter.ToString(data).Replace("-", string.Empty);
		}
		static string StringBuilderTest(byte[] data)
		{
			StringBuilder sb = new StringBuilder(data.Length * 2);
			foreach (byte b in data)
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
		static string LinqConcat(byte[] data)
		{
			return string.Concat(data.Select(b => b.ToString("X2")).ToArray());
		}
		static string LinqJoin(byte[] data)
		{
			return string.Join("",
				data.Select(
					bin => bin.ToString("X2")
					).ToArray());
		}
		static string LinqAgg(byte[] data)
		{
			return data.Aggregate(new StringBuilder(),
									   (sb, v) => sb.Append(v.ToString("X2"))
									  ).ToString();
		}
		static string ToHex(byte[] bytes)
		{
			char[] c = new char[bytes.Length * 2];

			byte b;

			for (int bx = 0, cx = 0; bx < bytes.Length; ++bx, ++cx)
			{
				b = ((byte)(bytes[bx] >> 4));
				c[cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');

				b = ((byte)(bytes[bx] & 0x0F));
				c[++cx] = (char)(b > 9 ? b - 10 + 'A' : b + '0');
			}

			return new string(c);
		}
		public static string ByteArrayToHexString(byte[] Bytes)
		{
			StringBuilder Result = new StringBuilder(Bytes.Length * 2);
			string HexAlphabet = "0123456789ABCDEF";

			foreach (byte B in Bytes)
			{
				Result.Append(HexAlphabet[(int)(B >> 4)]);
				Result.Append(HexAlphabet[(int)(B & 0xF)]);
			}

			return Result.ToString();
		}
	}
}
