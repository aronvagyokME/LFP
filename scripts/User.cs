using System.Text;
using MongoDB.Bson;

public class User
{
    public ObjectId Id;
    public string Email;
    public string Username;
    public string Phone;
    public string[] Address = {"","",""};
    public byte[] Password;

    public User(ObjectId id, string email, string username, byte[] password)
    {
        Id = id;
        Email = email;
        Username = username;
        Password = password;
    }

    public User(string email, string username, string password)
    {
        Id = ObjectId.GenerateNewId();
        Email = email;
        Username = username;
        Password = ASCIIEncoding.ASCII.GetBytes(password);
    }
}