using Godot;
using System;

public partial class Updater : Timer
{
	[Export]
	private NodePath _product_container;

	/// <summary>
	/// Terméklista frissítésének a kérése
	/// </summary>
	private void _On_Timeout()
	{
		var product_container = GetNode<VBoxContainer>(_product_container) as ProductContainer;

		product_container.Update();
	}
}
