namespace IO.KnowledgeSharingPlatform.Application.Interfaces.Repository
{
    public interface ITedTalkUnitOfWork : IDisposable
    {
        ITedTalkRepository Repository();
        int SaveChanges();
    }
}
