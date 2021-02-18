using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeLive.Identity.Api.Infrastructure
{
    public class ResourceRepository : IResourceStore
    {
        protected IRepository _repository;

        public ResourceRepository(IRepository repository)
            => _repository = repository;

        private IEnumerable<ApiResource> GetAllApiResources()
            => _repository.All<ApiResource>();

        private IEnumerable<IdentityResource> GetAllIdentityResources()
            => _repository.All<IdentityResource>();

        public Task<ApiResource> FindApiResourceAsync(string name)
            => Task.FromResult(_repository.Single<ApiResource>(a => a.Name == name));
    
        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
            => Task.FromResult(_repository.Where<IdentityResource>(e => scopeNames.Contains(e.Name)).AsEnumerable());

        public Task<Resources> GetAllResourcesAsync()
            => Task.FromResult(new Resources(GetAllIdentityResources(), GetAllApiResources(), ));

        private Func<IdentityResource, bool> BuildPredicate(Func<IdentityResource, bool> predicate)
            => predicate;

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)        
            => Task.FromResult(_repository.Where<IdentityResource>(a => a.Name.Any(s => scopeNames.Contains(a.Name))).AsEnumerable());
       
        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
         => Task.FromResult(_repository.Where<ApiScope>(a => a.Name.Any(s => scopeNames.Contains(a.Name))).AsEnumerable());

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        { 
            var apis = _repository.All<ApiResource>().ToList();
            var list = apis.Where(a => a.Scopes.Any(s => scopeNames.Contains(a.Name))).AsEnumerable();
            return Task.FromResult(list);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
          => Task.FromResult(_repository.Where<ApiResource>(a => a.Name.Any(s => apiResourceNames.Contains(a.Name))).AsEnumerable());

    }
}
