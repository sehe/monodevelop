namespace Sharpen
{
	using System;
	using System.IO;

	internal class ByteArrayOutputStream : OutputStream
	{
		public ByteArrayOutputStream ()
		{
			base.Wrapped = new MemoryStream ();
		}

		public ByteArrayOutputStream (int bufferSize)
		{
			base.Wrapped = new MemoryStream (bufferSize);
		}

		public long Size ()
		{
			return ((MemoryStream)base.Wrapped).Length;
		}

		public byte[] ToByteArray ()
		{
			return ((MemoryStream)base.Wrapped).ToArray ();
		}
	}
}
