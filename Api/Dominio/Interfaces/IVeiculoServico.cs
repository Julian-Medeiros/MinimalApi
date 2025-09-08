using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IVeiculoServico
{
    Veiculo? GetById(int id);
    List<Veiculo> GetAll(int? pagina = 1, string? marca = null, string? modelo = null);
    void Create(Veiculo veiculo);
    void Update(Veiculo veiculo);
    void Delete(Veiculo veiculo);
}