using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.DTOs;

namespace Test.Mocks;

public class VeiculoServicoMock : IVeiculoServico
{
    private static List<Veiculo> veiculos = new List<Veiculo>()
    {
        new Veiculo { Id = 1, Marca = "Carro A", Modelo = "Marca X", Ano = 2020 },
        new Veiculo { Id = 2, Marca = "Carro B", Modelo = "Marca Y", Ano = 2021 }
    };

    public Veiculo? GetById(int id)
    {
        return veiculos.Find(veiculo => veiculo.Id == id);
    }

    public List<Veiculo> GetAll(int? pagina, string? filtro, string? ordenacao)
    {
        IEnumerable<Veiculo> query = veiculos;
        if (!string.IsNullOrEmpty(filtro))
        {
            query = query.Where(veiculo => veiculo.Marca.Contains(filtro) || veiculo.Modelo.Contains(filtro));
        }
        return query.ToList();
    }

    public void Create(Veiculo veiculo)
    {
        veiculos.Add(veiculo);
    }

    public void Update(Veiculo veiculo)
    {
        var veiculoBanco = veiculos.Find(v => v.Id == veiculo.Id);
        if (veiculoBanco != null)
        {
            veiculoBanco.Marca = veiculo.Marca;
            veiculoBanco.Modelo = veiculo.Modelo;
            veiculoBanco.Ano = veiculo.Ano;
        }
    }

    public void Delete(Veiculo veiculo)
    {
        veiculos.RemoveAll(v => v.Id == veiculo.Id);
    }
}