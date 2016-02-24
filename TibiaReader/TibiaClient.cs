using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TibiaReader
{
    public class TibiaClient
    {
		private Process process;
		private MemoryReader reader;
		private Addresses addr;

		public string WindowTitle
		{
			get
			{
				return process.MainWindowTitle;
			}
		}

		public int XOR
		{
			get
			{
				return reader.ReadInt32(addr.XOR);
			}
		}

		public int Health
		{
			get
			{
				return reader.ReadInt32(addr.Health) ^ XOR;
			}
		}

		public int MaxHealth
		{
			get
			{
				return reader.ReadInt32(addr.MaxHealth) ^ XOR;
			}
		}

		public int Mana
		{
			get
			{
				return reader.ReadInt32(addr.Mana) ^ XOR;
			}
		}

		public int MaxMana
		{
			get
			{
				return reader.ReadInt32(addr.MaxMana) ^ XOR;
			}
		}

		public TibiaClient(Process process)
		{
			this.process = process;
			reader = new MemoryReader(process);
			addr = new Addresses((UInt32)process.MainModule.BaseAddress.ToInt32());
		}
		
		public static List<TibiaClient> GetClients()
		{
			var processes = Process.GetProcessesByName("Tibia");
			var clients = new List<TibiaClient>();
			foreach (var p in processes)
			{
				clients.Add(new TibiaClient(p));
			}
			return clients;
		}
	}
}
