using System.Security.Cryptography.X509Certificates;
using UnitTestExample.API.Utilities;

namespace UnitTestExample.UT
{
    public class UnitTest1
    {
        [Fact]
        public void TestWithoutParameters()
        {
            //Arrange = Kaynaklarin hazirlanmasi
            string[] expected = { "this", "is", "our", "data" };
            object parameters = null;
            TryDataMethods tryData = new();

            //Act = Methodlarin testi
            var result = tryData.TryData();

            //Assert = Datalarin dogrulanmasi
            Assert.Equal(expected, result);
        }



        [Theory]
        [InlineData(true)]
        public void TestWithParameters(bool check)
        {
            //Arrange
            string[] expected = { "this", "is", "bool", "example" };
            TryDataMethods tryData = new();

            //Act
            var result = tryData.TryDataBool(check);

            //Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> sumDatas => new List<object[]>
        {
            new object[] { false },
            new object[] { true }
        };

        [Theory]
        [MemberData(nameof(sumDatas))]
        public void TestWithMultipleParameters(bool check)
        {
            //Arrange
            string[] expected = { "this", "is", "bool", "example" };
            TryDataMethods tryData = new();

            //Act
            var result = tryData.TryDataBool(check);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}