// thanks to https://www.youtube.com/watch?v=LJYj17yCckE

using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TibiaReader
{
	class MemoryReader
	{
		private IntPtr handle;

		[DllImport("kernel32.dll")]
		public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

		public MemoryReader(Process process)
		{
			handle = process.Handle;
		}

		public byte[] ReadBytes(Int64 address, uint n)
		{
			IntPtr ptrBytesRead;
			byte[] buf = new byte[n];
			ReadProcessMemory(handle, new IntPtr(address), buf, n, out ptrBytesRead);
			return buf;
		}

		public Int32 ReadInt32(Int64 address)
		{
			return BitConverter.ToInt32(ReadBytes(address, 4), 0);
		}

		public UInt32 ReadUInt32(Int64 address)
		{
			return BitConverter.ToUInt32(ReadBytes(address, 4), 0);
		}

		public string ReadString(Int64 address, uint length = 32)
		{
			return ASCIIEncoding.Default.GetString(ReadBytes(address, length)).Split('\0')[0];
		}
	}
}
