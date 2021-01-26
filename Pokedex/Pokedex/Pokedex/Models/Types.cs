using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
	public class Types : PropertyChangeNotifier
	
	{
		public int Slot { get; set; }

		public Type Type { get; set; }
	}
}
