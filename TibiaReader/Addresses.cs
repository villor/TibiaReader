using System;

namespace TibiaReader
{
	class Addresses
	{
		private UInt32 baseAddress;

		public UInt32 XOR
		{
			get
			{
				return baseAddress + 0x534658;
			}
		}

		public UInt32 Health
		{
			get
			{
				return baseAddress + 0x6d2030;
			}
		}

		public UInt32 MaxHealth
		{
			get
			{
				return baseAddress + 0x6D2024;
			}
		}

		public UInt32 Mana
		{
			get
			{
				return baseAddress + 0x534688;
			}
		}

		public UInt32 MaxMana
		{
			get
			{
				return baseAddress + 0x53465C;
			}
		}

		public UInt32 PlayerId
		{
			get
			{
				return baseAddress + 0x6D202C;
			}
		}

		public UInt32 BattleList
		{
			get
			{
				return baseAddress + 0x72DE20;
			}
		}

		public Addresses(UInt32 baseAddress)
		{
			this.baseAddress = baseAddress;
		}
	}
}
