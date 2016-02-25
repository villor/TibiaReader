using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TibiaReader
{
	public class TibiaClient {
		private const int BL_CREATURE_SIZE = 220;
		private const int BL_Z_OFFSET = 36;
		private const int BL_Y_OFFSET = 40;
		private const int BL_X_OFFSET = 44;

		private Process process;
		private MemoryReader reader;
		private Addresses addr;

		public UInt32 BaseAddress {
			get {
				return (UInt32)process.MainModule.BaseAddress.ToInt32();
			}
		}

		public string WindowTitle {
			get {
				return process.MainWindowTitle;
			}
		}

		public int XOR {
			get {
				return reader.ReadInt32(addr.XOR);
			}
		}

		public int Health {
			get {
				return reader.ReadInt32(addr.Health) ^ XOR;
			}
		}

		public int MaxHealth {
			get {
				return reader.ReadInt32(addr.MaxHealth) ^ XOR;
			}
		}

		public int Mana {
			get {
				return reader.ReadInt32(addr.Mana) ^ XOR;
			}
		}

		public int MaxMana {
			get {
				return reader.ReadInt32(addr.MaxMana) ^ XOR;
			}
		}

		public int PlayerId {
			get {
				return reader.ReadInt32(addr.PlayerId);
			}
		}

		public string PlayerName {
			get {
				return reader.ReadString(findPlayerInBattleList() + 4);
			}
		}

		public int X {
			get {
				return reader.ReadInt32(findPlayerInBattleList() + BL_X_OFFSET);
			}
		}

		public int Y {
			get {
				return reader.ReadInt32(findPlayerInBattleList() + BL_Y_OFFSET);
			}
		}

		public int Z {
			get {
				return reader.ReadInt32(findPlayerInBattleList() + BL_Z_OFFSET);
			}
		}

		public int Experience {
			get {
				return reader.ReadInt32(addr.Experience);
			}
		}

		public int Level {
			get {
				return reader.ReadInt32(addr.Level);
			}
		}

		public int MagicLevel {
			get {
				return reader.ReadInt32(addr.MagicLevel);
			}
		}

		public TibiaClient(Process process) {
			this.process = process;
			reader = new MemoryReader(process);
			addr = new Addresses(BaseAddress);
		}

		private UInt32 findPlayerInBattleList() {
			UInt32 creature = addr.BattleList;
			while (reader.ReadInt32(creature) != PlayerId) {
				creature += BL_CREATURE_SIZE;
			}
			return creature;
		}

		public static List<TibiaClient> GetClients() {
			var processes = Process.GetProcessesByName("Tibia");
			var clients = new List<TibiaClient>();
			foreach (var p in processes) {
				clients.Add(new TibiaClient(p));
			}
			return clients;
		}
	}
}
