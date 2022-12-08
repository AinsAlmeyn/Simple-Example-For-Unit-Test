1 - Test edilecek proje hazirlanmali

2 - Test edecegimiz UnitTestProjesini ayni solution icinde olusturuyoruz.

3 - Gerekli kutuphaneleri kuruyoruz
	1 - Microsoft.NET.Test.Sdk : xUnit.Net ile yazılmış kodların build edilmesini sağlayan SDK’dır.
	2 - xunit : xUnit.Net içerisinde kullanılacak tüm member’lar bu pakettedir.
	3 - xunit.runner.visualstudio : xUnit.Net ile yazılan test kodlarının Test Explorer penceresinde çalıştırılabilmesini sağlayan pakettir.

4 - Test edecegimiz projeyi Test etmemizi saglayacak olan projede referans olarak ekliyoruz.

5 - Testler 3 asamadan olusur:

	1 - Arrange : Test edilecek metodun kullanacağı kaynakların hazırlandığı bölümdür. Değişken tanımlama, nesne oluşturma vs. gerçekleştirilir.
	2 - Act : Arrange aşamasında hazırlanan değişkenler yahut nesneler eşliğinde test edilecek olan metodun çalıştırıldığı bölümdür. Mümkün mertebe kısa ve öz olması makbuldür.
	3 - Assert : Act aşamasında yapılan testin doğrulama evresidir. Tek bir Act’te birden fazla sonuç gerçekleşebilir. Misal olarak; exception fırlatılabilir yahut herhangi bir türde result dönebilir.

*1 - Test süreçlerinde ilgili metot herhangi bir parametre almıyorsa eğer ‘Fact’ attribute’u ile işaretlenmelidir.

6 - View sekmesinden Test Explorer sayfasini aciyoruz: Kisatlmasi = Gtrl+E,T

*2 - Ornek Test ;
public class MathematicsTest
{
    [Fact]
    public void SubtractTest()
    {
        #region Arrange
        //Kaynaklar hazırlanıyor.
        int number1 = 10;
        int number2 = 20;
        int expected = -10;
        Mathematics mathematics = new Mathematics();
        #endregion
        #region Act
        //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
        int result = mathematics.Subtract(number1, number2);
        #endregion
        #region Assert
        //Test neticesinde gelen data doğrulanıyor.
        Assert.Equal(expected, result);
        #endregion
    }
}


7 - Ornek Test(*2) deki 'Assert.Equel(expected,result);' satiri testin verilen data icin dondurmesi beklenen
	sonucu ve islemden donen sonucu karsilastirmakta ve ona gore test yapmaktadir.

8 - Assert Methodu ve Fonksiyonlarinin islevi;
	1 - Equal/NotEqual : Test sürecinde gelen sonuçla, beklenen sonucu kıyaslamamızı sağlayan metottur.
		1.1 = Assert.Equal(expected, result) / Assert.NotEqual(expected, result) 
	
	2 - Contain/DoesNotContain : Test sürecinde gelen sonuç içerisinde bir değerin olup olmamasını kontrol eden metotlardır.
		2.1 = var containsValues = new[] { 3, 5, 7, -10 };
			doesNotContainsValues = new[] { 2, 4, 6 };
			Assert.Contains<int>(containsValues, value => value == result);
			Assert.DoesNotContain<int>(doesNotContainsValues, value => value == result);

	3 - True/False : Test sürecinde şartın doğrulandığını(True) yahut yanlışlandığını(False) kontrol eden metotlardır
		3.1 = Assert.True(result < 10);
			Assert.False(result > 10);

	4 - Match/DoesNotMatch : Test sürecinde gelen değerin bildirilmiş olan Regex ifadesine uyup uymadığını kontrol eden metotlardır
		4.1 = Assert.Matches("sa{2}t", "saat");
			Assert.DoesNotMatch("sa{2}t", "muiddin");

	5 - StartsWith/EndsWith	Test sürecinde gelen değerin bildirilmiş olan değerle başlayıp bittiğini kontrol eden metotlardır.
		5.1 = Assert.StartsWith("G", "Gençay");
			Assert.EndsWith("y", "Gençay");

	6 - Empty/NotEmpty : Test sürecinde gelen koleksiyonel değerlerin boş olup olmama durumunu kontrol eden metotlardır.
		6.1 = var emptyCollection = new List<object>();
			var notEmptyCollection = new List<object>() { 3 };
			Assert.Empty(emptyCollection);
			Assert.NotEmpty(notEmptyCollection);

	7 - InRange/NotInRange	Test sürecinde gelen değerin belirli bir aralıkta olup olmamasını kontrol eden metotlardır.
		7.1 = Assert.InRange<int>(result, -1000, 1000);
			Assert.NotInRange<int>(result, 1000, 2000);

	8 - Single	Test sürecinde gelen koleksiyonel verinin içerisinde sadece tek bir data olup olmadığını kontrol eden metottur.
		8.1 =	var collection = new List<object> { 3 };
			Assert.Single(collection);

	9 - IsType/IsNotType : Test sürecinde gelen değerin türüne göre kontrol sağlayan metotlardır.
		9.1 =	Assert.IsType<int>(result);
			Assert.IsNotType<string>(result);

	10 - IsAssignableFrom :	Test sürecinde gelen değerin hangi türden türediğini kontrol eden metottur.
		10.1 = Assert.IsAssignableFrom<object>(result);
			//ya da
			var collection = new List<object>();
			Assert.IsAssignableFrom<IEnumerable<object>>(collection);

	11 - Null/NotNull : Test sürecinde gelen değerin null olup olmama durumunu kontrol eden metotlardır.
		11.1 = Assert.Null(result);
			Assert.NotNull(result);


9 - Parametre alan methodlar 'Theory' ile isaretleniyor ve  'InlineData(3,6,7)' seklinde parametreleri veriyoruz.

*3 - Parametreli Ornek "InlineData";
[Theory]
[InlineData(3, 5, 8)]
[InlineData(11, 5, 16)]
[InlineData(23, 2, 25)]
[InlineData(33, 44, 87)]
public void SumTest(int number1, int number2, int expected)
{
    #region Arrange
    Mathematics mathematics = new Mathematics();
    #endregion
    #region Act
    int result = mathematics.Sum(number1, number2);
    #endregion
    #region Assert
    Assert.Equal(expected, result);
    #endregion
}

*4 - Parametreli Ornek "MemberData" Ayni siniftayken;
public static IEnumerable<object[]> sumDatas => new List<object[]> {
    new object[]{ 3, 5, 8 },
    new object[]{ 11, 5, 16 },
    new object[]{ 23, 2, 25 },
    new object[]{ 33, 44, 87 }
};
 
[Theory]
[MemberData(nameof(sumDatas))]
public void SumTest(int number1, int number2, int expected)
{
    #region Arrange
    Mathematics mathematics = new Mathematics();
    #endregion
    #region Act
    int result = mathematics.Sum(number1, number2);
    #endregion
    #region Assert
    Assert.Equal(expected, result);
    #endregion
}
**4.1 = ‘MemberData’ attribute’u ile kullanılacak member türü IEnumerable<object[]> ve static olmak zorundadır.

*5 - Parametreli Ornek "MemberData" Farkli siniftayken;

public class Datas
{
    public static IEnumerable<object[]> sumDatas => new List<object[]> {
        new object[]{ 3, 5, 8 },
        new object[]{ 11, 5, 16 },
        new object[]{ 23, 2, 25 },
        new object[]{ 33, 44, 87 }
    };
}
public class MathematicsTest
{
    [Theory]
    [MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas))]
    public void SumTest(int number1, int number2, int expected)
    {
        #region Arrange
        Mathematics mathematics = new Mathematics();
        #endregion
        #region Act
        int result = mathematics.Sum(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
}

**5.1 = Her data icin farkli sonuc gormek istemiyorsak.
	[MemberData(nameof(Datas.sumDatas), MemberType = typeof(Datas), DisableDiscoveryEnumeration = true)]


*6 - "ClassData" kullanarak "Object" turunde data tanimlamak
public class Datas : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 3, 5, 8 };
        yield return new object[] { 11, 5, 16 };
        yield return new object[] { 23, 2, 25 };
        yield return new object[] { 33, 44, 87 };
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
public class MathematicsTest
{
    [Theory]
    [ClassData(typeof(Datas))]
    public void SumTest(int number1, int number2, int expected)
    {
        #region Arrange
        Mathematics mathematics = new Mathematics();
        #endregion
        #region Act
        int result = mathematics.Sum(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
}


*7 - "ClassData" kullanarak "Istedigimiz" turde data tanimlamak icin TheoryData<n,n,n> seklinde implemente edilecek interfaceyi veriyoruz.

public class TypeSafeData : TheoryData<int, int, int>
{
    public TypeSafeData()
    {
        Add(3, 5, 8);
        Add(11, 5, 16);
        Add(23, 2, 25);
        Add(33, 44, 87);
    }
}
public class MathematicsTest
{
    [Theory]
    [ClassData(typeof(TypeSafeData))]
    public void SumTest(int number1, int number2, int expected)
    {
        #region Arrange
        Mathematics mathematics = new Mathematics();
        #endregion
        #region Act
        int result = mathematics.Sum(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
}

10 - Her birim icin bir nesne ornegi ureterek xUnit.Net islemleri yapmaktadir.
     Bunun maliyetini azaltmak icin ise Test sinifimizi IClassFixture<TestEdilecekSinif> seklinde interfaceden
     implemente etmeliyiz.

*8 public class MathematicsTest : IClassFixture<Mathematics>
{
    Mathematics _mathematics;
    public MathematicsTest(Mathematics mathematics)
    {
        _mathematics = mathematics;
    }
    [Theory]
    [ClassData(typeof(TypeSafeData))]
    public void SumTest(int number1, int number2, int expected)
    {
        Task.Delay(5000).Wait();
        #region Act
        int result = _mathematics.Sum(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
    [Fact]
    public void SubtractTest()
    {
        Task.Delay(5000).Wait();
        #region Arrange
        int number1 = 10;
        int number2 = 20;
        int expected = -10;
        #endregion
        #region Act
        int result = _mathematics.Subtract(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
    [Theory, InlineData(3, 5)]
    public void MultiplyTest(int number1, int number2)
    {
        Task.Delay(5000).Wait();
        #region Act
        int result = _mathematics.Multiply(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(15, result);
        #endregion
    }
    [Theory, InlineData(30, 5, 6)]
    public void DivideTest(int number1, int number2, int expected)
    {
        Task.Delay(5000).Wait();
        #region Act
        int result = _mathematics.Divide(number1, number2);
        #endregion
        #region Assert
        Assert.Equal(expected, result);
        #endregion
    }
}

11 - Islemlerin hepsini ayni anda test etmek icin ise hepsini ayri bir sinifta test etmeliyiz.

12 - Moq Framework = Test edilmek istenilen sınıfların gerçek nesnelerini kullanmak yerine onları simüle etmemizi sağlayan
			   ve böylece test süreçlerindeki maliyetleri minimize etmemizi hedefleyen bir framework’tür. Bu isleme Mocking denir.

*9 Mocking islemi;

public class MathematicsTest
{
    [Fact]
    public void SumTest()
    {
        var mathematics = new Mock<IMathematics>();
        mathematics.Setup(m => m.Sum(1, 2))
            .Returns(3);
        int result = mathematics.Object.Sum(1, 2);
 
        Assert.Equal(3, result);
    }
}

13 - Verify Bir metodun kaç kez çalıştığını test edebilmek için kullanılan metottur.

*10 Verify Ornegimiz;

public class MathematicsTest
{
    [Fact]
    public void SumTest()
    {
        var mathematics = new Mock<IMathematics>();
        mathematics.Setup(m => m.Sum(1, 2))
            .Returns(3);
        int result = mathematics.Object.Sum(1, 2);
 
        Assert.Equal(3, result);
 
        mathematics.Verify(x => x.Sum(1, 2), Times.AtLeast(2));
    }
}

**10 - Yukarıdaki kod bloğunu incelerseniz eğer 13. satırda ‘Sum’ metodunun
iki kere çalıştırılması durumunda testten geçeceği bildirilmiştir.


14 - Throws Bir metodun fırlattığı exception’ı test edebilmemizi sağlayan metottur.

*11 - 
public class MathematicsTest
{
    [Fact]
    public void DivideTest()
    {
        Mathematics mathematics = new Mathematics();
        var mathematicsMock = new Mock<IMathematics>();
        mathematicsMock.Setup(m => m.Divide(1, 0))
            .Throws<DivideByZeroException>();
 
        var exception = Assert.Throws<DivideByZeroException>(() => mathematics.Divide(1, 0));
    }
}








