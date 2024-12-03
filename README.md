url: https://colorhunt.co/palette/191a191e51284e9f3dd8e9a8
black: 191A19
dark_green: 1E5128
green: 4E9F3D
light_green: D8E9A8


icons: https://www.svgrepo.com/collection/user-interface-capped-icons/

Adatbázis: https://www.mongodb.com/cloud/atlas/register
szerkezet:
	user:
		id: [objectId]
		name: [string]
		email: [string]
		password: [hash]
		ads [objectid list]
	products:
		id [objectid]
  		advertiser [objectid]
  		title [string]
		quantity [int]
		unit [pc,kg,g]
		price [double]
		highlighted [true/false]
	orders:
		id: [objectid]
		customer: [objectid]
		seller: [objectid]
  		product: [objectid]
		date: [timestamp]
