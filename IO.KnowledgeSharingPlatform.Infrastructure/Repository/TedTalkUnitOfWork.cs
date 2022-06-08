
using IO.KnowledgeSharingPlatform.Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IO.KnowledgeSharingPlatform.Infrastructure.Repository
{
    public class TedTalkUnitOfWork : ITedTalkUnitOfWork
    {
        protected KnowledgeSharingPlatformContext Context;
        public ITedTalkRepository _repository;

        public TedTalkUnitOfWork(KnowledgeSharingPlatformContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _repository = new TedTalkRepository(context);
        }

        public virtual int SaveChanges()
        {
            var entities = from entry in Context.ChangeTracker.Entries()
                           where entry.State == EntityState.Modified || entry.State == EntityState.Added
                           select entry.Entity;

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    throw new Exception("Data validation error occured during data saving");
                }
            }

            return Context.SaveChanges();
        }
        public ITedTalkRepository Repository()
        {
            return _repository;
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
