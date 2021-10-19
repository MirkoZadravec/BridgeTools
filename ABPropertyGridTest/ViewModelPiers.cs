using AllplanBridge;
using System.Collections.Generic;

namespace ABPropertyGridTest
{
	public class ViewModelPiers
	{
		public string Project { get; set; }
		public ViewModelPier Pier1 { get; set; } = new ViewModelPier() { Name = "Pier 1", Description = "Long pier" };
		public ViewModelPier Pier2 { get; set; } = new ViewModelPier() { Name = "Pier 2", Description = "Short pier" };
	}

	public enum RadioOptionsEnum
	{
		One,
		Two,
		Three
	}

	public enum ComboOptionsEnum
	{
		First,
		Second,
		Third
	}

	public class ViewModelPier
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsReady { get; set; }
		public double Darkness { get; set; }
		public ViewModelGeoPos GeoPos { get; set; } = new ViewModelGeoPos() { Description = "This is a geometric position" };
		public List<ViewModelAnimal> Animals = new List<ViewModelAnimal>() { new ViewModelCat() { Age = "5" }, new ViewModelDog() { Name = "Ben" } };

		public List<ComboItem<RadioOptionsEnum>> RadioOptions = new List<ComboItem<RadioOptionsEnum>>()
		{
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.One, "One" ),
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.Two, "Two" ),
			new ComboItem<RadioOptionsEnum>(RadioOptionsEnum.Three, "Three" )
		};
		public ComboItem<RadioOptionsEnum> RadioOption { get; set; } = null;

		public List<ComboItem<ComboOptionsEnum>> ComboOptions = new List<ComboItem<ComboOptionsEnum>>()
		{
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.First, "First" ),
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.Second, "Second" ),
			new ComboItem<ComboOptionsEnum>(ComboOptionsEnum.Third, "Third" )
		};
		public ComboItem<ComboOptionsEnum> ComboOption { get; set; } = null;
	}

	public class ViewModelGeoPos
	{
		public string Description { get; set; }
	}

	public class ViewModelAnimal
	{
	}

	public class ViewModelDog : ViewModelAnimal
	{
		public string Name { get; set; }
	}

	public class ViewModelCat : ViewModelAnimal
	{
		public string Age { get; set; }
	}
}
