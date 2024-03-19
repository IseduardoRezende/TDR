namespace TDRData.Interface
{
    public interface IBaseModel
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
