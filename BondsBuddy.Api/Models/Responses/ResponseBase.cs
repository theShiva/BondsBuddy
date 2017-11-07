namespace BondsBuddy.Api.Models.Responses
{
    public abstract class ResponseBase
    {
        public ResponseMeta Meta { get; set; }

        protected ResponseBase()
        {
            Meta = new ResponseMeta();
        } 
    }
}