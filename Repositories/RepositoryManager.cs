﻿using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private IShopCarcaseTypeRepository _shopCarcaseTypeRepository;
        private IShopDriveTypeRepository _shopDriveTypeRepository;
        private IShopEngineTypeRepository _shopEngineTypeRepository;
        private IShopMarkRepository _shopMarkRepository;
        private IShopModelRepository _shopModelRepository;
        private IShopTransmissionTypeRepository _shopTransmissionTypeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IShopCarcaseTypeRepository ShopCarcaseType
        {
            get
            {
                if(_shopCarcaseTypeRepository == null)
                {
                    _shopCarcaseTypeRepository = new ShopCarcaseTypeRepository(_repositoryContext);
                }

                return _shopCarcaseTypeRepository;
            }
        }

        public IShopDriveTypeRepository ShopDriveType
        {
            get
            {
                if (_shopDriveTypeRepository == null)
                {
                    _shopDriveTypeRepository = new ShopDriveTypeRepository(_repositoryContext);
                }

                return _shopDriveTypeRepository;
            }
        }

        public IShopEngineTypeRepository ShopEngineType
        {
            get
            {
                if (_shopEngineTypeRepository == null)
                {
                    _shopEngineTypeRepository = new ShopEngineTypeRepository(_repositoryContext);
                }

                return _shopEngineTypeRepository;
            }
        }

        public IShopMarkRepository ShopMark
        {
            get
            {
                if (_shopMarkRepository == null)
                {
                    _shopMarkRepository = new ShopMarkRepository(_repositoryContext);
                }

                return _shopMarkRepository;
            }
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

        public IShopTransmissionTypeRepository ShopTransmissionType
        {
            get
            {
                if (_shopTransmissionTypeRepository == null)
                {
                    _shopTransmissionTypeRepository = new ShopTransmissionTypeRepository(_repositoryContext);
                }

                return _shopTransmissionTypeRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}