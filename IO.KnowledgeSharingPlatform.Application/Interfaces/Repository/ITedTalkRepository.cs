using IO.KnowledgeSharingPlatform.Core.Model;
using System.Linq.Expressions;

namespace IO.KnowledgeSharingPlatform.Application.Interfaces.Repository
{
    public interface ITedTalkRepository
    {
        TedTalk Add(TedTalk entity);

        TedTalk Update(TedTalk entity);

        void Delete(TedTalk entity);

        TedTalk Find(Expression<Func<TedTalk, bool>> predicate);

        IQueryable<TedTalk> Where(Expression<Func<TedTalk, bool>> predicate, params string[] includes);
    }
}
