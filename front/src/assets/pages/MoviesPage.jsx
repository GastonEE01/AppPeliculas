import React, { useEffect, useState } from 'react'
import { MovieCard } from '../components/MovieCard'
import { ChatIa } from '../components/ChatIa'

import { useTheme } from '../components/ThemeContext'

import '../../App.css'
export const MoviesPage = ({movies,addMovie,deleteMovie,addFavorite,favorites,handleSearch,searchText,addMovieRating, message}) => {

    
    const { darkMode, toggleTheme } = useTheme()
  
  /*  const [modal,setModal] = useState(false)//onClick={() => {addMovie(movies)}}
    
    const [count,setCount] = useState(0)
    const [form,setForm] = useState({
        title: '',
        categoria: '',
        igm: ''
    })
    const saveInput = (e) => {
        const {name, value} = e.target
        setForm({...form,
        [name]: value
        })
    }
*/
    
    return (
    <div className={darkMode ? 'dark' : 'light'}>
       
      
           <MovieCard movies= {movies} deleteMovie = {deleteMovie} addFavorite = {addFavorite} favorites = {favorites} addMovieRating = {addMovieRating} message = {message}></MovieCard>
                      <ChatIa></ChatIa>
            
    </div>
  )
}

