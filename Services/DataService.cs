using Exercicio2.Models;
using Exercicio2.Services.Interface;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;
using System.Text;
using System.Text.Json;

namespace Exercicio2.Services
{
    public class DataService : IDataService
    {
        private Data datas;
        private IEnumerable<Data> datasList;

        public DataService()
        {
        }

        public async Task<IEnumerable<Data>> GetAll()
        {
            string apiUrl = "https://ff9920b4-766e-4568-bf72-66331605dc30.mock.pstmn.io/teste/api/articles?page";
            List<Data> articlesWithData = new List<Data>();
            int currentPage = 1;

            while (true && !articlesWithData.Any(a => !string.IsNullOrEmpty(a.url)))
            {
                var artigos = await GetDataFromApi(apiUrl, currentPage);

                // Filtrar e adicionar apenas os artigos com datas
                articlesWithData.AddRange(artigos.Data.FindAll(a => !string.IsNullOrEmpty(a.url)));
                currentPage++;
            }

            return articlesWithData;
        }

        static async Task<Artigos> GetDataFromApi(string apiUrl, int page)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construa a URL para a página desejada
                string requestUrl = $"{apiUrl}?page={page}";

                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Artigos data = JsonConvert.DeserializeObject<Artigos>(content);
                    return data;
                }
                else
                {
                    // Trate erros aqui
                    Console.WriteLine($"Erro ao recuperar dados da página {page}: {response.StatusCode}");
                    return null;
                }
            }
        }

    }
}
