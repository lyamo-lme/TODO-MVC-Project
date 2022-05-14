namespace ToDoList.Models
{
    public class Error
    {
        public string MessageError { get; set; }
        public Error(string message) { 
        MessageError= message;
        }
    }
}
