namespace Org.BouncyCastle.Crypto.Utilities
{
	internal sealed class Pack
	{
		private Pack()
		{
		}

		internal static void UInt32_To_BE(uint n, byte[] bs, int off)
		{
			bs[off] = (byte)(n >> 24);
			bs[off + 1] = (byte)(n >> 16);
			bs[off + 2] = (byte)(n >> 8);
			bs[off + 3] = (byte)n;
		}

		internal static void UInt32_To_BE(uint[] ns, byte[] bs, int off)
		{
			for (int i = 0; i < ns.Length; i++)
			{
				UInt32_To_BE(ns[i], bs, off);
				off += 4;
			}
		}

		internal static uint BE_To_UInt32(byte[] bs, int off)
		{
			return (uint)((bs[off] << 24) | (bs[off + 1] << 16) | (bs[off + 2] << 8) | bs[off + 3]);
		}

		internal static void BE_To_UInt32(byte[] bs, int off, uint[] ns)
		{
			for (int i = 0; i < ns.Length; i++)
			{
				ns[i] = BE_To_UInt32(bs, off);
				off += 4;
			}
		}

		internal static void UInt64_To_BE(ulong n, byte[] bs, int off)
		{
			UInt32_To_BE((uint)(n >> 32), bs, off);
			UInt32_To_BE((uint)n, bs, off + 4);
		}

		internal static void UInt32_To_LE(uint n, byte[] bs)
		{
			bs[0] = (byte)n;
			bs[1] = (byte)(n >> 8);
			bs[2] = (byte)(n >> 16);
			bs[3] = (byte)(n >> 24);
		}

		internal static void UInt32_To_LE(uint n, byte[] bs, int off)
		{
			bs[off] = (byte)n;
			bs[off + 1] = (byte)(n >> 8);
			bs[off + 2] = (byte)(n >> 16);
			bs[off + 3] = (byte)(n >> 24);
		}

		internal static uint LE_To_UInt32(byte[] bs, int off)
		{
			return (uint)(bs[off] | (bs[off + 1] << 8) | (bs[off + 2] << 16) | (bs[off + 3] << 24));
		}

		internal static void UInt64_To_LE(ulong n, byte[] bs)
		{
			UInt32_To_LE((uint)n, bs);
			UInt32_To_LE((uint)(n >> 32), bs, 4);
		}
	}
}
