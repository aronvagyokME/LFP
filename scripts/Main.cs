using Godot;
using System;

public partial class Main : Control
{

	[Export]
	private PackedScene _add_product;
	
	/// <summary>
	/// Termék hozzáadása ablak megnyitása
	/// </summary>
	private void _On_Add_Product_Pressed()
	{
		if (!LoginManager.IsLoggedIn())
		{
			return;
		}

		var add_product =  _add_product.Instantiate();
		AddChild(add_product);
	}
}
