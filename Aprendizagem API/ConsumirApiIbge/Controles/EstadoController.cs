using System.Text.Json;

public class EstadoControle
{
    public static async Task GetEstados()
    {
        string apiUrl = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";

        using HttpClient client = new HttpClient();
        try
        {
            Console.WriteLine("Consumindo API do IBGE...");

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            List<Estado> estados = new List<Estado>(); // Inicializa a lista vazia

            estados = JsonSerializer.Deserialize<List<Estado>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var estado in estados)
            {
                Console.WriteLine($"ID: {estado.Id}, Nome: {estado.Nome}, Sigla: {estado.Sigla}, \nId Região: {estado.Regiao.Id} Sigla Região: {estado.Regiao.Sigla} Nome Região: {estado.Regiao.Nome}");
                System.Console.WriteLine("\n\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
        }
    }

    public static async Task GetEstadoId(int id)
    {
        string apiUrl = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{id}";

        using HttpClient client = new HttpClient();
        try
        {
            Console.WriteLine("Consumindo API do IBGE...");

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            string jsonResponse = await response.Content.ReadAsStringAsync();

            Estado estado = new Estado(); // Inicializa a lista vazia

            estado = JsonSerializer.Deserialize<Estado>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine($"ID: {estado.Id}, Nome: {estado.Nome}, Sigla: {estado.Sigla}, \n Id: {estado.Regiao.Id} Sigla: {estado.Regiao.Sigla} Nome: {estado.Regiao.Nome}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
        }
    }
}