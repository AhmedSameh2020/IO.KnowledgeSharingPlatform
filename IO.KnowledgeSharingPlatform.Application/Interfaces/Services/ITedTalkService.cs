using IO.KnowledgeSharingPlatform.Core.Model;

namespace IO.KnowledgeSharingPlatform.Application.Interfaces.Services
{
    public interface ITedTalkService
    {
        bool AutoSave { get; set; }
        TedTalk Add(TedTalk entity);
        void SeedTedTalks();
        void Update(TedTalk entity);
        void Delete(Guid id);
        IQueryable<TedTalk> Where(System.Linq.Expressions.Expression<Func<TedTalk, bool>> predicate, params string[] includes);
        int SaveChanges();
    }
}
