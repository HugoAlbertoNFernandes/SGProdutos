using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SGP.AplicationCore.Entity;

namespace SGP.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Inicializer(SgcContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clientes.Any())
            {
                return;
            }
            
            var clientes = new Cliente [] {
                new Cliente
                {
                    Nome = "Administrador",
                    Email = "adm@hotmail.com",
                    Senha = "1234"
                 }
            };
            context.AddRange(clientes);
            context.SaveChanges();

            var categorias = new Categoria[]
            {
                new Categoria
                {
                    Descricao="alimento"
                },
                new Categoria
                {
                    Descricao="bebida"
                },
                new Categoria
                {
                    Descricao="outros"
                }
            };
            context.AddRange(categorias);
            context.SaveChanges();

            var prod = new Produto[] {
                new Produto
                {
                    Nome="Arroz",
                    Preco=Convert.ToDecimal("18.00"),
                    CategoriaId=1
                },new Produto
                {
                    Nome="Coca-Cola",
                    Preco=Convert.ToDecimal("8.00"),
                    CategoriaId=2
                },new Produto
                {
                    Nome="Tapoer",
                    Preco=Convert.ToDecimal("10.00"),
                    CategoriaId=3
                }
            };
            context.AddRange(prod);
            context.SaveChanges();
        }
    }
}
