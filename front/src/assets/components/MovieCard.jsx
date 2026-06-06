import React, { useState } from 'react'
import '../components/MovieCard.css'
import {Valoration} from '../components/Valoration' 
import { useTheme } from '../components/ThemeContext'

export const MovieCard = ({movies,deleteMovie,addFavorite,favorites,addMovieRating, message}) => {
  const { darkMode } = useTheme();

  const [menssageFavorite,setMenssageFavorite] = useState("")

  const menssage = async (movieId) => {
    const movieToAdd = movies.find(m => m.id === movieId);

    try {
      await addFavorite(movieToAdd);

      setMenssageFavorite("Agregado a favoritos");
    } catch (error) {
      setMenssageFavorite(error.message);
    }

    setTimeout(() => {
      setMenssageFavorite("");
    }, 3000);
  };
/*
const menssage = async (movieId) => {
  const movieToAdd = movies.find(m => m.id === movieId)

  try {
    await addFavorite(movieToAdd)

    setMenssageFavorite("Agregado a favoritos")
  } catch (error) {
    setMenssageFavorite(error.message)
  }

  setTimeout(() => {
    setMenssageFavorite("")
  }, 3000)
}*/
/*
const addMovieRating = async (ratingData) => {
  try {
    await addMovieRatingApi(ratingData);

    setMessage("Valoración guardada");
  } catch (error) {
    setMessage("Error al guardar valoración");
  }

  setTimeout(() => {
    setMessage("");
  }, 3000);
};*/
  return (
    
      <div className="movies-container">
  {movies.map((movie) => (
    <>
  <div className="card" key={movie.id}>
  <div key={movie.id} className="card__shine"></div>
  <div className="card__glow"></div>
  <div className="card__content" style={{ background: darkMode ? '#2b2b35' : 'white', color: darkMode ? 'white' : 'black' }}>
    <div className="card__badge">{movie.title}</div>
    <div  className="card__image">
      {movie.img && <img src={movie.img} alt={movie.title} />}
    </div>
    <div className="card__text">
      <p className="card__title" style={{ color: darkMode ? 'white' : 'black' }}>
        {movie.title}
      </p>
      <p className="card__category">🎬 {movie.category}</p>
        <p className="card__description" style={{ color: darkMode ? 'white' : 'black' }}>
          {movie.description}
        </p>
      <p className="card__rating">⭐ {movie.qualification}</p>
    </div>
    <div className="card__footer">
      <Valoration  movieId={movie.id} onRate={addMovieRating}></Valoration>
      <div className="card__button" onClick={() => menssage(movie.id)}>
        <svg height="16" width="16" viewBox="0 0 24 24">  
          <path
            strokeWidth="2"
            stroke="currentColor"
            d="M4 12H20M12 4V20"
            fill="currentColor"
          ></path>
        </svg>
      </div>
    </div>
  </div>
  </div>
  </>

))}
{(menssageFavorite || message) && (
  <div className="toast">
    {menssageFavorite || message}
  </div>
)}
</div>
  )
}
  

/*
    <div>
<div className="card">
  {movies.map((movie) => (
    <>
  <div key={movie.id} className="card__shine"></div>
  <div className="card__glow"></div>
  <div className="card__content">
    <div className="card__badge">NEaaaaaaaaW</div>
    <div  className="card__image">
      {movie.img && <img src={movie.img} alt={movie.title} />}
    </div>
    <div className="card__text">
      <p className="card__title">{movie.title}</p>
      <p className="card__description">{movie.categoria}</p>
      <p className="card__description">{movie.descripcion}</p>
    </div>
    <div className="card__footer">
      <Valoration></Valoration>
      <div className="card__button" >
        <svg height="16" width="16" viewBox="0 0 24 24">  
          <path
           onClick= {() => menssage(movie.id)}
            strokeWidth="2"
            stroke="currentColor"
            d="M4 12H20M12 4V20"
            fill="currentColor"
          ></path>
        </svg>
      </div>
    </div>
  </div>
  </>

))}
{menssageFavorite && <h3>{menssageFavorite}</h3>}
</div>
</div>
*/
 