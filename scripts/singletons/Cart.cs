using Godot;
using Godot.Collections;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

public partial class Cart : Node
{

	private List<ObjectId> content;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		content = new List<ObjectId>();
	}

	public void AddProduct(Product product)
	{
		content.Add(product.Id);
	}

	public void RemoveProduct(Product product) 
	{
		content.Remove(product.Id);
	}
}
