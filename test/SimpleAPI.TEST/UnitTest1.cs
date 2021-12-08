using System;
using Xunit;
using SimpleAPI.Controllers;

namespace SimpleAPI.TEST
{
    public class UnitTest1
    {
        WeatherForecastController controller = new WeatherForecastController();
        [Fact]
        public void GetReturnsMyWeather(){
            var returnValue = controller.GetWeather("Cool");
            Assert.Equal("Cool", returnValue.Value.Summary);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
