using Godot;
using System;
using System.Text.RegularExpressions;

public partial class Login : Window
{
	[Export]
	private NodePath _email,_password;


	private PackedScene packed;

	public override void _Ready()
	{
		packed = ResourceLoader.Load<PackedScene>("res://scenes/register.tscn");
	}

	/// <summary>
	/// Felhasználó bejelentkeztetése
	/// </summary>
	public void OnLoginPressed()
	{
		var email = GetNode<LineEdit>(_email).Text;
		var password = GetNode<LineEdit>(_password).Text;

		if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
		{
			GD.Print("Valami üres");
			return;
		}

		if (!Regex.Match(email, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success)
		{
			GD.Print("Hibás email");
			return;
		}

		if (!Database.checkEmail(email))
		{
			GD.Print("Nem regisztrált emailcím");
			return;
		}

		if (!Database.checkPassword(email,password))
		{
			GD.Print("Hibás jelszó");
			return;
		}

		var user = Database.getUser(email);
		LoginManager.SetUser(user);

		GD.Print("Sikeres bejelentkezés " + user.Username);
	}

	private void OnCloseRequested()
	{
		this.Hide();
		GetParent().RemoveChild(this);
	}

	private void OnRegisterPressed()
	{
		var reg = packed.Instantiate();
		this.Hide();
		GetParent().AddChild(reg);
	}
}
