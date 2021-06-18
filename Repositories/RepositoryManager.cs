using Contracts;
using Contracts.IShopRepository;
using Entities;
using Repositories.ShopRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IShopModelRepository _shopModelRepository;
     
        private IUsersRepository _usersRepository;
        

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }


        public IShopModelRepository ShopModel
        {
            get
            {
                if (_shopModelRepository == null)
                {
                    _shopModelRepository = new ShopModelRepository(_repositoryContext);
                }

                return _shopModelRepository;
            }
        }

        public IUsersRepository User
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UsersRepository(_repositoryContext);
                }

                return _usersRepository;
            }
        }

        

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
