using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeLive.Identity.Api.Infrastructure
{
    public class PersistedGrantRepository : IPersistedGrantStore
    {
        protected IRepository _repository;

        public PersistedGrantRepository(IRepository repository)
            => _repository = repository;
    
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
            => Task.FromResult(_repository.Where<PersistedGrant>(i => i.SubjectId == filter.SubjectId).AsEnumerable());
      

        public Task<PersistedGrant> GetAsync(string key)
            => Task.FromResult(_repository.Single<PersistedGrant>(i => i.Key == key));

        public Task RemoveAllAsync(string subjectId, string clientId)
        {
            _repository.Delete<PersistedGrant>(i => i.SubjectId == subjectId && i.ClientId == clientId);
            return Task.CompletedTask;
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            _repository.Delete<PersistedGrant>(i => i.SubjectId == filter.SubjectId && i.ClientId == filter.ClientId && i.Type == filter.Type);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key)
        {
            _repository.Delete<PersistedGrant>(i => i.Key == key);
            return Task.CompletedTask;
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            _repository.Add<PersistedGrant>(grant);
            return Task.CompletedTask;
        }
    }
}
