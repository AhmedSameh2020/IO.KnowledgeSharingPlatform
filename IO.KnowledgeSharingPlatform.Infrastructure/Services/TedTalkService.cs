using CsvHelper;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Repository;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Core.Model;
using System.Globalization;

namespace IO.KnowledgeSharingPlatform.Infrastructure.Services
{
    public class TedTalkService : ITedTalkService
    {
        public bool AutoSave { get; set; }

        public ITedTalkUnitOfWork UnitOfWork { get; set; }

        public TedTalkService(ITedTalkUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;

            AutoSave = true;
        }

        public virtual ITedTalkRepository Repository
        {
            get { return UnitOfWork.Repository(); }
        }

        public virtual TedTalk Add(TedTalk entity)
        {
            try
            {
                entity = Repository.Add(entity);
                if (AutoSave)
                {
                    SaveChanges();
                }
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SeedTedTalks()
        {
            try
            {
                var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture);

                config.MissingFieldFound = null;
                config.HeaderValidated = null;

                using (var reader = new StreamReader("SeedData\\data.csv"))
                using (var csv = new CsvReader(reader, config))
                {
                    var tedTalks = csv.GetRecords<TedTalk>();
                    Repository.AddRange(tedTalks);
                }

                if (AutoSave)
                {
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Update(TedTalk entity)
        {
            try
            {
                Repository.Update(entity);
                if (AutoSave)
                {
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Delete(Guid id)
        {
            try
            {
                var entity = Repository.Find(e => e.Id == id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Delete(TedTalk entity)
        {
            try
            {
                Repository.Delete(entity);
                if (AutoSave)
                {
                    SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public virtual IQueryable<TedTalk> Where(System.Linq.Expressions.Expression<Func<TedTalk, bool>> predicate, params string[] includes)
        {
            return Repository.Where(predicate, includes);
        }

        public void DeleteRange(IEnumerable<TedTalk> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual int SaveChanges()
        {
            return UnitOfWork.SaveChanges();
        }
    }
}
