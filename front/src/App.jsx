import { BrowserRouter,Route,Routes,Link,Navigate} from 'react-router-dom'
import './App.css'
import { useEffect, useState } from 'react'
import { FavoritesPage } from './assets/pages/FavoritesPage'
import { MoviesPage } from './assets/pages/MoviesPage'
import { LoginPage } from './assets/pages/LoginPage'
import { RegisterPage } from './assets/pages/RegisterPage'
import { useTheme } from './assets/components/ThemeContext'
import { Header } from './assets/components/Header'
import { getMovies } from './assets/Services/api'
import { getMovieGetByID } from './assets/Services/api'
import { AddFavorite } from './assets/Services/api'
import { getCurrentUser } from "../src/assets/Services/api";
import { removeFavoriteMovie } from "../src/assets/Services/api";
import { addMovieRatingApi } from "../src/assets/Services/api";

function App() {

  const { darkMode, toggleTheme } = useTheme()

  useEffect(() => {
  document.body.className = darkMode ? 'dark' : 'light'
}, [darkMode])

const [user, setUser] = useState(null) // Estado para almacenar la información del usuario logueado
const [token, setToken] = useState(localStorage.getItem('token')) // Estado para almacenar el token de autenticación

useEffect(() => {
  if(token) {
    const loadUser = async () => {
      try{
        
        const userData = await getCurrentUser(token) // Función para obtener los datos del usuario usando el token
                console.log("USER DATA:", userData);

        setUser(userData)
      } catch (error) {
        console.error("Error al cargar los datos del usuario:", error)
      }
    }
    
    loadUser()
    
  }
}, [token])

  const [movies, setMovies] = useState([])

  useEffect(() => {
    const loadMovies = async () => {
      try {
        const moviesData = await getMovies()
        setMovies(moviesData)
      } catch (error) {
        console.error("Error al cargar las películas:", error)
      }
    }
  loadMovies()}, [])

  const [favorites, setFavorites] = useState([])

  useEffect(() => {
  if (!user) return

  const loadFavoriteMovies = async () => {
    try {
      const moviesData = await getMovieGetByID(user.id)
      setFavorites(moviesData)
    } catch (error) {
      console.error("Error al cargar las películas favoritas:", error)
    }
  }

  loadFavoriteMovies()
}, [user])

const removeFavorite = async (movieId) => {
  try{
    await removeFavoriteMovie(movieId)
      setFavorites(prev => prev.filter(movie => movie.id !== movieId))
  } catch (error) {
    console.error("Error al eliminar de favoritos:", error)
  }
}
  /*
  const addFavorite = async (movie) => {
    try {
      await AddFavorite(movie.id, user?.id)
      setFavorites([...favorites, movie])
    } catch (error) {
      console.error("Error al agregar a favoritos:", error)
    }
  }
 */
const addFavorite = async (movie) => {
  await AddFavorite(movie.id, user.id)

  setFavorites(prev => [...prev, movie])
}

  const addMovie = (newMovie) => {
    setMovies([...movies,newMovie])

  }
  
  const deleteMovie = (movieId) => {
  setMovies(movies.filter((item) => item.id !== movieId)
  ),[]}

  const [message, setMessage] = useState("");

const addMovieRating = async (ratingData) => {
  try {
    await addMovieRatingApi(ratingData);

    setMessage("Valoración guardada correctamente");

    setTimeout(() => {
      setMessage("");
    }, 3000);

  } catch (error) {

    setMessage("Error al guardar valoración");

    setTimeout(() => {
      setMessage("");
    }, 3000);

    console.error(error);
  }
};

 const [searchText, setSearchText] = useState("")
const handleSearch = (e) => {
  setSearchText(e.target.value)
}

  return (
    <>
    <div className={darkMode ? 'dark' : 'light'}>
     <BrowserRouter>
    
     
    {/* RUTAS */}
      <Routes>
         <Route path="/login" element={<LoginPage /*movies={filteredMovies} addMovie= {addMovie} deleteMovie= {deleteMovie} addFavorite = {addFavorite} favorites= {favorites} handleSearch = {handleSearch} searchText = {searchText}*//>}></Route>
        <Route path="/register" element={<RegisterPage /*movies={filteredMovies} addMovie= {addMovie} deleteMovie= {deleteMovie} addFavorite = {addFavorite} favorites= {favorites} handleSearch = {handleSearch} searchText = {searchText}*//>}></Route>
        
        <Route path="/movies" element={
          <>
              <Header darkMode={darkMode} toggleTheme={toggleTheme} movies={movies} addMovie={addMovie} handleSearch={handleSearch} searchText={searchText}  user={user} />
              <MoviesPage movies={movies} addMovie= {addMovie} deleteMovie= {deleteMovie} addFavorite = {addFavorite} favorites= {favorites} handleSearch = {handleSearch} searchText = {searchText} addMovieRating = {addMovieRating}  message={message}/>
          </>
        }/>
        
        <Route path="/favorites" element={
          <>
          <Header darkMode={darkMode} toggleTheme={toggleTheme} movies={movies} addMovie={addMovie} handleSearch={handleSearch} searchText={searchText} user={user} />
          <FavoritesPage favorites = {favorites} removeFavorite = {removeFavorite}/>
          </>
          } />
      </Routes>
    </BrowserRouter>
    </div>
    </>
    
  )
}

export default App
