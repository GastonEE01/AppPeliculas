import React, { useState } from 'react'
import '../components/MovieCard.css'

export const MovieCard = ({movies,deleteMovie,addFavorite,favorites}) => {
  const [menssageFavorite,setMenssageFavorite] = useState("")

  const menssage = (movieId) => {
    const movieToAdd = movies.find(m => m.id === movieId)
    const yaExiste = favorites.some(fav => fav.id === movieToAdd.id)
    if(yaExiste){
    setMenssageFavorite("Ya esta en favoritos")
    setTimeout(() => {
      setMenssageFavorite("")
    },3000)
    return
  }

  addFavorite(movieToAdd)
    setMenssageFavorite("Agregado a favoritos")
    setTimeout(() => {
      setMenssageFavorite("")
    },3000)
    return
  }
  return (
    <div className='movie-card'>
    <div className="movies-container">
      {movies.map((movie) => (
        <div key={movie.id} className="movie-card">
          <h3>{movie.title}</h3>
          <p >{movie.categoria}</p> 
          {movie.img && <img src={movie.img} alt={movie.title} />}
          <button className="button" name='buttonFavorite' onClick= {() => menssage(movie.id)}>
          <img src="../src/assets//img/estrella.png" alt="" width= "30px" height="30px"/>
          </button>

          <button className="button" onClick={() => {deleteMovie(movie.id)}}>Eliminar pelicula</button>
        </div>
      ))}
        {menssageFavorite && <h3>{menssageFavorite}</h3>}

    </div>
    </div>
  )
}

