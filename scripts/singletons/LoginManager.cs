using Godot;
using System;

public partial class LoginManager : Node
{
	private static LoginManager Instance;
	
	private User _user = null;

	public override void _Ready()
	{
		Instance = this;
	}

	public static void SetUser(User user)
	{
		Instance._user = user;
	}

	public static User GetUser() 
	{
		return Instance._user;
	}

	public static Boolean IsLoggedIn()
	{
		return Instance._user != null;
	}
}
