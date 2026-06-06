//import React, { useState } from 'react'
import React from "react";
//import '../pages/FavoritesPage.css'
import "../components/MovieCard.css";
import { useTheme } from "../components/ThemeContext";

export const FavoritesPage = ({ favorites, removeFavorite }) => {
  const { darkMode } = useTheme();

  return (
    <div className="movies-container">
      {favorites.map((movie) => (
        <div className="card" key={movie.id}>
          <div className="card__content" style={{background: darkMode ? "#2b2b35" : "white",color: darkMode ? "white" : "black",}}>
            <div className="card__image">
              <img src={movie.img} alt={movie.title} />
            </div>

            <div className="card__text">
              <h3 className="card__badge">{movie.title}</h3>
              <p className="card__category">🎬 {movie.category}</p>
              <p
                className="card__description"
                style={{ color: darkMode ? "white" : "black" }}
              >
                {movie.description}
              </p>
              <p className="card__rating">⭐ {movie.qualification}</p>
            </div>

            <div
              className="card__button"
              onClick={() => removeFavorite(movie.id)}
            >
              <svg height="16" width="16" viewBox="0 0 24 24">
                <path
                  strokeWidth="2"
                  stroke="currentColor"
                  d="M4 12H20"
                  fill="currentColor"
                />
              </svg>
            </div>
          </div>
        </div>
      ))}
    </div>
  );
};
