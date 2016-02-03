﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Wenn der Code neu generiert wird, gehen alle Änderungen an dieser Datei verloren
// </auto-generated>
//------------------------------------------------------------------------------
namespace RemoteControlServer.ClientService
{
	using Definitions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class ClientService : IClientService
    {
        private IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository_)
        {

        }

		public virtual Client getClientForNewConnection(string ip)
		{
            Client client = clientRepository.getClientWithIp(ip);
            if (client == null)
            {
                client = new Client();
            }
            return client;
		}

	}
}

