using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeLive.Identity.Api.Infrastructure
{
    public class ClientStoreRepository : IClientStore
    {
        protected IRepository _repository;

        public ClientStoreRepository(IRepository repository)
            => _repository = repository;

        public Task<Client> FindClientByIdAsync(string clientId)
            => Task.FromResult(_repository.Single<Client>(c => c.ClientId == clientId));
    }
}
