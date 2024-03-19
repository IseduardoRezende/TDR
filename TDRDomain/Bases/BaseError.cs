namespace TDRDomain.Bases
{
    public class BaseError 
    {
        public BaseError()
        {
            Errors = new List<Error>();
        }

        public bool HasErrors { get { return Errors.Any() ? true : false; } }

        public List<Error> Errors { get; private set; }
            
        public void AddError(Error error)
        {
            Errors.Add(error);            
        }        
    }
}
