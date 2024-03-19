using TDRDomain.Interfaces;

namespace TDR.ViewModels
{
    public class BaseReadViewModel : IBaseReadViewModel
    {
        public long? Id { get; set; }
    }
}
