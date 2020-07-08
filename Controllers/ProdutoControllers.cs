using System.Collections.Generic;
using AulaPOOMvc.Model;
using AulaPOOMvc.Views;

namespace AulaPOOMvc.Controllers
{
    public class ProdutoControllers
    {
        Produto prodModel = new Produto();
        ProdutoViews prodViews = new ProdutoViews();

        public void Listar () {
            List<Produto> lista = new List<Produto>();

            prodViews.MostrarNoConsole(lista);
        }

        public void Buscar (string termo) {
            List<Produto> lista = prodModel.Ler().FindAll(x => x.Preco == float.Parse(termo));

            prodViews.MostrarNoConsole(lista);
        }
    }
}