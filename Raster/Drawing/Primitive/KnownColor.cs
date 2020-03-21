using System;

namespace Raster.Drawing.Primitive
{
	/// <summary>
	/// 
	/// </summary>
	public partial struct Rgba
	{
		#region Public Static Fields
		/// <summary>
		/// AliceBlue 			
		/// </summary>
		public static readonly Rgba AliceBlue = new Rgba(0xF0, 0xF8, 0xFF, 0xFF);
		/// <summary>
		/// AntiqueWhite 		
		/// </summary>
		public static readonly Rgba AntiqueWhite = new Rgba(0xFA, 0xEB, 0xD7, 0xFF);
		/// <summary>
		/// Aqua 				
		/// </summary>
		public static readonly Rgba Aqua = new Rgba(0x00, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// Aquamarine 			
		/// </summary>
		public static readonly Rgba Aquamarine = new Rgba(0x7F, 0xFF, 0xD4, 0xFF);
		/// <summary>
		/// Azure 				
		/// </summary>
		public static readonly Rgba Azure = new Rgba(0xF0, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// Beige 				
		/// </summary>
		public static readonly Rgba Beige = new Rgba(0xF5, 0xF5, 0xDC, 0xFF);
		/// <summary>
		/// Bisque 				
		/// </summary>
		public static readonly Rgba Bisque = new Rgba(0xFF, 0xE4, 0xC4, 0xFF);
		/// <summary>
		/// Black 				
		/// </summary>
		public static readonly Rgba Black = new Rgba(0x00, 0x00, 0x00, 0xFF);
		/// <summary>
		/// BlanchedAlmond 
		/// </summary>
		public static readonly Rgba BlanchedAlmond = new Rgba(0xFF, 0xEB, 0xCD, 0xFF);
		/// <summary>
		/// Blue 				
		/// </summary>
		public static readonly Rgba Blue = new Rgba(0x00, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// BlueViolet 			
		/// </summary>
		public static readonly Rgba BlueViolet = new Rgba(0x8A, 0x2B, 0xE2, 0xFF);
		/// <summary>
		/// Brown 				
		/// </summary>
		public static readonly Rgba Brown = new Rgba(0xA5, 0x2A, 0x2A, 0xFF);
		/// <summary>
		/// BurlyWood 			
		/// </summary>
		public static readonly Rgba BurlyWood = new Rgba(0xDE, 0xB8, 0x87, 0xFF);
		/// <summary>
		/// CadetBlue 			
		/// </summary>
		public static readonly Rgba CadetBlue = new Rgba(0x5F, 0x9E, 0xA0, 0xFF);
		/// <summary>
		/// Chartreuse 			
		/// </summary>
		public static readonly Rgba Chartreuse = new Rgba(0x7F, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// Chocolate 			
		/// </summary>
		public static readonly Rgba Chocolate = new Rgba(0xD2, 0x69, 0x1E, 0xFF);
		/// <summary>
		/// Coral 				
		/// </summary>
		public static readonly Rgba Coral = new Rgba(0xFF, 0x7F, 0x50, 0xFF);
		/// <summary>
		/// CornflowerBlue 
		/// </summary>
		public static readonly Rgba CornflowerBlue = new Rgba(0x64, 0x95, 0xED, 0xFF);
		/// <summary>
		/// Cornsilk 			
		/// </summary>
		public static readonly Rgba Cornsilk = new Rgba(0xFF, 0xF8, 0xDC, 0xFF);
		/// <summary>
		/// Crimson 			
		/// </summary>
		public static readonly Rgba Crimson = new Rgba(0xDC, 0x14, 0x3C, 0xFF);
		/// <summary>
		/// Cyan 				
		/// </summary>
		public static readonly Rgba Cyan = new Rgba(0x00, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// DarkBlue 			
		/// </summary>
		public static readonly Rgba DarkBlue = new Rgba(0x00, 0x00, 0x8B, 0xFF);
		/// <summary>
		/// DarkCyan 			
		/// </summary>
		public static readonly Rgba DarkCyan = new Rgba(0x00, 0x8B, 0x8B, 0xFF);
		/// <summary>
		/// DarkGoldenRod 	
		/// </summary>
		public static readonly Rgba DarkGoldenRod = new Rgba(0xB8, 0x86, 0x0B, 0xFF);
		/// <summary>
		/// DarkGray 			
		/// </summary>
		public static readonly Rgba DarkGray = new Rgba(0xA9, 0xA9, 0xA9, 0xFF);
		/// <summary>
		/// DarkGreen 			
		/// </summary>
		public static readonly Rgba DarkGreen = new Rgba(0x00, 0x64, 0x00, 0xFF);
		/// <summary>
		/// DarkKhaki 			
		/// </summary>
		public static readonly Rgba DarkKhaki = new Rgba(0xBD, 0xB7, 0x6B, 0xFF);
		/// <summary>
		/// DarkMagenta 		
		/// </summary>
		public static readonly Rgba DarkMagenta = new Rgba(0x8B, 0x00, 0x8B, 0xFF);
		/// <summary>
		/// DarkOliveGreen 
		/// </summary>
		public static readonly Rgba DarkOliveGreen = new Rgba(0x55, 0x6B, 0x2F, 0xFF);
		/// <summary>
		/// Darkorange 			
		/// </summary>
		public static readonly Rgba Darkorange = new Rgba(0xFF, 0x8C, 0x00, 0xFF);
		/// <summary>
		/// DarkOrchid 			
		/// </summary>
		public static readonly Rgba DarkOrchid = new Rgba(0x99, 0x32, 0xCC, 0xFF);
		/// <summary>
		/// DarkRed 			
		/// </summary>
		public static readonly Rgba DarkRed = new Rgba(0x8B, 0x00, 0x00, 0xFF);
		/// <summary>
		/// DarkSalmon 			
		/// </summary>
		public static readonly Rgba DarkSalmon = new Rgba(0xE9, 0x96, 0x7A, 0xFF);
		/// <summary>
		/// DarkSeaGreen 		
		/// </summary>
		public static readonly Rgba DarkSeaGreen = new Rgba(0x8F, 0xBC, 0x8F, 0xFF);
		/// <summary>
		/// DarkSlateBlue 	
		/// </summary>
		public static readonly Rgba DarkSlateBlue = new Rgba(0x48, 0x3D, 0x8B, 0xFF);
		/// <summary>
		/// DarkSlateGray 	
		/// </summary>
		public static readonly Rgba DarkSlateGray = new Rgba(0x2F, 0x4F, 0x4F, 0xFF);
		/// <summary>
		/// DarkTurquoise 	
		/// </summary>
		public static readonly Rgba DarkTurquoise = new Rgba(0x00, 0xCE, 0xD1, 0xFF);
		/// <summary>
		/// DarkViolet 			
		/// </summary>
		public static readonly Rgba DarkViolet = new Rgba(0x94, 0x00, 0xD3, 0xFF);
		/// <summary>
		/// DeepPink 			
		/// </summary>
		public static readonly Rgba DeepPink = new Rgba(0xFF, 0x14, 0x93, 0xFF);
		/// <summary>
		/// DeepSkyBlue 		
		/// </summary>
		public static readonly Rgba DeepSkyBlue = new Rgba(0x00, 0xBF, 0xFF, 0xFF);
		/// <summary>
		/// DimGray 			
		/// </summary>
		public static readonly Rgba DimGray = new Rgba(0x69, 0x69, 0x69, 0xFF);
		/// <summary>
		/// DodgerBlue 			
		/// </summary>
		public static readonly Rgba DodgerBlue = new Rgba(0x1E, 0x90, 0xFF, 0xFF);
		/// <summary>
		/// Feldspar 			
		/// </summary>
		public static readonly Rgba Feldspar = new Rgba(0xD1, 0x92, 0x75, 0xFF);
		/// <summary>
		/// FireBrick 			
		/// </summary>
		public static readonly Rgba FireBrick = new Rgba(0xB2, 0x22, 0x22, 0xFF);
		/// <summary>
		/// FloralWhite 		
		/// </summary>
		public static readonly Rgba FloralWhite = new Rgba(0xFF, 0xFA, 0xF0, 0xFF);
		/// <summary>
		/// ForestGreen 		
		/// </summary>
		public static readonly Rgba ForestGreen = new Rgba(0x22, 0x8B, 0x22, 0xFF);
		/// <summary>
		/// Fuchsia 			
		/// </summary>
		public static readonly Rgba Fuchsia = new Rgba(0xFF, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// Gainsboro 			
		/// </summary>
		public static readonly Rgba Gainsboro = new Rgba(0xDC, 0xDC, 0xDC, 0xFF);
		/// <summary>
		/// GhostWhite 			
		/// </summary>
		public static readonly Rgba GhostWhite = new Rgba(0xF8, 0xF8, 0xFF, 0xFF);
		/// <summary>
		/// Gold 				
		/// </summary>
		public static readonly Rgba Gold = new Rgba(0xFF, 0xD7, 0x00, 0xFF);
		/// <summary>
		/// GoldenRod 			
		/// </summary>
		public static readonly Rgba GoldenRod = new Rgba(0xDA, 0xA5, 0x20, 0xFF);
		/// <summary>
		/// Gray 				
		/// </summary>
		public static readonly Rgba Gray = new Rgba(0x80, 0x80, 0x80, 0xFF);
		/// <summary>
		/// Green 				
		/// </summary>
		public static readonly Rgba Green = new Rgba(0x00, 0x80, 0x00, 0xFF);
		/// <summary>
		/// GreenYellow 		
		/// </summary>
		public static readonly Rgba GreenYellow = new Rgba(0xAD, 0xFF, 0x2F, 0xFF);
		/// <summary>
		/// HoneyDew 			
		/// </summary>
		public static readonly Rgba HoneyDew = new Rgba(0xF0, 0xFF, 0xF0, 0xFF);
		/// <summary>
		/// HotPink 			
		/// </summary>
		public static readonly Rgba HotPink = new Rgba(0xFF, 0x69, 0xB4, 0xFF);
		/// <summary>
		/// IndianRed  			
		/// </summary>
		public static readonly Rgba IndianRed = new Rgba(0xCD, 0x5C, 0x5C, 0xFF);
		/// <summary>
		/// Indigo  			
		/// </summary>
		public static readonly Rgba Indigo = new Rgba(0x4B, 0x00, 0x82, 0xFF);
		/// <summary>
		/// Ivory 				
		/// </summary>
		public static readonly Rgba Ivory = new Rgba(0xFF, 0xFF, 0xF0, 0xFF);
		/// <summary>
		/// Khaki 				
		/// </summary>
		public static readonly Rgba Khaki = new Rgba(0xF0, 0xE6, 0x8C, 0xFF);
		/// <summary>
		/// Lavender 			
		/// </summary>
		public static readonly Rgba Lavender = new Rgba(0xE6, 0xE6, 0xFA, 0xFF);
		/// <summary>
		/// LavenderBlush 	
		/// </summary>
		public static readonly Rgba LavenderBlush = new Rgba(0xFF, 0xF0, 0xF5, 0xFF);
		/// <summary>
		/// LawnGreen 			
		/// </summary>
		public static readonly Rgba LawnGreen = new Rgba(0x7C, 0xFC, 0x00, 0xFF);
		/// <summary>
		/// LemonChiffon 		
		/// </summary>
		public static readonly Rgba LemonChiffon = new Rgba(0xFF, 0xFA, 0xCD, 0xFF);
		/// <summary>
		/// LightBlue 			
		/// </summary>
		public static readonly Rgba LightBlue = new Rgba(0xAD, 0xD8, 0xE6, 0xFF);
		/// <summary>
		/// LightCoral 			
		/// </summary>
		public static readonly Rgba LightCoral = new Rgba(0xF0, 0x80, 0x80, 0xFF);
		/// <summary>
		/// LightCyan 			
		/// </summary>
		public static readonly Rgba LightCyan = new Rgba(0xE0, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba LightGoldenRodYellow = new Rgba(0xFA, 0xFA, 0xD2, 0xFF);
		/// <summary>
		/// LightGrey 			
		/// </summary>
		public static readonly Rgba LightGrey = new Rgba(0xD3, 0xD3, 0xD3, 0xFF);
		/// <summary>
		/// LightGreen 			
		/// </summary>
		public static readonly Rgba LightGreen = new Rgba(0x90, 0xEE, 0x90, 0xFF);
		/// <summary>
		/// LightPink 			
		/// </summary>
		public static readonly Rgba LightPink = new Rgba(0xFF, 0xB6, 0xC1, 0xFF);
		/// <summary>
		/// LightSalmon 		
		/// </summary>
		public static readonly Rgba LightSalmon = new Rgba(0xFF, 0xA0, 0x7A, 0xFF);
		/// <summary>
		/// LightSeaGreen 	
		/// </summary>
		public static readonly Rgba LightSeaGreen = new Rgba(0x20, 0xB2, 0xAA, 0xFF);
		/// <summary>
		/// LightSkyBlue 		
		/// </summary>
		public static readonly Rgba LightSkyBlue = new Rgba(0x87, 0xCE, 0xFA, 0xFF);
		/// <summary>
		/// LightSlateBlue 
		/// </summary>
		public static readonly Rgba LightSlateBlue = new Rgba(0x84, 0x70, 0xFF, 0xFF);
		/// <summary>
		/// LightSlateGray 
		/// </summary>
		public static readonly Rgba LightSlateGray = new Rgba(0x77, 0x88, 0x99, 0xFF);
		/// <summary>
		/// LightSteelBlue 
		/// </summary>
		public static readonly Rgba LightSteelBlue = new Rgba(0xB0, 0xC4, 0xDE, 0xFF);
		/// <summary>
		/// LightYellow 		
		/// </summary>
		public static readonly Rgba LightYellow = new Rgba(0xFF, 0xFF, 0xE0, 0xFF);
		/// <summary>
		/// Lime 				
		/// </summary>
		public static readonly Rgba Lime = new Rgba(0x00, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// LimeGreen 			
		/// </summary>
		public static readonly Rgba LimeGreen = new Rgba(0x32, 0xCD, 0x32, 0xFF);
		/// <summary>
		/// Linen 				
		/// </summary>
		public static readonly Rgba Linen = new Rgba(0xFA, 0xF0, 0xE6, 0xFF);
		/// <summary>
		/// Magenta 			
		/// </summary>
		public static readonly Rgba Magenta = new Rgba(0xFF, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// Maroon 				
		/// </summary>
		public static readonly Rgba Maroon = new Rgba(0x80, 0x00, 0x00, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba MediumAquaMarine = new Rgba(0x66, 0xCD, 0xAA, 0xFF);
		/// <summary>
		/// MediumBlue 			
		/// </summary>
		public static readonly Rgba MediumBlue = new Rgba(0x00, 0x00, 0xCD, 0xFF);
		/// <summary>
		/// MediumOrchid 		
		/// </summary>
		public static readonly Rgba MediumOrchid = new Rgba(0xBA, 0x55, 0xD3, 0xFF);
		/// <summary>
		/// MediumPurple 		
		/// </summary>
		public static readonly Rgba MediumPurple = new Rgba(0x93, 0x70, 0xD8, 0xFF);
		/// <summary>
		/// MediumSeaGreen 
		/// </summary>
		public static readonly Rgba MediumSeaGreen = new Rgba(0x3C, 0xB3, 0x71, 0xFF);
		/// <summary>
		/// MediumSlateBlue
		/// </summary>
		public static readonly Rgba MediumSlateBlue = new Rgba(0x7B, 0x68, 0xEE, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba MediumSpringGreen = new Rgba(0x00, 0xFA, 0x9A, 0xFF);
		/// <summary>
		/// MediumTurquoise
		/// </summary>
		public static readonly Rgba MediumTurquoise = new Rgba(0x48, 0xD1, 0xCC, 0xFF);
		/// <summary>
		/// MediumVioletRed
		/// </summary>
		public static readonly Rgba MediumVioletRed = new Rgba(0xC7, 0x15, 0x85, 0xFF);
		/// <summary>
		/// MidnightBlue 		
		/// </summary>
		public static readonly Rgba MidnightBlue = new Rgba(0x19, 0x19, 0x70, 0xFF);
		/// <summary>
		/// MintCream 			
		/// </summary>
		public static readonly Rgba MintCream = new Rgba(0xF5, 0xFF, 0xFA, 0xFF);
		/// <summary>
		/// MistyRose 			
		/// </summary>
		public static readonly Rgba MistyRose = new Rgba(0xFF, 0xE4, 0xE1, 0xFF);
		/// <summary>
		/// Moccasin 			
		/// </summary>
		public static readonly Rgba Moccasin = new Rgba(0xFF, 0xE4, 0xB5, 0xFF);
		/// <summary>
		/// NavajoWhite 		
		/// </summary>
		public static readonly Rgba NavajoWhite = new Rgba(0xFF, 0xDE, 0xAD, 0xFF);
		/// <summary>
		/// Navy 				
		/// </summary>
		public static readonly Rgba Navy = new Rgba(0x00, 0x00, 0x80, 0xFF);
		/// <summary>
		/// OldLace 			
		/// </summary>
		public static readonly Rgba OldLace = new Rgba(0xFD, 0xF5, 0xE6, 0xFF);
		/// <summary>
		/// Olive 				
		/// </summary>
		public static readonly Rgba Olive = new Rgba(0x80, 0x80, 0x00, 0xFF);
		/// <summary>
		/// OliveDrab 			
		/// </summary>
		public static readonly Rgba OliveDrab = new Rgba(0x6B, 0x8E, 0x23, 0xFF);
		/// <summary>
		/// Orange 				
		/// </summary>
		public static readonly Rgba Orange = new Rgba(0xFF, 0xA5, 0x00, 0xFF);
		/// <summary>
		/// OrangeRed 			
		/// </summary>
		public static readonly Rgba OrangeRed = new Rgba(0xFF, 0x45, 0x00, 0xFF);
		/// <summary>
		/// Orchid 				
		/// </summary>
		public static readonly Rgba Orchid = new Rgba(0xDA, 0x70, 0xD6, 0xFF);
		/// <summary>
		/// PaleGoldenRod 	
		/// </summary>
		public static readonly Rgba PaleGoldenRod = new Rgba(0xEE, 0xE8, 0xAA, 0xFF);
		/// <summary>
		/// PaleGreen 			
		/// </summary>
		public static readonly Rgba PaleGreen = new Rgba(0x98, 0xFB, 0x98, 0xFF);
		/// <summary>
		/// PaleTurquoise 	
		/// </summary>
		public static readonly Rgba PaleTurquoise = new Rgba(0xAF, 0xEE, 0xEE, 0xFF);
		/// <summary>
		/// PaleVioletRed 	
		/// </summary>
		public static readonly Rgba PaleVioletRed = new Rgba(0xD8, 0x70, 0x93, 0xFF);
		/// <summary>
		/// PapayaWhip 			
		/// </summary>
		public static readonly Rgba PapayaWhip = new Rgba(0xFF, 0xEF, 0xD5, 0xFF);
		/// <summary>
		/// PeachPuff 			
		/// </summary>
		public static readonly Rgba PeachPuff = new Rgba(0xFF, 0xDA, 0xB9, 0xFF);
		/// <summary>
		/// Peru 				
		/// </summary>
		public static readonly Rgba Peru = new Rgba(0xCD, 0x85, 0x3F, 0xFF);
		/// <summary>
		/// Pink 				
		/// </summary>
		public static readonly Rgba Pink = new Rgba(0xFF, 0xC0, 0xCB, 0xFF);
		/// <summary>
		/// Plum 				
		/// </summary>
		public static readonly Rgba Plum = new Rgba(0xDD, 0xA0, 0xDD, 0xFF);
		/// <summary>
		/// PowderBlue 			
		/// </summary>
		public static readonly Rgba PowderBlue = new Rgba(0xB0, 0xE0, 0xE6, 0xFF);
		/// <summary>
		/// Purple 				
		/// </summary>
		public static readonly Rgba Purple = new Rgba(0x80, 0x00, 0x80, 0xFF);
		/// <summary>
		/// Red 				
		/// </summary>
		public static readonly Rgba Red = new Rgba(0xFF, 0x00, 0x00, 0xFF);
		/// <summary>
		/// RosyBrown 			
		/// </summary>
		public static readonly Rgba RosyBrown = new Rgba(0xBC, 0x8F, 0x8F, 0xFF);
		/// <summary>
		/// RoyalBlue 			
		/// </summary>
		public static readonly Rgba RoyalBlue = new Rgba(0x41, 0x69, 0xE1, 0xFF);
		/// <summary>
		/// SaddleBrown 		
		/// </summary>
		public static readonly Rgba SaddleBrown = new Rgba(0x8B, 0x45, 0x13, 0xFF);
		/// <summary>
		/// Salmon 				
		/// </summary>
		public static readonly Rgba Salmon = new Rgba(0xFA, 0x80, 0x72, 0xFF);
		/// <summary>
		/// SandyBrown 			
		/// </summary>
		public static readonly Rgba SandyBrown = new Rgba(0xF4, 0xA4, 0x60, 0xFF);
		/// <summary>
		/// SeaGreen 			
		/// </summary>
		public static readonly Rgba SeaGreen = new Rgba(0x2E, 0x8B, 0x57, 0xFF);
		/// <summary>
		/// SeaShell 			
		/// </summary>
		public static readonly Rgba SeaShell = new Rgba(0xFF, 0xF5, 0xEE, 0xFF);
		/// <summary>
		/// Sienna 				
		/// </summary>
		public static readonly Rgba Sienna = new Rgba(0xA0, 0x52, 0x2D, 0xFF);
		/// <summary>
		/// Silver 				
		/// </summary>
		public static readonly Rgba Silver = new Rgba(0xC0, 0xC0, 0xC0, 0xFF);
		/// <summary>
		/// SkyBlue 			
		/// </summary>
		public static readonly Rgba SkyBlue = new Rgba(0x87, 0xCE, 0xEB, 0xFF);
		/// <summary>
		/// SlateBlue 			
		/// </summary>
		public static readonly Rgba SlateBlue = new Rgba(0x6A, 0x5A, 0xCD, 0xFF);
		/// <summary>
		/// SlateGray 			
		/// </summary>
		public static readonly Rgba SlateGray = new Rgba(0x70, 0x80, 0x90, 0xFF);
		/// <summary>
		/// Snow 				
		/// </summary>
		public static readonly Rgba Snow = new Rgba(0xFF, 0xFA, 0xFA, 0xFF);
		/// <summary>
		/// SpringGreen 		
		/// </summary>
		public static readonly Rgba SpringGreen = new Rgba(0x00, 0xFF, 0x7F, 0xFF);
		/// <summary>
		/// SteelBlue 			
		/// </summary>
		public static readonly Rgba SteelBlue = new Rgba(0x46, 0x82, 0xB4, 0xFF);
		/// <summary>
		/// Tan 				
		/// </summary>
		public static readonly Rgba Tan = new Rgba(0xD2, 0xB4, 0x8C, 0xFF);
		/// <summary>
		/// Teal 				
		/// </summary>
		public static readonly Rgba Teal = new Rgba(0x00, 0x80, 0x80, 0xFF);
		/// <summary>
		/// Thistle 			
		/// </summary>
		public static readonly Rgba Thistle = new Rgba(0xD8, 0xBF, 0xD8, 0xFF);
		/// <summary>
		/// Tomato 				
		/// </summary>
		public static readonly Rgba Tomato = new Rgba(0xFF, 0x63, 0x47, 0xFF);
		/// <summary>
		/// Turquoise 			
		/// </summary>
		public static readonly Rgba Turquoise = new Rgba(0x40, 0xE0, 0xD0, 0xFF);
		/// <summary>
		/// Violet 				
		/// </summary>
		public static readonly Rgba Violet = new Rgba(0xEE, 0x82, 0xEE, 0xFF);
		/// <summary>
		/// VioletRed 			
		/// </summary>
		public static readonly Rgba VioletRed = new Rgba(0xD0, 0x20, 0x90, 0xFF);
		/// <summary>
		/// Wheat 				
		/// </summary>
		public static readonly Rgba Wheat = new Rgba(0xF5, 0xDE, 0xB3, 0xFF);
		/// <summary>
		/// White 				
		/// </summary>
		public static readonly Rgba White = new Rgba(0xFF, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// WhiteSmoke 			
		/// </summary>
		public static readonly Rgba WhiteSmoke = new Rgba(0xF5, 0xF5, 0xF5, 0xFF);
		/// <summary>
		/// Yellow 				
		/// </summary>
		public static readonly Rgba Yellow = new Rgba(0xFF, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// YellowGreen 		
		/// </summary>
		public static readonly Rgba YellowGreen = new Rgba(0x9A, 0xCD, 0x32, 0xFF);
		#endregion Public Static Fields
	}
}