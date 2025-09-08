using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestGetSetProp()
    {
        // Arrange = criar as variáveis
        var veiculo = new Veiculo();

        // Act
        veiculo.Id = 1;
        veiculo.Marca = "Teste";
        veiculo.Modelo = "Testinson";
        veiculo.Ano = 2018;

        // Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Teste", veiculo.Marca);
        Assert.AreEqual("Testinson", veiculo.Modelo);
        Assert.AreEqual(2018, veiculo.Ano);

    }
}
