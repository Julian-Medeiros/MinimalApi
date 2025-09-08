using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.DTOs;

namespace Test.Mocks;

public class AdministradorServicoMock : IAdministradorServico
{
    private static List<Administrador> administradores = new List<Administrador>(){
        new Administrador{
            Id = 1,
            Email = "adm@teste.com",
            Senha = "123456",
            Perfil = "Adm"
        },
        new Administrador{
            Id = 2,
            Email = "editor@teste.com",
            Senha = "123456",
            Perfil = "Editor"
        }
    };

    public Administrador? GetById(int id)
    {
        return administradores.Find(adm => adm.Id == id);
    }

    public void Create(Administrador administrador)
    {
        administrador.Id = administradores.Count() + 1;
        administradores.Add(administrador);
    }

    public void Update(Administrador administrador)
    {
        var existing = administradores.Find(adm => adm.Id == administrador.Id);
        if (existing != null)
        {
            existing.Email = administrador.Email;
            existing.Senha = administrador.Senha;
            existing.Perfil = administrador.Perfil;
        }
    }

    public void Delete(Administrador administrador)
    {
        administradores.RemoveAll(adms => adms.Id == administrador.Id);  
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return administradores.Find(adm => adm.Email == loginDTO.Email && adm.Senha == loginDTO.Senha);
    }

    public List<Administrador> Todos(int? pagina)
    {
        return administradores;
    }

    public List<Administrador> GetAll(int? pagina, string? filtro)
    {
        if (string.IsNullOrEmpty(filtro))
            return administradores;
        return administradores.Where(adm => adm.Email.Contains(filtro) || adm.Perfil.Contains(filtro)).ToList();
    }
}