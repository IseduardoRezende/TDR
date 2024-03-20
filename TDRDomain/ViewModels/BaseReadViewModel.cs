using TDRDomain.Bases;
using TDRDomain.Interfaces;

namespace TDR.ViewModels
{
    public class BaseReadViewModel : IBaseReadViewModel
    {
        public long? Id { get; set; }

        public BaseError? BaseError { get; set; }
    }
}
