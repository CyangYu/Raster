using System;

namespace Raster.Drawing.Primitive
{
	public partial struct Rgba
	{
		#region Public Static Fields
        /// <summary>
		/// AliceBlue 			
		/// </summary>
		public static readonly Rgba AliceBlue 				= new Rgba(0xF0, 0xF8, 0xFF, 0xFF);
		/// <summary>
		/// AntiqueWhite 		
		/// </summary>
		public static readonly Rgba AntiqueWhite 			= new Rgba(0xFA, 0xEB, 0xD7, 0xFF);
		/// <summary>
		/// Aqua 				
		/// </summary>
		public static readonly Rgba Aqua 					= new Rgba(0x00, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// Aquamarine 			
		/// </summary>
		public static readonly Rgba Aquamarine 				= new Rgba(0x7F, 0xFF, 0xD4, 0xFF);
		/// <summary>
		/// Azure 				
		/// </summary>
		public static readonly Rgba Azure 					= new Rgba(0xF0, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// Beige 				
		/// </summary>
		public static readonly Rgba Beige 					= new Rgba(0xF5, 0xF5, 0xDC, 0xFF);
		/// <summary>
		/// Bisque 				
		/// </summary>
		public static readonly Rgba Bisque 					= new Rgba(0xFF, 0xE4, 0xC4, 0xFF);
		/// <summary>
		/// Black 				
		/// </summary>
		public static readonly Rgba Black 					= new Rgba(0x00, 0x00, 0x00, 0xFF);
		/// <summary>
		/// BlanchedAlmond 
		/// </summary>
		public static readonly Rgba BlanchedAlmond 			= new Rgba(0xFF, 0xEB, 0xCD, 0xFF);
		/// <summary>
		/// Blue 				
		/// </summary>
		public static readonly Rgba Blue 					= new Rgba(0x00, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// BlueViolet 			
		/// </summary>
		public static readonly Rgba BlueViolet 				= new Rgba(0x8A, 0x2B, 0xE2, 0xFF);
		/// <summary>
		/// Brown 				
		/// </summary>
		public static readonly Rgba Brown 					= new Rgba(0xA5, 0x2A, 0x2A, 0xFF);
		/// <summary>
		/// BurlyWood 			
		/// </summary>
		public static readonly Rgba BurlyWood 				= new Rgba(0xDE, 0xB8, 0x87, 0xFF);
		/// <summary>
		/// CadetBlue 			
		/// </summary>
		public static readonly Rgba CadetBlue 				= new Rgba(0x5F, 0x9E, 0xA0, 0xFF);
		/// <summary>
		/// Chartreuse 			
		/// </summary>
		public static readonly Rgba Chartreuse 				= new Rgba(0x7F, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// Chocolate 			
		/// </summary>
		public static readonly Rgba Chocolate 				= new Rgba(0xD2, 0x69, 0x1E, 0xFF);
		/// <summary>
		/// Coral 				
		/// </summary>
		public static readonly Rgba Coral 					= new Rgba(0xFF, 0x7F, 0x50, 0xFF);
		/// <summary>
		/// CornflowerBlue 
		/// </summary>
		public static readonly Rgba CornflowerBlue 			= new Rgba(0x64, 0x95, 0xED, 0xFF);
		/// <summary>
		/// Cornsilk 			
		/// </summary>
		public static readonly Rgba Cornsilk 				= new Rgba(0xFF, 0xF8, 0xDC, 0xFF);
		/// <summary>
		/// Crimson 			
		/// </summary>
		public static readonly Rgba Crimson 				= new Rgba(0xDC, 0x14, 0x3C, 0xFF);
		/// <summary>
		/// Cyan 				
		/// </summary>
		public static readonly Rgba Cyan 					= new Rgba(0x00, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// DarkBlue 			
		/// </summary>
		public static readonly Rgba DarkBlue 				= new Rgba(0x00, 0x00, 0x8B, 0xFF);
		/// <summary>
		/// DarkCyan 			
		/// </summary>
		public static readonly Rgba DarkCyan 				= new Rgba(0x00, 0x8B, 0x8B, 0xFF);
		/// <summary>
		/// DarkGoldenRod 	
		/// </summary>
		public static readonly Rgba DarkGoldenRod 			= new Rgba(0xB8, 0x86, 0x0B, 0xFF);
		/// <summary>
		/// DarkGray 			
		/// </summary>
		public static readonly Rgba DarkGray 				= new Rgba(0xA9, 0xA9, 0xA9, 0xFF);
		/// <summary>
		/// DarkGreen 			
		/// </summary>
		public static readonly Rgba DarkGreen 				= new Rgba(0x00, 0x64, 0x00, 0xFF);
		/// <summary>
		/// DarkKhaki 			
		/// </summary>
		public static readonly Rgba DarkKhaki 				= new Rgba(0xBD, 0xB7, 0x6B, 0xFF);
		/// <summary>
		/// DarkMagenta 		
		/// </summary>
		public static readonly Rgba DarkMagenta 			= new Rgba(0x8B, 0x00, 0x8B, 0xFF);
		/// <summary>
		/// DarkOliveGreen 
		/// </summary>
		public static readonly Rgba DarkOliveGreen 			= new Rgba(0x55, 0x6B, 0x2F, 0xFF);
		/// <summary>
		/// Darkorange 			
		/// </summary>
		public static readonly Rgba Darkorange 				= new Rgba(0xFF, 0x8C, 0x00, 0xFF);
		/// <summary>
		/// DarkOrchid 			
		/// </summary>
		public static readonly Rgba DarkOrchid 				= new Rgba(0x99, 0x32, 0xCC, 0xFF);
		/// <summary>
		/// DarkRed 			
		/// </summary>
		public static readonly Rgba DarkRed 				= new Rgba(0x8B, 0x00, 0x00, 0xFF);
		/// <summary>
		/// DarkSalmon 			
		/// </summary>
		public static readonly Rgba DarkSalmon 				= new Rgba(0xE9, 0x96, 0x7A, 0xFF);
		/// <summary>
		/// DarkSeaGreen 		
		/// </summary>
		public static readonly Rgba DarkSeaGreen 			= new Rgba(0x8F, 0xBC, 0x8F, 0xFF);
		/// <summary>
		/// DarkSlateBlue 	
		/// </summary>
		public static readonly Rgba DarkSlateBlue 			= new Rgba(0x48, 0x3D, 0x8B, 0xFF);
		/// <summary>
		/// DarkSlateGray 	
		/// </summary>
		public static readonly Rgba DarkSlateGray 			= new Rgba(0x2F, 0x, 0x, 0xFF);
		/// <summary>
		/// DarkTurquoise 	
		/// </summary>
		public static readonly Rgba DarkTurquoise 			= new Rgba(0x00, 0xCE, 0xD1, 0xFF);
		/// <summary>
		/// DarkViolet 			
		/// </summary>
		public static readonly Rgba DarkViolet 				= new Rgba(0x94, 0x00, 0xD3, 0xFF);
		/// <summary>
		/// DeepPink 			
		/// </summary>
		public static readonly Rgba DeepPink 				= new Rgba(0xFF, 0x14, 0x93, 0xFF);
		/// <summary>
		/// DeepSkyBlue 		
		/// </summary>
		public static readonly Rgba DeepSkyBlue 			= new Rgba(0x00, 0xBF, 0xFF, 0xFF);
		/// <summary>
		/// DimGray 			
		/// </summary>
		public static readonly Rgba DimGray 				= new Rgba(0x69, 0x69, 0x69, 0xFF);
		/// <summary>
		/// DodgerBlue 			
		/// </summary>
		public static readonly Rgba DodgerBlue 				= new Rgba(0x1E, 0x90, 0xFF, 0xFF);
		/// <summary>
		/// Feldspar 			
		/// </summary>
		public static readonly Rgba Feldspar 				= new Rgba(0xD1, 0x92, 0x75, 0xFF);
		/// <summary>
		/// FireBrick 			
		/// </summary>
		public static readonly Rgba FireBrick 				= new Rgba(0xB2, 0x22, 0x22, 0xFF);
		/// <summary>
		/// FloralWhite 		
		/// </summary>
		public static readonly Rgba FloralWhite 			= new Rgba(0xFF, 0xFA, 0xF0, 0xFF);
		/// <summary>
		/// ForestGreen 		
		/// </summary>
		public static readonly Rgba ForestGreen 			= new Rgba(0x22, 0x8B, 0x22, 0xFF);
		/// <summary>
		/// Fuchsia 			
		/// </summary>
		public static readonly Rgba Fuchsia 				= new Rgba(0xFF, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// Gainsboro 			
		/// </summary>
		public static readonly Rgba Gainsboro 				= new Rgba(0xDC, 0xDC, 0xDC, 0xFF);
		/// <summary>
		/// GhostWhite 			
		/// </summary>
		public static readonly Rgba GhostWhite 				= new Rgba(0xF8, 0xF8, 0xFF, 0xFF);
		/// <summary>
		/// Gold 				
		/// </summary>
		public static readonly Rgba Gold 					= new Rgba(0xFF, 0xD7, 0x00, 0xFF);
		/// <summary>
		/// GoldenRod 			
		/// </summary>
		public static readonly Rgba GoldenRod 				= new Rgba(0xDA, 0xA5, 0x20, 0xFF);
		/// <summary>
		/// Gray 				
		/// </summary>
		public static readonly Rgba Gray 					= new Rgba(0x80, 0x80, 0x80, 0xFF);
		/// <summary>
		/// Green 				
		/// </summary>
		public static readonly Rgba Green 					= new Rgba(0x00, 0x80, 0x00, 0xFF);
		/// <summary>
		/// GreenYellow 		
		/// </summary>
		public static readonly Rgba GreenYellow 			= new Rgba(0xAD, 0xFF, 0x2F, 0xFF);
		/// <summary>
		/// HoneyDew 			
		/// </summary>
		public static readonly Rgba HoneyDew 				= new Rgba(0xF0, 0xFF, 0xF0, 0xFF);
		/// <summary>
		/// HotPink 			
		/// </summary>
		public static readonly Rgba HotPink 				= new Rgba(0xFF, 0x69, 0xB4, 0xFF);
		/// <summary>
		/// IndianRed  			
		/// </summary>
		public static readonly Rgba IndianRed  				= new Rgba(0xCD, 0x5C, 0x5C, 0xFF);
		/// <summary>
		/// Indigo  			
		/// </summary>
		public static readonly Rgba Indigo  				= new Rgba(0x4B, 0x00, 0x82, 0xFF);
		/// <summary>
		/// Ivory 				
		/// </summary>
		public static readonly Rgba Ivory 					= new Rgba(0xFF, 0xFF, 0xF0, 0xFF);
		/// <summary>
		/// Khaki 				
		/// </summary>
		public static readonly Rgba Khaki 					= new Rgba(0xF0, 0xE6, 0x8C, 0xFF);
		/// <summary>
		/// Lavender 			
		/// </summary>
		public static readonly Rgba Lavender 				= new Rgba(0xE6, 0xE6, 0xFA, 0xFF);
		/// <summary>
		/// LavenderBlush 	
		/// </summary>
		public static readonly Rgba LavenderBlush 			= new Rgba(0xFF, 0xF0, 0xF5, 0xFF);
		/// <summary>
		/// LawnGreen 			
		/// </summary>
		public static readonly Rgba LawnGreen 				= new Rgba(0x7C, 0xFC, 0x00, 0xFF);
		/// <summary>
		/// LemonChiffon 		
		/// </summary>
		public static readonly Rgba LemonChiffon 			= new Rgba(0xFF, 0xFA, 0xCD, 0xFF);
		/// <summary>
		/// LightBlue 			
		/// </summary>
		public static readonly Rgba LightBlue 				= new Rgba(0xAD, 0xD8, 0xE6, 0xFF);
		/// <summary>
		/// LightCoral 			
		/// </summary>
		public static readonly Rgba LightCoral 				= new Rgba(0xF0, 0x80, 0x80, 0xFF);
		/// <summary>
		/// LightCyan 			
		/// </summary>
		public static readonly Rgba LightCyan 				= new Rgba(0xE0, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba LightGoldenRodYellow	= new Rgba(0xFA, 0xFA, 0xD2, 0xFF);
		/// <summary>
		/// LightGrey 			
		/// </summary>
		public static readonly Rgba LightGrey 				= new Rgba(0xD3, 0xD3, 0xD3, 0xFF);
		/// <summary>
		/// LightGreen 			
		/// </summary>
		public static readonly Rgba LightGreen 				= new Rgba(0x90, 0xEE, 0x90, 0xFF);
		/// <summary>
		/// LightPink 			
		/// </summary>
		public static readonly Rgba LightPink 				= new Rgba(0xFF, 0xB6, 0xC1, 0xFF);
		/// <summary>
		/// LightSalmon 		
		/// </summary>
		public static readonly Rgba LightSalmon 			= new Rgba(0xFF, 0xA0, 0x7A, 0xFF);
		/// <summary>
		/// LightSeaGreen 	
		/// </summary>
		public static readonly Rgba LightSeaGreen 			= new Rgba(0x20, 0xB2, 0xAA, 0xFF);
		/// <summary>
		/// LightSkyBlue 		
		/// </summary>
		public static readonly Rgba LightSkyBlue 			= new Rgba(0x87, 0xCE, 0xFA, 0xFF);
		/// <summary>
		/// LightSlateBlue 
		/// </summary>
		public static readonly Rgba LightSlateBlue 			= new Rgba(0x84, 0x70, 0xFF, 0xFF);
		/// <summary>
		/// LightSlateGray 
		/// </summary>
		public static readonly Rgba LightSlateGray 			= new Rgba(0x77, 0x88, 0x99, 0xFF);
		/// <summary>
		/// LightSteelBlue 
		/// </summary>
		public static readonly Rgba LightSteelBlue 			= new Rgba(0xB0, 0xC4, 0xDE, 0xFF);
		/// <summary>
		/// LightYellow 		
		/// </summary>
		public static readonly Rgba LightYellow 			= new Rgba(0xFF, 0xFF, 0xE0, 0xFF);
		/// <summary>
		/// Lime 				
		/// </summary>
		public static readonly Rgba Lime 					= new Rgba(0x00, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// LimeGreen 			
		/// </summary>
		public static readonly Rgba LimeGreen 				= new Rgba(0x32, 0xCD, 0x32, 0xFF);
		/// <summary>
		/// Linen 				
		/// </summary>
		public static readonly Rgba Linen 					= new Rgba(0xFA, 0xF0, 0xE6, 0xFF);
		/// <summary>
		/// Magenta 			
		/// </summary>
		public static readonly Rgba Magenta 				= new Rgba(0xFF, 0x00, 0xFF, 0xFF);
		/// <summary>
		/// Maroon 				
		/// </summary>
		public static readonly Rgba Maroon 					= new Rgba(0x80, 0x00, 0x00, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba MediumAquaMarine		= new Rgba(0x66, 0xCD, 0xAA, 0xFF);
		/// <summary>
		/// MediumBlue 			
		/// </summary>
		public static readonly Rgba MediumBlue 				= new Rgba(0x00, 0x00, 0xCD, 0xFF);
		/// <summary>
		/// MediumOrchid 		
		/// </summary>
		public static readonly Rgba MediumOrchid 			= new Rgba(0xBA, 0x55, 0xD3, 0xFF);
		/// <summary>
		/// MediumPurple 		
		/// </summary>
		public static readonly Rgba MediumPurple 			= new Rgba(0x93, 0x70, 0xD8, 0xFF);
		/// <summary>
		/// MediumSeaGreen 
		/// </summary>
		public static readonly Rgba MediumSeaGreen 			= new Rgba(0x3C, 0xB3, 0x71, 0xFF);
		/// <summary>
		/// MediumSlateBlue
		/// </summary>
		public static readonly Rgba MediumSlateBlue			= new Rgba(0x7B, 0x68, 0xEE, 0xFF);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Rgba MediumSpringGreen		= new Rgba(0x00, 0xFA, 0x9A, 0xFF);
		/// <summary>
		/// MediumTurquoise
		/// </summary>
		public static readonly Rgba MediumTurquoise			= new Rgba(0x48, 0xD1, 0xCC, 0xFF);
		/// <summary>
		/// MediumVioletRed
		/// </summary>
		public static readonly Rgba MediumVioletRed			= new Rgba(0xC7, 0x15, 0x85, 0xFF);
		/// <summary>
		/// MidnightBlue 		
		/// </summary>
		public static readonly Rgba MidnightBlue 			= new Rgba(0x19, 0x19, 0x70, 0xFF);
		/// <summary>
		/// MintCream 			
		/// </summary>
		public static readonly Rgba MintCream 				= new Rgba(0xF5, 0xFF, 0xFA, 0xFF);
		/// <summary>
		/// MistyRose 			
		/// </summary>
		public static readonly Rgba MistyRose 				= new Rgba(0xFF, 0xE4, 0xE1, 0xFF);
		/// <summary>
		/// Moccasin 			
		/// </summary>
		public static readonly Rgba Moccasin 				= new Rgba(0xFF, 0xE4, 0xB5, 0xFF);
		/// <summary>
		/// NavajoWhite 		
		/// </summary>
		public static readonly Rgba NavajoWhite 			= new Rgba(0xFF, 0xDE, 0xAD, 0xFF);
		/// <summary>
		/// Navy 				
		/// </summary>
		public static readonly Rgba Navy 					= new Rgba(0x00, 0x00, 0x80, 0xFF);
		/// <summary>
		/// OldLace 			
		/// </summary>
		public static readonly Rgba OldLace 				= new Rgba(0xFD, 0xF5, 0xE6, 0xFF);
		/// <summary>
		/// Olive 				
		/// </summary>
		public static readonly Rgba Olive 					= new Rgba(0x80, 0x80, 0x00, 0xFF);
		/// <summary>
		/// OliveDrab 			
		/// </summary>
		public static readonly Rgba OliveDrab 				= new Rgba(0x6B, 0x8E, 0x23, 0xFF);
		/// <summary>
		/// Orange 				
		/// </summary>
		public static readonly Rgba Orange 					= new Rgba(0xFF, 0xA5, 0x00, 0xFF);
		/// <summary>
		/// OrangeRed 			
		/// </summary>
		public static readonly Rgba OrangeRed 				= new Rgba(0xFF, 0x45, 0x00, 0xFF);
		/// <summary>
		/// Orchid 				
		/// </summary>
		public static readonly Rgba Orchid 					= new Rgba(0xDA, 0x70, 0xD6, 0xFF);
		/// <summary>
		/// PaleGoldenRod 	
		/// </summary>
		public static readonly Rgba PaleGoldenRod 			= new Rgba(0xEE, 0xE8, 0xAA, 0xFF);
		/// <summary>
		/// PaleGreen 			
		/// </summary>
		public static readonly Rgba PaleGreen 				= new Rgba(0x98, 0xFB, 0x98, 0xFF);
		/// <summary>
		/// PaleTurquoise 	
		/// </summary>
		public static readonly Rgba PaleTurquoise 			= new Rgba(0xAF, 0xEE, 0xEE, 0xFF);
		/// <summary>
		/// PaleVioletRed 	
		/// </summary>
		public static readonly Rgba PaleVioletRed 			= new Rgba(0xD8, 0x70, 0x93, 0xFF);
		/// <summary>
		/// PapayaWhip 			
		/// </summary>
		public static readonly Rgba PapayaWhip 				= new Rgba(0xFF, 0xEF, 0xD5, 0xFF);
		/// <summary>
		/// PeachPuff 			
		/// </summary>
		public static readonly Rgba PeachPuff 				= new Rgba(0xFF, 0xDA, 0xB9, 0xFF);
		/// <summary>
		/// Peru 				
		/// </summary>
		public static readonly Rgba Peru 					= new Rgba(0xCD, 0x85, 0x3F, 0xFF);
		/// <summary>
		/// Pink 				
		/// </summary>
		public static readonly Rgba Pink 					= new Rgba(0xFF, 0xC0, 0xCB, 0xFF);
		/// <summary>
		/// Plum 				
		/// </summary>
		public static readonly Rgba Plum 					= new Rgba(0xDD, 0xA0, 0xDD, 0xFF);
		/// <summary>
		/// PowderBlue 			
		/// </summary>
		public static readonly Rgba PowderBlue 				= new Rgba(0xB0, 0xE0, 0xE6, 0xFF);
		/// <summary>
		/// Purple 				
		/// </summary>
		public static readonly Rgba Purple 					= new Rgba(0x80, 0x00, 0x80, 0xFF);
		/// <summary>
		/// Red 				
		/// </summary>
		public static readonly Rgba Red 					= new Rgba(0xFF, 0x00, 0x00, 0xFF);
		/// <summary>
		/// RosyBrown 			
		/// </summary>
		public static readonly Rgba RosyBrown 				= new Rgba(0xBC, 0x8F, 0x8F, 0xFF);
		/// <summary>
		/// RoyalBlue 			
		/// </summary>
		public static readonly Rgba RoyalBlue 				= new Rgba(0x41, 0x69, 0xE1, 0xFF);
		/// <summary>
		/// SaddleBrown 		
		/// </summary>
		public static readonly Rgba SaddleBrown 			= new Rgba(0x8B, 0x45, 0x13, 0xFF);
		/// <summary>
		/// Salmon 				
		/// </summary>
		public static readonly Rgba Salmon 					= new Rgba(0xFA, 0x80, 0x72, 0xFF);
		/// <summary>
		/// SandyBrown 			
		/// </summary>
		public static readonly Rgba SandyBrown 				= new Rgba(0xF4, 0xA4, 0x60, 0xFF);
		/// <summary>
		/// SeaGreen 			
		/// </summary>
		public static readonly Rgba SeaGreen 				= new Rgba(0x2E, 0x8B, 0x57, 0xFF);
		/// <summary>
		/// SeaShell 			
		/// </summary>
		public static readonly Rgba SeaShell 				= new Rgba(0xFF, 0xF5, 0xEE, 0xFF);
		/// <summary>
		/// Sienna 				
		/// </summary>
		public static readonly Rgba Sienna 					= new Rgba(0xA0, 0x52, 0x2D, 0xFF);
		/// <summary>
		/// Silver 				
		/// </summary>
		public static readonly Rgba Silver 					= new Rgba(0xC0, 0xC0, 0xC0, 0xFF);
		/// <summary>
		/// SkyBlue 			
		/// </summary>
		public static readonly Rgba SkyBlue 				= new Rgba(0x87, 0xCE, 0xEB, 0xFF);
		/// <summary>
		/// SlateBlue 			
		/// </summary>
		public static readonly Rgba SlateBlue 				= new Rgba(0x6A, 0x5A, 0xCD, 0xFF);
		/// <summary>
		/// SlateGray 			
		/// </summary>
		public static readonly Rgba SlateGray 				= new Rgba(0x70, 0x80, 0x90, 0xFF);
		/// <summary>
		/// Snow 				
		/// </summary>
		public static readonly Rgba Snow 					= new Rgba(0xFF, 0xFA, 0xFA, 0xFF);
		/// <summary>
		/// SpringGreen 		
		/// </summary>
		public static readonly Rgba SpringGreen 			= new Rgba(0x00, 0xFF, 0x7F, 0xFF);
		/// <summary>
		/// SteelBlue 			
		/// </summary>
		public static readonly Rgba SteelBlue 				= new Rgba(0x46, 0x82, 0xB4, 0xFF);
		/// <summary>
		/// Tan 				
		/// </summary>
		public static readonly Rgba Tan 					= new Rgba(0xD2, 0xB4, 0x8C, 0xFF);
		/// <summary>
		/// Teal 				
		/// </summary>
		public static readonly Rgba Teal 					= new Rgba(0x00, 0x80, 0x80, 0xFF);
		/// <summary>
		/// Thistle 			
		/// </summary>
		public static readonly Rgba Thistle 				= new Rgba(0xD8, 0xBF, 0xD8, 0xFF);
		/// <summary>
		/// Tomato 				
		/// </summary>
		public static readonly Rgba Tomato 					= new Rgba(0xFF, 0x63, 0x47, 0xFF);
		/// <summary>
		/// Turquoise 			
		/// </summary>
		public static readonly Rgba Turquoise 				= new Rgba(0x40, 0xE0, 0xD0, 0xFF);
		/// <summary>
		/// Violet 				
		/// </summary>
		public static readonly Rgba Violet 					= new Rgba(0xEE, 0x82, 0xEE, 0xFF);
		/// <summary>
		/// VioletRed 			
		/// </summary>
		public static readonly Rgba VioletRed 				= new Rgba(0xD0, 0x20, 0x90, 0xFF);
		/// <summary>
		/// Wheat 				
		/// </summary>
		public static readonly Rgba Wheat 					= new Rgba(0xF5, 0xDE, 0xB3, 0xFF);
		/// <summary>
		/// White 				
		/// </summary>
		public static readonly Rgba White 					= new Rgba(0xFF, 0xFF, 0xFF, 0xFF);
		/// <summary>
		/// WhiteSmoke 			
		/// </summary>
		public static readonly Rgba WhiteSmoke 				= new Rgba(0xF5, 0xF5, 0xF5, 0xFF);
		/// <summary>
		/// Yellow 				
		/// </summary>
		public static readonly Rgba Yellow 					= new Rgba(0xFF, 0xFF, 0x00, 0xFF);
		/// <summary>
		/// YellowGreen 		
		/// </summary>
		public static readonly Rgba YellowGreen 			= new Rgba(0x9A, 0xCD, 0x32, 0xFF);
		#endregion Public Static Fields
	}

	public partial struct Color
	{
		#region Public Static Fields
		/// <summary>
		/// AliceBlue			
		/// </summary>
		public static readonly Color AliceBlue			    = new Color(0.941176f, 0.972549f, 1.000000f, 1.000000f);
		/// <summary>
		/// AntiqueWhite		
		/// </summary>
		public static readonly Color AntiqueWhite			= new Color(0.980392f, 0.921569f, 0.843137f, 1.000000f);
		/// <summary>
		/// Aqua				
		/// </summary>
		public static readonly Color Aqua					= new Color(0.000000f, 1.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// Aquamarine			
		/// </summary>
		public static readonly Color Aquamarine			    = new Color(0.498039f, 1.000000f, 0.831373f, 1.000000f);
		/// <summary>
		/// Azure				
		/// </summary>
		public static readonly Color Azure				    = new Color(0.941176f, 1.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// Beige				
		/// </summary>
		public static readonly Color Beige				    = new Color(0.960784f, 0.960784f, 0.862745f, 1.000000f);
		/// <summary>
		/// Bisque				
		/// </summary>
		public static readonly Color Bisque				    = new Color(1.000000f, 0.894118f, 0.768627f, 1.000000f);
		/// <summary>
		/// Black				
		/// </summary>
		public static readonly Color Black				    = new Color(0.000000f, 0.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// BlanchedAlmond	
		/// </summary>
		public static readonly Color BlanchedAlmond		    = new Color(1.000000f, 0.921569f, 0.803922f, 1.000000f);
		/// <summary>
		/// Blue				
		/// </summary>
		public static readonly Color Blue					= new Color(0.000000f, 0.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// BlueViolet			
		/// </summary>
		public static readonly Color BlueViolet			    = new Color(0.541176f, 0.168627f, 0.886275f, 1.000000f);
		/// <summary>
		/// Brown				
		/// </summary>
		public static readonly Color Brown				    = new Color(0.647059f, 0.164706f, 0.164706f, 1.000000f);
		/// <summary>
		/// BurlyWood			
		/// </summary>
		public static readonly Color BurlyWood			    = new Color(0.870588f, 0.721569f, 0.529412f, 1.000000f);
		/// <summary>
		/// CadetBlue			
		/// </summary>
		public static readonly Color CadetBlue			    = new Color(0.372549f, 0.619608f, 0.627451f, 1.000000f);
		/// <summary>
		/// Chartreuse			
		/// </summary>
		public static readonly Color Chartreuse			    = new Color(0.498039f, 1.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// Chocolate			
		/// </summary>
		public static readonly Color Chocolate			    = new Color(0.823529f, 0.411765f, 0.117647f, 1.000000f);
		/// <summary>
		/// Coral				
		/// </summary>
		public static readonly Color Coral				    = new Color(1.000000f, 0.498039f, 0.313726f, 1.000000f);
		/// <summary>
		/// CornflowerBlue	
		/// </summary>
		public static readonly Color CornflowerBlue		    = new Color(0.392157f, 0.584314f, 0.929412f, 1.000000f);
		/// <summary>
		/// Cornsilk			
		/// </summary>
		public static readonly Color Cornsilk				= new Color(1.000000f, 0.972549f, 0.862745f, 1.000000f);
		/// <summary>
		/// Crimson			
		/// </summary>
		public static readonly Color Crimson				= new Color(0.862745f, 0.078431f, 0.235294f, 1.000000f);
		/// <summary>
		/// Cyan				
		/// </summary>
		public static readonly Color Cyan					= new Color(0.000000f, 1.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// DarkBlue			
		/// </summary>
		public static readonly Color DarkBlue				= new Color(0.000000f, 0.000000f, 0.545098f, 1.000000f);
		/// <summary>
		/// DarkCyan			
		/// </summary>
		public static readonly Color DarkCyan				= new Color(0.000000f, 0.545098f, 0.545098f, 1.000000f);
		/// <summary>
		/// DarkGoldenRod		
		/// </summary>
		public static readonly Color DarkGoldenRod		    = new Color(0.721569f, 0.525490f, 0.043137f, 1.000000f);
		/// <summary>
		/// DarkGray			
		/// </summary>
		public static readonly Color DarkGray				= new Color(0.662745f, 0.662745f, 0.662745f, 1.000000f);
		/// <summary>
		/// DarkGreen			
		/// </summary>
		public static readonly Color DarkGreen			    = new Color(0.000000f, 0.392157f, 0.000000f, 1.000000f);
		/// <summary>
		/// DarkKhaki			
		/// </summary>
		public static readonly Color DarkKhaki			    = new Color(0.741176f, 0.717647f, 0.419608f, 1.000000f);
		/// <summary>
		/// DarkMagenta		
		/// </summary>
		public static readonly Color DarkMagenta			= new Color(0.545098f, 0.000000f, 0.545098f, 1.000000f);
		/// <summary>
		/// DarkOliveGreen	
		/// </summary>
		public static readonly Color DarkOliveGreen		    = new Color(0.333333f, 0.419608f, 0.184314f, 1.000000f);
		/// <summary>
		/// Darkorange			
		/// </summary>
		public static readonly Color Darkorange			    = new Color(1.000000f, 0.549020f, 0.000000f, 1.000000f);
		/// <summary>
		/// DarkOrchid			
		/// </summary>
		public static readonly Color DarkOrchid			    = new Color(0.600000f, 0.196078f, 0.800000f, 1.000000f);
		/// <summary>
		/// DarkRed			
		/// </summary>
		public static readonly Color DarkRed				= new Color(0.545098f, 0.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// DarkSalmon			
		/// </summary>
		public static readonly Color DarkSalmon			    = new Color(0.913725f, 0.588235f, 0.478431f, 1.000000f);
		/// <summary>
		/// DarkSeaGreen		
		/// </summary>
		public static readonly Color DarkSeaGreen			= new Color(0.560784f, 0.737255f, 0.560784f, 1.000000f);
		/// <summary>
		/// DarkSlateBlue		
		/// </summary>
		public static readonly Color DarkSlateBlue		    = new Color(0.282353f, 0.239216f, 0.545098f, 1.000000f);
		/// <summary>
		/// DarkSlateGray		
		/// </summary>
		public static readonly Color DarkSlateGray		    = new Color(0.184314f, 0.309804f, 0.309804f, 1.000000f);
		/// <summary>
		/// DarkTurquoise		
		/// </summary>
		public static readonly Color DarkTurquoise		    = new Color(0.000000f, 0.807843f, 0.819608f, 1.000000f);
		/// <summary>
		/// DarkViolet			
		/// </summary>
		public static readonly Color DarkViolet			    = new Color(0.580392f, 0.000000f, 0.827451f, 1.000000f);
		/// <summary>
		/// DeepPink			
		/// </summary>
		public static readonly Color DeepPink				= new Color(1.000000f, 0.078431f, 0.576471f, 1.000000f);
		/// <summary>
		/// DeepSkyBlue		
		/// </summary>
		public static readonly Color DeepSkyBlue			= new Color(0.000000f, 0.749020f, 1.000000f, 1.000000f);
		/// <summary>
		/// DimGray			
		/// </summary>
		public static readonly Color DimGray				= new Color(0.411765f, 0.411765f, 0.411765f, 1.000000f);
		/// <summary>
		/// DodgerBlue			
		/// </summary>
		public static readonly Color DodgerBlue			    = new Color(0.117647f, 0.564706f, 1.000000f, 1.000000f);
		/// <summary>
		/// Feldspar			
		/// </summary>
		public static readonly Color Feldspar				= new Color(0.819608f, 0.572549f, 0.458824f, 1.000000f);
		/// <summary>
		/// FireBrick			
		/// </summary>
		public static readonly Color FireBrick			    = new Color(0.698039f, 0.133333f, 0.133333f, 1.000000f);
		/// <summary>
		/// FloralWhite		
		/// </summary>
		public static readonly Color FloralWhite			= new Color(1.000000f, 0.980392f, 0.941176f, 1.000000f);
		/// <summary>
		/// ForestGreen		
		/// </summary>
		public static readonly Color ForestGreen			= new Color(0.133333f, 0.545098f, 0.133333f, 1.000000f);
		/// <summary>
		/// Fuchsia			
		/// </summary>
		public static readonly Color Fuchsia				= new Color(1.000000f, 0.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// Gainsboro			
		/// </summary>
		public static readonly Color Gainsboro			    = new Color(0.862745f, 0.862745f, 0.862745f, 1.000000f);
		/// <summary>
		/// GhostWhite			
		/// </summary>
		public static readonly Color GhostWhite			    = new Color(0.972549f, 0.972549f, 1.000000f, 1.000000f);
		/// <summary>
		/// Gold				
		/// </summary>
		public static readonly Color Gold					= new Color(1.000000f, 0.843137f, 0.000000f, 1.000000f);
		/// <summary>
		/// GoldenRod			
		/// </summary>
		public static readonly Color GoldenRod			    = new Color(0.854902f, 0.647059f, 0.125490f, 1.000000f);
		/// <summary>
		/// Gray				
		/// </summary>
		public static readonly Color Gray					= new Color(0.501961f, 0.501961f, 0.501961f, 1.000000f);
		/// <summary>
		/// Green				
		/// </summary>
		public static readonly Color Green				    = new Color(0.000000f, 0.501961f, 0.000000f, 1.000000f);
		/// <summary>
		/// GreenYellow		
		/// </summary>
		public static readonly Color GreenYellow			= new Color(0.678431f, 1.000000f, 0.184314f, 1.000000f);
		/// <summary>
		/// HoneyDew			
		/// </summary>
		public static readonly Color HoneyDew				= new Color(0.941176f, 1.000000f, 0.941176f, 1.000000f);
		/// <summary>
		/// HotPink			
		/// </summary>
		public static readonly Color HotPink				= new Color(1.000000f, 0.411765f, 0.705882f, 1.000000f);
		/// <summary>
		/// IndianRed			
		/// </summary>
		public static readonly Color IndianRed			    = new Color(0.803922f, 0.360784f, 0.360784f, 1.000000f);
		/// <summary>
		/// Indigo				
		/// </summary>
		public static readonly Color Indigo				    = new Color(0.294118f, 0.000000f, 0.509804f, 1.000000f);
		/// <summary>
		/// Ivory				
		/// </summary>
		public static readonly Color Ivory				    = new Color(1.000000f, 1.000000f, 0.941176f, 1.000000f);
		/// <summary>
		/// Khaki				
		/// </summary>
		public static readonly Color Khaki				    = new Color(0.941176f, 0.901961f, 0.549020f, 1.000000f);
		/// <summary>
		/// Lavender			
		/// </summary>
		public static readonly Color Lavender				= new Color(0.901961f, 0.901961f, 0.980392f, 1.000000f);
		/// <summary>
		/// LavenderBlush		
		/// </summary>
		public static readonly Color LavenderBlush		    = new Color(1.000000f, 0.941176f, 0.960784f, 1.000000f);
		/// <summary>
		/// LawnGreen			
		/// </summary>
		public static readonly Color LawnGreen			    = new Color(0.486275f, 0.988235f, 0.000000f, 1.000000f);
		/// <summary>
		/// LemonChiffon		
		/// </summary>
		public static readonly Color LemonChiffon			= new Color(1.000000f, 0.980392f, 0.803922f, 1.000000f);
		/// <summary>
		/// LightBlue			
		/// </summary>
		public static readonly Color LightBlue			    = new Color(0.678431f, 0.847059f, 0.901961f, 1.000000f);
		/// <summary>
		/// LightCoral			
		/// </summary>
		public static readonly Color LightCoral			    = new Color(0.941176f, 0.501961f, 0.501961f, 1.000000f);
		/// <summary>
		/// LightCyan			
		/// </summary>
		public static readonly Color LightCyan			    = new Color(0.878431f, 1.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Color LightGoldenRodYellow	= new Color(0.980392f, 0.980392f, 0.823529f, 1.000000f);
		/// <summary>
		/// LightGrey			
		/// </summary>
		public static readonly Color LightGrey			    = new Color(0.827451f, 0.827451f, 0.827451f, 1.000000f);
		/// <summary>
		/// LightGreen			
		/// </summary>
		public static readonly Color LightGreen			    = new Color(0.564706f, 0.933333f, 0.564706f, 1.000000f);
		/// <summary>
		/// LightPink			
		/// </summary>
		public static readonly Color LightPink			    = new Color(1.000000f, 0.713726f, 0.756863f, 1.000000f);
		/// <summary>
		/// LightSalmon		
		/// </summary>
		public static readonly Color LightSalmon			= new Color(1.000000f, 0.627451f, 0.478431f, 1.000000f);
		/// <summary>
		/// LightSeaGreen		
		/// </summary>
		public static readonly Color LightSeaGreen		    = new Color(0.125490f, 0.698039f, 0.666667f, 1.000000f);
		/// <summary>
		/// LightSkyBlue		
		/// </summary>
		public static readonly Color LightSkyBlue			= new Color(0.529412f, 0.807843f, 0.980392f, 1.000000f);
		/// <summary>
		/// LightSlateBlue	
		/// </summary>
		public static readonly Color LightSlateBlue		    = new Color(0.517647f, 0.439216f, 1.000000f, 1.000000f);
		/// <summary>
		/// LightSlateGray	
		/// </summary>
		public static readonly Color LightSlateGray		    = new Color(0.466667f, 0.533333f, 0.600000f, 1.000000f);
		/// <summary>
		/// LightSteelBlue	
		/// </summary>
		public static readonly Color LightSteelBlue		    = new Color(0.690196f, 0.768627f, 0.870588f, 1.000000f);
		/// <summary>
		/// LightYellow		
		/// </summary>
		public static readonly Color LightYellow			= new Color(1.000000f, 1.000000f, 0.878431f, 1.000000f);
		/// <summary>
		/// Lime				
		/// </summary>
		public static readonly Color Lime					= new Color(0.000000f, 1.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// LimeGreen			
		/// </summary>
		public static readonly Color LimeGreen			    = new Color(0.196078f, 0.803922f, 0.196078f, 1.000000f);
		/// <summary>
		/// Linen				
		/// </summary>
		public static readonly Color Linen				    = new Color(0.980392f, 0.941176f, 0.901961f, 1.000000f);
		/// <summary>
		/// Magenta			
		/// </summary>
		public static readonly Color Magenta				= new Color(1.000000f, 0.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// Maroon				
		/// </summary>
		public static readonly Color Maroon				    = new Color(0.501961f, 0.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Color MediumAquaMarine		= new Color(0.400000f, 0.803922f, 0.666667f, 1.000000f);
		/// <summary>
		/// MediumBlue			
		/// </summary>
		public static readonly Color MediumBlue			    = new Color(0.000000f, 0.000000f, 0.803922f, 1.000000f);
		/// <summary>
		/// MediumOrchid		
		/// </summary>
		public static readonly Color MediumOrchid			= new Color(0.729412f, 0.333333f, 0.827451f, 1.000000f);
		/// <summary>
		/// MediumPurple		
		/// </summary>
		public static readonly Color MediumPurple			= new Color(0.576471f, 0.439216f, 0.847059f, 1.000000f);
		/// <summary>
		/// MediumSeaGreen	
		/// </summary>
		public static readonly Color MediumSeaGreen		    = new Color(0.235294f, 0.701961f, 0.443137f, 1.000000f);
		/// <summary>
		/// MediumSlateBlue
		/// </summary>
		public static readonly Color MediumSlateBlue		= new Color(0.482353f, 0.407843f, 0.933333f, 1.000000f);
		/// <summary>
		/// 
		/// </summary>
		public static readonly Color MediumSpringGree		= new Color(0.000000f, 0.980392f, 0.603922f, 1.000000f);
		/// <summary>
		/// MediumTurquoise
		/// </summary>
		public static readonly Color MediumTurquoise		= new Color(0.282353f, 0.819608f, 0.800000f, 1.000000f);
		/// <summary>
		/// MediumVioletRed
		/// </summary>
		public static readonly Color MediumVioletRed		= new Color(0.780392f, 0.082353f, 0.521569f, 1.000000f);
		/// <summary>
		/// MidnightBlue		
		/// </summary>
		public static readonly Color MidnightBlue			= new Color(0.098039f, 0.098039f, 0.439216f, 1.000000f);
		/// <summary>
		/// MintCream			
		/// </summary>
		public static readonly Color MintCream			    = new Color(0.960784f, 1.000000f, 0.980392f, 1.000000f);
		/// <summary>
		/// MistyRose			
		/// </summary>
		public static readonly Color MistyRose			    = new Color(1.000000f, 0.894118f, 0.882353f, 1.000000f);
		/// <summary>
		/// Moccasin			
		/// </summary>
		public static readonly Color Moccasin				= new Color(1.000000f, 0.894118f, 0.709804f, 1.000000f);
		/// <summary>
		/// NavajoWhite		
		/// </summary>
		public static readonly Color NavajoWhite			= new Color(1.000000f, 0.870588f, 0.678431f, 1.000000f);
		/// <summary>
		/// Navy				
		/// </summary>
		public static readonly Color Navy					= new Color(0.000000f, 0.000000f, 0.501961f, 1.000000f);
		/// <summary>
		/// OldLace			
		/// </summary>
		public static readonly Color OldLace				= new Color(0.992157f, 0.960784f, 0.901961f, 1.000000f);
		/// <summary>
		/// Olive				
		/// </summary>
		public static readonly Color Olive				    = new Color(0.501961f, 0.501961f, 0.000000f, 1.000000f);
		/// <summary>
		/// OliveDrab			
		/// </summary>
		public static readonly Color OliveDrab			    = new Color(0.419608f, 0.556863f, 0.137255f, 1.000000f);
		/// <summary>
		/// Orange				
		/// </summary>
		public static readonly Color Orange				    = new Color(1.000000f, 0.647059f, 0.000000f, 1.000000f);
		/// <summary>
		/// OrangeRed			
		/// </summary>
		public static readonly Color OrangeRed			    = new Color(1.000000f, 0.270588f, 0.000000f, 1.000000f);
		/// <summary>
		/// Orchid				
		/// </summary>
		public static readonly Color Orchid				    = new Color(0.854902f, 0.439216f, 0.839216f, 1.000000f);
		/// <summary>
		/// PaleGoldenRod		
		/// </summary>
		public static readonly Color PaleGoldenRod		    = new Color(0.933333f, 0.909804f, 0.666667f, 1.000000f);
		/// <summary>
		/// PaleGreen			
		/// </summary>
		public static readonly Color PaleGreen			    = new Color(0.596078f, 0.984314f, 0.596078f, 1.000000f);
		/// <summary>
		/// PaleTurquoise		
		/// </summary>
		public static readonly Color PaleTurquoise		    = new Color(0.686275f, 0.933333f, 0.933333f, 1.000000f);
		/// <summary>
		/// PaleVioletRed		
		/// </summary>
		public static readonly Color PaleVioletRed		    = new Color(0.847059f, 0.439216f, 0.576471f, 1.000000f);
		/// <summary>
		/// PapayaWhip			
		/// </summary>
		public static readonly Color PapayaWhip			    = new Color(1.000000f, 0.937255f, 0.835294f, 1.000000f);
		/// <summary>
		/// PeachPuff			
		/// </summary>
		public static readonly Color PeachPuff			    = new Color(1.000000f, 0.854902f, 0.725490f, 1.000000f);
		/// <summary>
		/// Peru				
		/// </summary>
		public static readonly Color Peru					= new Color(0.803922f, 0.521569f, 0.247059f, 1.000000f);
		/// <summary>
		/// Pink				
		/// </summary>
		public static readonly Color Pink					= new Color(1.000000f, 0.752941f, 0.796078f, 1.000000f);
		/// <summary>
		/// Plum				
		/// </summary>
		public static readonly Color Plum					= new Color(0.866667f, 0.627451f, 0.866667f, 1.000000f);
		/// <summary>
		/// PowderBlue			
		/// </summary>
		public static readonly Color PowderBlue			    = new Color(0.690196f, 0.878431f, 0.901961f, 1.000000f);
		/// <summary>
		/// Purple				
		/// </summary>
		public static readonly Color Purple				    = new Color(0.501961f, 0.000000f, 0.501961f, 1.000000f);
		/// <summary>
		/// Red				
		/// </summary>
		public static readonly Color Red					= new Color(1.000000f, 0.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// RosyBrown			
		/// </summary>
		public static readonly Color RosyBrown			    = new Color(0.737255f, 0.560784f, 0.560784f, 1.000000f);
		/// <summary>
		/// RoyalBlue			
		/// </summary>
		public static readonly Color RoyalBlue			    = new Color(0.254902f, 0.411765f, 0.882353f, 1.000000f);
		/// <summary>
		/// SaddleBrown		
		/// </summary>
		public static readonly Color SaddleBrown			= new Color(0.545098f, 0.270588f, 0.074510f, 1.000000f);
		/// <summary>
		/// Salmon				
		/// </summary>
		public static readonly Color Salmon				    = new Color(0.980392f, 0.501961f, 0.447059f, 1.000000f);
		/// <summary>
		/// SandyBrown			
		/// </summary>
		public static readonly Color SandyBrown			    = new Color(0.956863f, 0.643137f, 0.376471f, 1.000000f);
		/// <summary>
		/// SeaGreen			
		/// </summary>
		public static readonly Color SeaGreen				= new Color(0.180392f, 0.545098f, 0.341176f, 1.000000f);
		/// <summary>
		/// SeaShell			
		/// </summary>
		public static readonly Color SeaShell				= new Color(1.000000f, 0.960784f, 0.933333f, 1.000000f);
		/// <summary>
		/// Sienna				
		/// </summary>
		public static readonly Color Sienna				    = new Color(0.627451f, 0.321569f, 0.176471f, 1.000000f);
		/// <summary>
		/// Silver				
		/// </summary>
		public static readonly Color Silver				    = new Color(0.752941f, 0.752941f, 0.752941f, 1.000000f);
		/// <summary>
		/// SkyBlue			
		/// </summary>
		public static readonly Color SkyBlue				= new Color(0.529412f, 0.807843f, 0.921569f, 1.000000f);
		/// <summary>
		/// SlateBlue			
		/// </summary>
		public static readonly Color SlateBlue			    = new Color(0.415686f, 0.352941f, 0.803922f, 1.000000f);
		/// <summary>
		/// SlateGray			
		/// </summary>
		public static readonly Color SlateGray			    = new Color(0.439216f, 0.501961f, 0.564706f, 1.000000f);
		/// <summary>
		/// Snow				
		/// </summary>
		public static readonly Color Snow					= new Color(1.000000f, 0.980392f, 0.980392f, 1.000000f);
		/// <summary>
		/// SpringGreen		
		/// </summary>
		public static readonly Color SpringGreen			= new Color(0.000000f, 1.000000f, 0.498039f, 1.000000f);
		/// <summary>
		/// SteelBlue			
		/// </summary>
		public static readonly Color SteelBlue			    = new Color(0.274510f, 0.509804f, 0.705882f, 1.000000f);
		/// <summary>
		/// Tan				
		/// </summary>
		public static readonly Color Tan					= new Color(0.823529f, 0.705882f, 0.549020f, 1.000000f);
		/// <summary>
		/// Teal				
		/// </summary>
		public static readonly Color Teal					= new Color(0.000000f, 0.501961f, 0.501961f, 1.000000f);
		/// <summary>
		/// Thistle			
		/// </summary>
		public static readonly Color Thistle				= new Color(0.847059f, 0.749020f, 0.847059f, 1.000000f);
		/// <summary>
		/// Tomato				
		/// </summary>
		public static readonly Color Tomato				    = new Color(1.000000f, 0.388235f, 0.278431f, 1.000000f);
		/// <summary>
		/// Turquoise			
		/// </summary>
		public static readonly Color Turquoise			    = new Color(0.250980f, 0.878431f, 0.815686f, 1.000000f);
		/// <summary>
		/// Violet				
		/// </summary>
		public static readonly Color Violet				    = new Color(0.933333f, 0.509804f, 0.933333f, 1.000000f);
		/// <summary>
		/// VioletRed			
		/// </summary>
		public static readonly Color VioletRed			    = new Color(0.815686f, 0.125490f, 0.564706f, 1.000000f);
		/// <summary>
		/// Wheat				
		/// </summary>
		public static readonly Color Wheat				    = new Color(0.960784f, 0.870588f, 0.701961f, 1.000000f);
		/// <summary>
		/// White				
		/// </summary>
		public static readonly Color White				    = new Color(1.000000f, 1.000000f, 1.000000f, 1.000000f);
		/// <summary>
		/// WhiteSmoke			
		/// </summary>
		public static readonly Color WhiteSmoke			    = new Color(0.960784f, 0.960784f, 0.960784f, 1.000000f);
		/// <summary>
		/// Yellow				
		/// </summary>
		public static readonly Color Yellow				    = new Color(1.000000f, 1.000000f, 0.000000f, 1.000000f);
		/// <summary>
		/// YellowGreen		
		/// </summary>
		public static readonly Color YellowGreen			= new Color(0.603922f, 0.803922f, 0.196078f, 1.000000f);
		
		#endregion Public Static Fields
	}
}