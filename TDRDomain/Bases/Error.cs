namespace TDRDomain.Bases
{
    public class Error
    {
        public Error(string field, string description)
        {
            Field = field;
            Description = description;
        }

        public string Field { get; set; }
        
        public string Description { get; set; }
    }
}
