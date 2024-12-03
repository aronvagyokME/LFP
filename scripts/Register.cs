using Godot;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

public partial class Register : Window
{
	[Export]
	private NodePath _email,_username,_password,_password2,_checkbox;


	private PackedScene packed;

	public override void _Ready()
	{
		packed = ResourceLoader.Load<PackedScene>("res://scenes/login.tscn");
	}

    public override void _Process(double delta)
    {
        
    }

	/// <summary>
	/// Felhasználó regisztrálása
	/// </summary>
    private void OnRegisterPressed()
	{
		var email = GetNode<LineEdit>(_email).Text;
		var username = GetNode<LineEdit>(_username).Text;
		var password = GetNode<LineEdit>(_password).Text;
		var password2 = GetNode<LineEdit>(_password2).Text;
		var checkbox = GetNode<CheckBox>(_checkbox);

	    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password2))
		{
			GD.Print("Valami üres");
			return;
		}

		if (!Regex.Match(email, @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").Success)
		{
			GD.Print("Hibás email");
			return;
		}

		if (Database.checkEmail(email))
		{
			GD.Print("Email foglalt");
			return;
		}

		if (Database.checkUsername(username))
		{
			GD.Print("Felhasználónév foglalt");
			return;
		}

		if (!Regex.Match(username, @"[a-zA-Z0-9]").Success)
		{
			GD.Print("Hibás felhasználónév");
			return;
		}

		if (!Regex.Match(password, @"[a-zA-Z0-9]").Success)
		{
			GD.Print("Hibás jelszó");
			return;
		}


		if (!password.Equals(password2)) {
			GD.Print("Nem egyező jelszó");
			return;
		}

		if (!checkbox.ButtonPressed) {
			GD.Print("ÁSZF nincs elfogadva");
			return;
		}
		
		var user = new User(email,username,password);
		Database.instertUser(user);

		LoginManager.SetUser(user);

		GD.Print("Sikeres regisztráció");

		this.Hide();
		GetParent().RemoveChild(this);
	}

	private void OnBackPressed()
	{
		var login = packed.Instantiate();
		this.Hide();
		GetParent().AddChild(login);
	}

	private void OnCloseRequested()
	{
		this.Hide();
		GetParent().RemoveChild(this);
	}
}
