import React, { useState } from 'react'

export const FavoritesPage = ({favorites}) => {
 // const [count,setCount] = useState(0)

  return (
    <div> 
      {favorites.map(favorite => (
       <div key={favorite.id} className="movie-card"> 
          <h3>{favorite.title}</h3>
          <p >{favorite.categoria}</p> 
          {favorite.img && <img src={favorite.img} alt={favorite.title} />}
      </div>
      ))}

    </div>
  )
}

