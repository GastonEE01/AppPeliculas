import { BrowserRouter,Route,Routes,Link } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { FavoritesPage } from './assets/pages/FavoritesPage'
import './App.css'
import { MoviesPage } from './assets/pages/MoviesPage'
import { useTheme } from './assets/components/ThemeContext'
/*const movies = [
  { id: 1,title: 'Intelestellar',categoria: 'Ciencia ficcion', img: ''},
  { id: 2,title: 'Stars Wars',categoria: 'Ciencia ficcion', img: ''},
  { id: 3,title: 'Blade Runner',categoria: 'Ciencia ficcion', img: ''},
    
  { id: 4,title: 'Que paso ayer',categoria: 'Comedia', img: ''},
  { id: 5,title: 'Supercool',categoria: 'Comedia', img: ''},
  { id: 6,title: "American Pie",categoria: "Comedia", img: ''},

  { id: 7,title: 'It',categoria: 'Ciencia ficcion', img:''},
  { id: 8,title: 'El conjuro',categoria: 'Ciencia ficcion', img: ''},
  { id: 9,title: 'Posecion infernal',categoria: 'Ciencia ficcion', img: ''},

  { id: 10,title: 'Memoria infinita',categoria: 'Documentales', img: ''},
  { id: 11,title: 'Free solo',categoria: 'Documentales', img: ''},
  { id: 11,title: 'La vecina perfecta',categoria: 'Documentales', img: ''},

]*/

function App() {

  const { darkMode, toggleTheme } = useTheme()

  useEffect(() => {
  document.body.className = darkMode ? 'dark' : 'light'
}, [darkMode])

  // Peliculas
  const [movies, setMovies] = useState(() => {
    const savedMovie = localStorage.getItem('movies')
    return savedMovie ? JSON.parse(savedMovie) : []
  }) 

  useEffect(() => {
    localStorage.setItem('movies', JSON.stringify(movies))
  })

  const addMovie = (newMovie) => {
    setMovies([...movies,newMovie])

  }
  
  const deleteMovie = (movieId) => {
  setMovies(movies.filter((item) => item.id !== movieId)
  ),[]}

 // Favorito

 const [favorites,setFavorites] = useState(() => {
  const savedFavorites = localStorage.getItem('favorites')
  return savedFavorites ? JSON.parse(savedFavorites) : []
 })

 useEffect (() => {
  localStorage.setItem('favorites', JSON.stringify(favorites))
 })

 const addFavorite = (newFavorite) => { // newFavorite es un OBJETO, no un ID
  setFavorites([...favorites,newFavorite])
 }

 const [searchText, setSearchText] = useState("")

 const filteredMovies = movies.filter((movie) => 
  movie.title.toLowerCase().includes(searchText.toLowerCase())
)
const handleSearch = (e) => {
  setSearchText(e.target.value)
}

  return (
    <>
    <div className={darkMode ? 'dark' : 'light'}>
     <BrowserRouter>
    <header className={darkMode ? 'dark' : 'light'}>
      <h1 >app de peliculas</h1>
      <div className="navbar-Link">
      <Link  to="/favorites">Favoritas</Link>
      <Link to="/movies">Peliculas</Link>
      <button className="button" onClick={toggleTheme}>{darkMode ? 'Modo Claro' : 'Modo Oscuro'}</button>
      </div>
    </header>
     
    {/* RUTAS */}
      <Routes>
        <Route path="/movies" element={<MoviesPage movies={filteredMovies} addMovie= {addMovie} deleteMovie= {deleteMovie} addFavorite = {addFavorite} favorites= {favorites} handleSearch = {handleSearch} searchText = {searchText}/>}></Route>
        <Route path="/favorites" element={<FavoritesPage favorites = {favorites} />} />
      </Routes>
    </BrowserRouter>
    </div>
    </>
    
  )
}

export default App
