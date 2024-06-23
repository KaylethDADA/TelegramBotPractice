namespace TelegramBotPractice.Application.Interfaces.RepositoryInterfaces
{
    public interface IRepository<TType>
    {
        public Task<TType> Create(TType x);
        public TType Update(TType x);
        public TType GetById(Guid id);
        public bool Delete(Guid id);
    }
}
