using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public void Create(Veiculo veiculo)
        {            
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public Veiculo? GetById(int id)
        {
            return _contexto.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();
        }

        public List<Veiculo> GetAll(int? pagina = 1, string? marca = null, string? modelo = null)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(marca))
            {
                query = query.Where(veiculo => EF.Functions.Like(veiculo.Marca.ToUpper(), $"%{marca.ToUpper()}%"));
            }

            int itensPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip((pagina.Value - 1) * itensPorPagina).Take(itensPorPagina);
            }
            return query.ToList();
        }

        public void Update(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();

        }
        public void Delete(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();
        }
    }
}