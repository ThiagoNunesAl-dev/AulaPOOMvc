using System;
using System.Collections.Generic;
using AulaPOOMvc.Model;

namespace AulaPOOMvc.Views
{
    public class ProdutoViews
    {
        public void MostrarNoConsole (List<Produto> produtos) {
            foreach (Produto p in produtos)
            {
                Console.WriteLine($"R$ {p.Preco} - {p.Nome}");
            }
        }
    }
}