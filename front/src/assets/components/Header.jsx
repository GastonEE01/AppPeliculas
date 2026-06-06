import { useState } from "react";
import { Link } from "react-router-dom";
import { ButtonTheme } from "./UIX/ButtonTheme";
import "../components/Header.css";
import { Modal } from "./UIX/Modal";
import { BiSolidUserCircle } from "react-icons/bi";
import { FiLogOut } from "react-icons/fi";
//deleteMovie,addFavorite,favorites
export const Header = ({
  darkMode,
  toggleTheme,
  movies,
  addMovie,
  handleSearch,
  searchText,
  user,
}) => {
  console.log(user);
  const [modal, setModal] = useState(false); //onClick={() => {addMovie(movies)}}

  return (
    <header> 
  <h1 className="Title">App de Películas</h1>

      <div className="navbar-Link">
        <Link  style={{ background: darkMode ? '#2b2b35' : 'white', color: darkMode ? 'white' : 'black' }} to="/favorites">Favoritas</Link>
        <Link  style={{ background: darkMode ? '#2b2b35' : 'white', color: darkMode ? 'white' : 'black' }} to="/movies">Peliculas</Link>

        <ButtonTheme darkMode={darkMode} toggleTheme={toggleTheme} />

        <div className="user-info">
          {
            user?.imgUrl ? (
              <img src={user.imgUrl} alt="Avatar" className="avatar" />
            ) : (
              <BiSolidUserCircle size={40}  color={darkMode ? "white" : "black"} />
            )
          }
         <span>{user?.email}</span>
        </div>
        <FiLogOut size={30} color={darkMode ? "white" : "black"} className="logout-icon" onClick={() => {
          localStorage.removeItem("token");
        window.location.href = "/login";
      }} />
      </div>

  
    </header>
  );
};
/* <button className="button" onClick={() => setModal(true)}>
          Agregar peliculas
        </button>
        <Modal
          movies={movies}
          addMovie={addMovie}
          handleSearch={handleSearch}
          searchText={searchText}
          isOpen={modal}
          onClose={() => setModal(false)}
        />*/