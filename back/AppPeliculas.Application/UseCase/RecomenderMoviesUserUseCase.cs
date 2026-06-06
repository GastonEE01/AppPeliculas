using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class RecomenderMoviesUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAIService _iaService;

        public RecomenderMoviesUserUseCase(IAIService iaService, IUserRepository userRepository)
        {
            _iaService = iaService;
            _userRepository = userRepository;
        }

        public async Task<string> ResponseAI(Guid idUser,string menssage)
        {
            User searchUser = _userRepository.GetByIdWithFavorites(idUser);
            if (searchUser == null)
                throw new Exception("Usuarion no encontrado");

            return await _iaService.GetRecommendations(searchUser, menssage);
        }
    }
}
