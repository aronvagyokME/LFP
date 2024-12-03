using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Godot;
using MongoDB.Bson;
using MongoDB.Driver;
public partial class Database : Node
{

	private static Database Instance;

	const string connectionURI = "mongodb+srv://vorosvencel0309:V0YLSAl7x9y4fQCL@tfp.geo9e.mongodb.net/?retryWrites=true&w=majority&appName=TFP";

	private IMongoCollection<User> _users;
	private IMongoCollection<Product> _products;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		var client = new MongoClient(connectionURI);
		var database = client.GetDatabase("TFP");

		_users = database.GetCollection<User>("users");
		_products = database.GetCollection<Product>("products");
	}

	/// <summary>
	/// Email cím ellenőrzés
	/// </summary>
	/// <param name="email">Megadott emailcím</param>
	/// <returns>Igaz, ha foglalt</returns>
	public static Boolean checkEmail(string email) {
		return Instance._users.CountDocuments<User>(u => u.Email == email) > 0;
	}

	/// <summary>
	/// Felhasználónév ellenőrzés
	/// </summary>
	/// <param name="username">Megadott felhasználónév</param>
	/// <returns>Igaz, ha foglalt</returns>
	public static Boolean checkUsername(string username)
	{
		return Instance._users.CountDocuments<User>(u => u.Username == username) > 0;
	}

	/// <summary>
	/// Ellenőrzi hogy az email és a jelszó egy felhasználóhoz tartozik-e
	/// </summary>
	/// <param name="email">a felhasználó által megadott emailcím</param>
	/// <param name="password">a felhasználó által megadott jelszó</param>
	/// <returns>Igaz, ha az email és a jelszó egy felhasználóhoz tartozik</returns>
	public static Boolean checkPassword(string email,string password)
	{
		var encoded = ASCIIEncoding.ASCII.GetBytes(password);

		var filter = Builders<User>.Filter.And(
			Builders<User>.Filter.Eq(u => u.Email, email),
			Builders<User>.Filter.Eq(u => u.Password, encoded)
		);
		return Instance._users.CountDocuments(filter) == 1;
	}

	/// <summary>
	/// Felhasználó regisztrálása az adatbázisba
	/// </summary>
	/// <param name="user">Felhasználó</param>
	public static void instertUser(User user) {
		Instance._users.InsertOneAsync(user);
	}

	/// <summary>
	/// Felhasználó keresése email alapján
	/// </summary>
	/// <param name="email">Megadott email</param>
	/// <returns></returns>
	public static User getUser(string email)
	{
		return Instance._users.Find<User>(u => u.Email == email).First();
	}

	/// <summary>
	/// Felhasználó adatainak frissítése
	/// </summary>
	public static void UpdateUser()
	{
		User user = LoginManager.GetUser();
		var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);

		Instance._users.ReplaceOne(filter,user);
	}

	public static List<Product> GetProducts()
	{
		return Instance._products.Find<Product>(_ => true).ToList();
	}

	public static void InsertProduct(Product product)
	{
		Instance._products.InsertOne(product);
	}
}
