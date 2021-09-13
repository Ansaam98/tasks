namespace tasks.Models
{
    public class ServiceResponse <T>
    {
        //The actual data we want to return 
        public T Data {get;set;}

        //if the call successsful
        public bool Success {get;set;} = true;

        //display message e.g(Alert)
        public string Message {get;set;} = null;
    }
}