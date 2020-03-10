namespace Cook_Book_Client_Desktop_Library.Models
{
   public interface ILoggedUser
    {
        string Email { get; set; }
        string Id { get; set; }
        string Token { get; set; }
        string UserName { get; set; }
    }
}