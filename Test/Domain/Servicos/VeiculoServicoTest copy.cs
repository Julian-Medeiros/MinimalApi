using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoServicoTest
{
    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettingsTest.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
        var Configuration = builder.Build();

        var connectionString = Configuration.GetConnectionString("SqlServer");

        var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DbContexto(optionsBuilder.Options);
    }

    [TestMethod]
    public void TestCreateVeiculo()
    {
        // Arrange = criar as variáveis
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();
        veiculo.Marca = "Ford";
        veiculo.Modelo = "Fusion";
        veiculo.Ano = 2020;

        var veiculoServico = new VeiculoServico(context);

        // Act
        veiculoServico.Create(veiculo);

        // Assert
        Assert.AreEqual(1, veiculoServico.GetAll().Count());
        Assert.AreEqual("Ford", veiculo.Marca);
        Assert.AreEqual("Fusion", veiculo.Modelo);
        Assert.AreEqual(2020, veiculo.Ano);
    }

    [TestMethod]
    public void TestGetByIdAdministrador()
    {
        // Arrange = criar as variáveis
        var context = CriarContextoDeTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act
        administradorServico.Create(adm);
        var GetByIdAdmNoBanco = administradorServico.GetById(adm.Id);

        // Assert
        Assert.AreEqual(1, GetByIdAdmNoBanco.Id);
    }
}
