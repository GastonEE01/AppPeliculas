const API_URL = import.meta.env.VITE_API_URL;

export const getMovieGetByID = async (userId) => {
   const token = localStorage.getItem("token");
   const res = await fetch(`${API_URL}/api/favoriteMovie/${userId}`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    },
  });
  const data = await res.json();
  if(!res.ok){
    throw new Error(data.message);
   }
      return data; 
}

export const getMovies = async () => {
   const res = await fetch(`${API_URL}/api/movie`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
  });
  const data = await res.json();
  if(!res.ok){
    throw new Error(data.message);
   }
    
   return data;
}

export const AddFavorite = async (movieId, userId) => {
  const res = await fetch(`${API_URL}/api/favoriteMovie`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify({
      movieId,
      userId
    })
  })

  const data = await res.json()

  if (!res.ok) {
    throw new Error(data.message)
  }

  return data
}
/*
export const AddFavorite = async (movieId, userId) => {
  const res = await fetch(`${API_URL}/api/favoriteMovie?movieId=${movieId}&userId=${userId}`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json', 
    },
    body: JSON.stringify({ movieId, userId }),
    });
    const data = await res.json();
    if(!res.ok){
      throw new Error(data.message);
     }
     return data;
}
*/
export const registerUser = async (formData) => {
  const res = await fetch(`${API_URL}/api/register`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(formData),
  });
  const data = await res.json();
  if (!res.ok) {
    throw new Error(data.message);
  }
  return data;
};

export const loginUser = async (formData) => {
  const res = await fetch(`${API_URL}/api/login`, {
    method: 'POST', 
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(formData),
  });
  const data = await res.json();  
  if (!res.ok) {
    throw new Error(data.message);
  }
  return data;
};

export const getCurrentUser = async (token) => {

  const res = await fetch(`${API_URL}/api/user/me`, {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`,
    },
  });
  const data = await res.json();
  if(!res.ok){
    throw new Error(data.message);
   }
  return data;
};
    

export const recommendation = async (formData) => {
  const token = localStorage.getItem("token");

  const res = await fetch(`${API_URL}/api/recommendation`, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    },
    body: JSON.stringify(formData ),
  });

 /* console.log("STATUS:", res.status);

const text = await res.text();
console.log("RESPONSE:", text);*/

  const data = await res.json();
  if(!res.ok){
    throw new Error(data.message);
   }
  return data;
};

export const removeFavoriteMovie  = async (movieId) => {
  const token = localStorage.getItem("token");
  const res = await fetch(`${API_URL}/api/favoriteMovie/${movieId}`, {
    method: 'DELETE',
    headers: {
      'Authorization': `Bearer ${token}`
    },
  });
     
  if (!res.ok) {
    throw new Error(res.status);
  }

  return true;
};

export const addMovieRatingApi  = async (formData) => {
  const token = localStorage.getItem("token");
  const res = await fetch(`${API_URL}/api/movieRating`, {
    method: 'POST', 
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    },
    body: JSON.stringify(formData),
  });
  
   if (!res.ok) {
    throw new Error(`Error ${res.status}`);
  }

  return true;
};



 