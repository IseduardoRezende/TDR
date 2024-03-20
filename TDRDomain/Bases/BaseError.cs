namespace TDRDomain.Bases
{
    public class BaseError 
    {
        public BaseError()
        {
            Errors = new List<Error>();
        }

        public bool HasErrors { get { return Errors.Any(); } }

        public List<Error> Errors { get; private set; }
            
        public void AddError(Error error)
        {
            if (error == null)
                return;

            Errors.Add(error);            
        }

        public void AddError(string field, string description)
        {
            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(description))
                return;

            Errors.Add(new Error(field, description));
        }       
    }
}
