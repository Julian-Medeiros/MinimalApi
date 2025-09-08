using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.DTOs;

namespace MinimalApi.Dominio.Interfaces;

public interface IAdministradorServico
{
    Administrador? Login(LoginDTO loginDTO);

    Administrador? GetById(int id);
    List<Administrador> GetAll(int? pagina = 1, string? email = null);
    void Create(Administrador administrador);
    void Update(Administrador administrador);
}