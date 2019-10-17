using System.Collections.Generic;

namespace BrokenDigSky.AmdOnlyRts.Networking
{
	public class NetAddressBook
	{

		public Dictionary<string, string> LANAddressBook;

		public NetAddressBook()
		{
			LANAddressBook = new Dictionary<string, string>();
		}

		public void AddAddress(string IP, string name)
		{
			LANAddressBook.Add(IP, name);
		}

		public string GetName(string IP)
		{
			return LANAddressBook[IP];
		}
	}
}
