namespace DataBaseIndus.Models
{
    public class Error
    {
        public string MessageError { get; set; }
        public Error(string message) { 
        MessageError= message;
        }
    }
}
