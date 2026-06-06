import React from 'react'
import '../components/Valoration.css'

export const Valoration = ({movieId,onRate} ) => {
  const handleRate = (stars) => {
    onRate({
      movieId,
      stars
    });
  };

  return (
    <div>
<div className="rating">
  <input value="5" className="rating" id={`star5-${movieId}`} type="radio" onChange={() => handleRate(5)} /> 
  <label htmlFor={`star5-${movieId}`}></label>
  <input value="4" className="rating" id={`star4-${movieId}`} type="radio" onChange={() => handleRate(4)} /> 
  <label htmlFor={`star4-${movieId}`}></label>
  <input value="3" className="rating" id={`star3-${movieId}`} type="radio" onChange={() => handleRate(3)} /> 
  <label htmlFor={`star3-${movieId}`}></label>
  <input value="2" className="rating" id={`star2-${movieId}`} type="radio" onChange={() => handleRate(2)} /> 
  <label htmlFor={`star2-${movieId}`}></label>
  <input value="1" className="rating" id={`star1-${movieId}`} type="radio" onChange={() => handleRate(1)} /> 
  <label htmlFor={`star1-${movieId}`}></label>
</div>

    </div>
  )
}

