using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace WhatsIn.EntityFramework.Repositories
{
    public abstract class WhatsInRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<WhatsInDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected WhatsInRepositoryBase(IDbContextProvider<WhatsInDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class WhatsInRepositoryBase<TEntity> : WhatsInRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected WhatsInRepositoryBase(IDbContextProvider<WhatsInDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
