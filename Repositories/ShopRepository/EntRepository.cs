using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.EntDto;
using Entities.DataTransferObjects.QueryModelDto;
using Entities.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class EntRepository : RepositoryBase<Ent>, IEntRepository
    {
        public EntRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEnt(Ent ent)
        {
            Create(ent);
        }

        public void CreateEntRange(IEnumerable<Ent> ents)
        {
            CreateRange(ents);
        }

        public IQueryable<Ent> GetEntsByType(EntType entType)
        {
            return FindByCondition(e => e.Type == entType, trackChanges: false);
        }

        public async Task<Ent> GetEntById(Guid entId)
        {
            return await FindByCondition(e => e.Id == entId, trackChanges: false).SingleOrDefaultAsync();
        }

        public void DeleteEnt(Ent ent)
        {
            Delete(ent);
        }

        public void Check(QueryModelForCreating entCreateDto)
        {
            Guid[] ents = FindByCondition(e => entCreateDto.EntsString.Contains(e.Value),trackChanges: false)
                .Select(e => e.Id)
                .ToArray();
                
        }

        public async Task<Guid[]> GetGuidsForCreatingQueryParams(QueryModelForCreating model)
        {
            List<Expression<Func<Ent, bool>>> expressions = new();
            IQueryable<Ent> finalQuery = FindAll(false).AsQueryable();
            for (int i = 0; i < model.Ents.Length; i++)
            {
                EntCreateDto entCreateDto = new EntCreateDto
                {
                    Type = model.Ents[i].Type,
                    Value = model.Ents[i].Value
                };

                expressions.Add(e => entCreateDto.Type == e.Type && entCreateDto.Value == e.Value);
            }

            if (expressions.Count > 0)
            {
                // dissect first expression
                ParameterExpression parameterExpression = expressions[0].Parameters[0];
                Expression bodyExpression = expressions[0].Body;
                // append rest bodies with replaced parameter
                for (int i = 1; i < expressions.Count; i++)
                    bodyExpression = Expression.OrElse(bodyExpression, ReplacingExpressionVisitor.Replace(expressions[i].Parameters[0], parameterExpression, expressions[i].Body));
                // create final predicate
                Expression<Func<Ent, bool>> composedPredicate = Expression.Lambda<Func<Ent, bool>>(bodyExpression, parameterExpression);
                finalQuery = finalQuery.Where(composedPredicate);
            }

            Guid[] entsGuids = finalQuery.Select(e => e.Id).ToArray();
            return entsGuids;
        }
    }
}
