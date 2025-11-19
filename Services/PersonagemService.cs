using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rpg-Blazor.Models.Enuns;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Rpg-Blazor.Services
{
    public class PersonagemService
    {
         private readonly HttpClient _http;


        public PersonagemService(HttpClient http)
        {

             _http = http;

        }

          
        public async Task<List<PersonagemViewModel>> GetAllAsync(string token)
        {
          _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" , token);

          var response = await _http.GetAllAsync("Personagens/GetALL");
          var responseContent = await response.Content.ReadAsStringAsync();
          List<PersonagemViewModel> lista = new List<PersonagemViewModel>();

          if (response.IsSucessStatusCode)
            {
                
                lista = JsonSerializer.Deserialize<List<PersonagemViewModel>>(responseContent , JsonSerializerOptions.Web);
                 return lista;

            }
          else
          {
            throw new Exception(responseContent);
          }



        }



    }
}