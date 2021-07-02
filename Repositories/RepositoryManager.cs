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
        private IMeshRepository _meshRepository;
        private IUsersRepository _usersRepository;
        private IEntRepository _entRepository;
        private IOrderRepository _orderRepository;
        private IStorageRepository _storageRepository;

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
        public IMeshRepository Mesh
        {
            get
            {
                if (_meshRepository == null)
                {
                    _meshRepository = new MeshRepository(_repositoryContext);
                }

                return _meshRepository;
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

        public IEntRepository Ent
        {
            get
            {
                if (_entRepository == null)
                {
                    _entRepository = new EntRepository(_repositoryContext);
                }

                return _entRepository;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_repositoryContext);
                }

                return _orderRepository;
            }
        }

        public IStorageRepository Storage
        {
            get
            {
                if (_storageRepository == null)
                {
                    _storageRepository = new StorageRepository(_repositoryContext);
                }

                return _storageRepository;
            }
        }


        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
