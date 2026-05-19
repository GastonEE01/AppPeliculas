import React, { useEffect, useState } from 'react'
import { MovieCard } from '../components/MovieCard'
import { useTheme } from '../components/ThemeContext'
import '../../App.css'
export const MoviesPage = ({movies,addMovie,deleteMovie,addFavorite,favorites,handleSearch,searchText}) => {

    const { darkMode, toggleTheme } = useTheme()
  
    const [modal,setModal] = useState(false)//onClick={() => {addMovie(movies)}}
    
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

    const[message,setMessage] = useState("")
    
    return (
    <div className={darkMode ? 'dark' : 'light'}>
        <h2>Peliculas</h2>
        <button className="button" >Agregar peliculas</button>
            <form action="" onSubmit={ (e) => {
                 e.preventDefault()
                 const peliculasExistente = movies.some(
                  (movie) => movie.title.toLowerCase() === form.title.toLocaleLowerCase()
                 )
                 if(peliculasExistente){
                  setMessage ("Esta pelicula ya existe")
                  setTimeout(() => {
                    setMessage("")
                  },3000)
                  return 
                 }
                 addMovie({...form,id: count})
                 setForm({ title: '', categoria: '', img: '' })
                 setCount(count + 1)
                 setMessage("")
            }}>
            <input className="input" onChange={saveInput} name= "title" type="text"  placeholder='Ingrese el titulo '/>
            <input className="input" onChange={saveInput} name= "categoria" type="text"  placeholder='Ingrese la categoria '/>
            <input className="input" onChange={saveInput} name="img" type="text"  placeholder='ponga la img en formato URL de la pelicula'/>
            <button className="button" type='submit'>Agregar</button>
            <h2>{message}</h2>
            </form>
            <input  className="input" type="text" placeholder='Ingrese el nombre de una pelicula' onChange={handleSearch}  values={searchText}/>
      
      <MovieCard movies= {movies} deleteMovie = {deleteMovie} addFavorite = {addFavorite} favorites = {favorites} ></MovieCard>
    </div>
  )
}

