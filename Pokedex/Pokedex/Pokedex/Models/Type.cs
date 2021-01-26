using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
	public class Type : PropertyChangeNotifier
	
	{
		public string Name { get; set; }
		public string Url { get; set; }
	}
}
