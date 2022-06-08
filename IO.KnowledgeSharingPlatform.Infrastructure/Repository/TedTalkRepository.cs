using IO.KnowledgeSharingPlatform.Application.Interfaces.Repository;
using IO.KnowledgeSharingPlatform.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IO.KnowledgeSharingPlatform.Infrastructure.Repository
{
    public class TedTalkRepository : ITedTalkRepository
    {
        private DbSet<TedTalk> _dbSet;
        protected KnowledgeSharingPlatformContext Context;

        public TedTalkRepository(KnowledgeSharingPlatformContext context)
        {
            Context = context;
        }

        protected DbSet<TedTalk> Table
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = Context.Set<TedTalk>();
                }

                return _dbSet;
            }
        }

        public bool IgnoreConcurrencyErrors { get; set; }

        public virtual TedTalk Add(TedTalk entity)
        {
            entity = Table.Add(entity).Entity;
            Context.Entry(entity).State = EntityState.Added;

            return entity;
        }

        public virtual TedTalk Update(TedTalk entity)
        {
            entity = Table.Attach(entity).Entity;
            var entry = Context.Entry(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        public virtual void Delete(TedTalk entity)
        {
            var entry = Context.Entry(entity);
            if (entry == null || entry.State != EntityState.Added)
            {
                Table.Attach(entity);
                Table.Remove(entity);
            }
        }

        public virtual IQueryable<TedTalk> Where(System.Linq.Expressions.Expression<Func<TedTalk, bool>> predicate, params string[] includes)
        {
            var table = Table.Where(predicate);

            foreach (var i in includes)
            {
                table = table.Include(i);
            }

            return table;
        }

        public virtual TedTalk Find(Expression<Func<TedTalk, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }
    }
}
