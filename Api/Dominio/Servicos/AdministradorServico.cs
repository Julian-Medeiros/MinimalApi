using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Create(Administrador administrador)
        {            
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
        }

        public List<Administrador> GetAll(int? pagina = 1, string? email = null)
        {
            var query = _contexto.Administradores.AsQueryable();

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(administrador => EF.Functions.Like(administrador.Email.ToUpper(), $"%{email.ToUpper()}%"));
            }

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip((pagina.Value - 1) * itensPorPagina).Take(itensPorPagina);
            }
            return query.ToList();
        }

        public Administrador? GetById(int id)
        {
            return _contexto.Administradores.Where(administrador => administrador.Id == id).FirstOrDefault();
        }

        public void Update(Administrador administrador)
        {            
            _contexto.Administradores.Update(administrador);
            _contexto.SaveChanges();
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return _contexto.Administradores.Where
            (
                administrador => administrador.Email == loginDTO.Email && administrador.Senha == loginDTO.Senha
            )
            .FirstOrDefault();
        }

    }
}