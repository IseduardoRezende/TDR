using TDRDomain.Bases;

namespace TDRDomain.Interfaces
{
    public interface IBaseReadViewModel
    {
        public long? Id { get; set; }

        public BaseError? BaseError { get; set; }
    }
}
