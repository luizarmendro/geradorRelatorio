using GeradorRelatorios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

public class RelatorioController : Controller
{
    private readonly IConfiguration _configuration;

    public RelatorioController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult GerarRelatorio()
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        List<RelatorioModel> relatorioDados = new List<RelatorioModel>();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            // Exemplo de consulta SQL
            string query = "SELECT Coluna1, Coluna2, Coluna3 FROM MinhaTabela WHERE Condicao = @Condicao";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Condicao", "ValorCondicao");

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    RelatorioModel dado = new RelatorioModel
                    {
                        Coluna1 = reader["Coluna1"].ToString(),
                        Coluna2 = reader["Coluna2"].ToString(),
                        Coluna3 = reader["Coluna3"].ToString(),
                    };
                    relatorioDados.Add(dado);
                }
            }
        }

        // Passar os dados para a view ou gerar o relatório diretamente
        return View(relatorioDados); // ou gerar PDF, CSV, XLSX aqui
    }
}