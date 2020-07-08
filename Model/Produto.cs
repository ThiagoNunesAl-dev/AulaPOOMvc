namespace AulaPOOMvc.Model
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string Path = "Database/Produto.csv";

        /// <summary>
        /// Cria uma pasta Produto.csv (conforme o caminho criado acima), se esta não existir.
        /// </summary>
        public Produto () {
            if (!File.Exists(Path)) {
                File.Create(Path).Close();
            }
        }

         /// <summary>
        /// Prepara uma linha no formato padrão csv.
        /// </summary>
        /// <param name="p">Produto já instanciado.</param>
        /// <returns>Uma estrutura no formato csv, com todas as informações relevantes do produto.</returns>
        public string PrepararLinhaCSV (Produto p) {
            return $"Código:{p.Codigo};Nome:{p.Nome};Preço:{p.Preco}";
        }

        /// <summary>
        /// Separa os dados.
        /// </summary>
        /// <param name="dado">Dado extraído.</param>
        /// <returns>Dados devidamente extraídos de acordo com o parâmetro dado na função "Split".</returns>
        public string Separar (string dado) {
            //Ex.:
            //dado => Código:1
            //dado[0] => Código
            //dado[1] => 1
            //Retorna o número do código, sem o enunciado.
            return dado.Split(":")[1];
        }

        /// <summary>
        /// Insere a linha criada e preenchida conforme o método acima no documento csv.
        /// </summary>
        /// <param name="p">Produto já instanciado.</param>
        public void Inserir (Produto p) {
            string[] linha = new string[] {PrepararLinhaCSV(p)};
            //Append acrescenta as linhas preparadas ao documento csv.
            File.AppendAllLines(Path, linha);
        }
        
        /// <summary>
        /// Lê a lista.
        /// </summary>
        /// <returns>Lista de produtos com nomes e preços.</returns>
        public List<Produto> Ler () {
            //Cria-se uma lista de produtos padrão.
            List<Produto> produtos = new List<Produto>();
            //Transforma-se as linhas criadas em um arranjo de strings.
            string[] linhas = File.ReadAllLines(Path);
            //O array é varrido.

            foreach (var linha in linhas)
            {
                //Os dados das linhas são separados.
                string[] dados = linha.Split(";");
                
                //Os dados agora são tratados para que possam ser colocados na lista.
                Produto prod = new Produto();
                prod.Codigo = Int32.Parse(Separar(dados[0]));
                prod.Nome = Separar(dados[1]);
                prod.Preco = float.Parse(Separar(dados[2]));

                //Os dados são inseridos na lista.
                produtos.Add(prod);
            }

            //Ordena a lista de acordo com o código.
            produtos = produtos.OrderBy(z => z.Codigo).ToList();

            return produtos;
        }
    }
}