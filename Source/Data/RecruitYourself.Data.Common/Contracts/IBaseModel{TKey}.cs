namespace RecruitYourself.Data.Common.Contracts
{
    public interface IBaseModel<TKey> : IAuditInfo, IDeletableEntity
    {
        TKey Id { get; set; }
    }
}
