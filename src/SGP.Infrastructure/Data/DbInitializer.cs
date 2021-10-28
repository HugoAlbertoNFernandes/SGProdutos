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
        }
    }
}
