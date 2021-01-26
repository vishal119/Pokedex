using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
	public class Sprites
	{
		[JsonProperty(PropertyName = "front_default")]
		public string FrontDefaultURI { get; set; }
	}
}
