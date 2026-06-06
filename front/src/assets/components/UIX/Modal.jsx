import {useState} from 'react'
      //   <Modal movies={movies} addMovie={addMovie} isOpen={modal} onClose={() => setModal(false)} />

export const Modal = ({movies,addMovie,handleSearch,searchText,isOpen,onClose}) => {
    const [count,setCount] = useState(0)
        const [form,setForm] = useState({
            title: '',
            categoria: '',
            img: ''
        })
        const saveInput = (e) => {
            const {name, value} = e.target
            setForm({...form,
            [name]: value
            })
        }

    const[message,setMessage] = useState("")

    if(!isOpen) return null
  return (
    <div>
        <div className="card">
            <button className="close" onClick={onClose}>X</button>
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

        </div>
    </div>
  )
}

