using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuillderDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var architect = new BuildingArchitect();

            IBuilder houseBuilder = new HouseBuilder();
            IBuilder mallBuilder=new MallBuilder();

            // Build House
            architect.Construct(houseBuilder);
            var houseObject = houseBuilder.GetBuildingObject();
            Console.WriteLine($"Building Name is :{houseObject.Name}");
            Console.WriteLine($"Floor is :{houseObject.FloorSize}");
            Console.WriteLine($"Numner of walls are :{houseObject.NumberOfWalls}");
            Console.WriteLine($"Roof is :{houseObject.RoofSzie}");

            //Build Mall
            architect.Construct(mallBuilder);
            var mallObject = mallBuilder.GetBuildingObject();
            Console.WriteLine($"Building Name is :{mallObject.Name}");
            Console.WriteLine($"Floor is :{mallObject.FloorSize}");
            Console.WriteLine($"Numner of walls are :{mallObject.NumberOfWalls}");
            Console.WriteLine($"Roof is :{mallObject.RoofSzie}");

            Console.ReadLine();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BuildingArchitect
    {
        public void Construct(IBuilder builder)
        {
            builder.SetName();
            builder.BuildFloor();
            builder.BuildWalls();
            builder.BuildRoof();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IBuilder
    {
        void SetName();
        void BuildFloor();
        void BuildWalls();
        void BuildRoof();
        BuildingObject GetBuildingObject();
    }
    /// <summary>
    /// 
    /// </summary>
    public class BuildingObject
    {
        public string Name { get; set; }
        public decimal FloorSize { get; set; }
        public int NumberOfWalls { get; set; }

        public decimal RoofSzie { get; set; }
    }

    public  class HouseBuilder:IBuilder
    {
        private BuildingObject _buildingObject = new BuildingObject();

        public void SetName()
        {
            _buildingObject.Name = "House";
        }
        public void BuildFloor()
        {
            _buildingObject.FloorSize = 100;
        }

        public void BuildWalls()
        {
            _buildingObject.NumberOfWalls = 10;
        }

        public void BuildRoof()
        {
            _buildingObject.RoofSzie = 150;
        }

        public BuildingObject GetBuildingObject()
        {
            return this._buildingObject;
        }
    }

    public class MallBuilder : IBuilder
    {
        private BuildingObject _buildingObject = new BuildingObject();
        public void SetName()
        {
            _buildingObject.Name = "Mall";
        }
        public void BuildFloor()
        {
            _buildingObject.FloorSize = 500;
        }

        public void BuildWalls()
        {
            _buildingObject.NumberOfWalls = 45;
        }

        public void BuildRoof()
        {
            _buildingObject.RoofSzie = 596;
        }

        public BuildingObject GetBuildingObject()
        {
            return this._buildingObject;
        }
    }

    
}
