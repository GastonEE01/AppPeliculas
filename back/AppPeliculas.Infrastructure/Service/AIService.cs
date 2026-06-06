using AppPeliculas.Application.Interfaces;
using AppPeliculas.Infrastructure.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppPeliculas.Infrastructure.Service
{
    using AppPeliculas.Application.UseCase;
    using AppPeliculas.Domain.Entities;
    using AppPeliculas.Infrastructure.Repositories;
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class AIService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IMovieIRepository _movieIRepository;

        public AIService(HttpClient httpClient, IConfiguration config, IMovieIRepository movieIRepository)
        {
            _httpClient = httpClient;
            _apiKey = config["Gemini:ApiKey"];
            _movieIRepository = movieIRepository;
        }


        public async Task<string> GetRecommendations(string prompt)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_apiKey}";
            var body = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        }
            };

            var response = await _httpClient.PostAsJsonAsync(url, body);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Gemini error: {json}");

            var doc = JsonDocument.Parse(json);

            var text = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text;
        }

        public async Task<string> GetRecommendations(User user,string prompt)
        {
            var movies = _movieIRepository.GetMovies();

            string favorites = string.Join(", ",
                user.FavoriteMovies.Select(f => f.Movie.Title));

            string availableMovies = string.Join("\n", movies.Select(m =>
                                             $"{m.Title} - {m.Category}"));

            string finalPromt = $@"El usuario se llama {user.Name}.
                Sus peliculas favoritas son {favorites}.
                Pregunta del usuario: {prompt}
                Recomendale peliculas basandote en sus gustos o en base a lo que te pregunta,si el usuario no tiene alguna pelicula favorita,recomendale las peliculas de la base de datos {availableMovies}";
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={_apiKey}";
            var body = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new { text = finalPromt }
                }
            }
        }
            };

            var response = await _httpClient.PostAsJsonAsync(url, body);

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Gemini error: {json}");

            var doc = JsonDocument.Parse(json);

            var text = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            return text;
        }

    }

}
