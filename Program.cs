using System;
using System.Collections.Generic;
using AulaPOOMvc.Controllers;
using AulaPOOMvc.Model;

namespace AulaPOOMvc
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "Gibson SG";
            p1.Preco = 4700f;
            p1.Inserir(p1);

            Produto p2 = new Produto();
            p2.Codigo = 2;
            p2.Nome = "Ibanez RG440V";
            p2.Preco = 5000f;
            p2.Inserir(p2);

            List<Produto> lista = new List<Produto>();
            lista = p1.Ler();

            ProdutoControllers produtos = new ProdutoControllers();
            produtos.Buscar("5000");

            foreach (Produto item in lista)
            {
                Console.WriteLine($"{item.Nome} - R$ {item.Preco}");
            }
        }
    }
}
