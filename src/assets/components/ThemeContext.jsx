import React, { createContext, useContext, useState } from 'react'

const ThemeContext = createContext()

export const ThemeProvider = ({children}) => {
  
    const [darkMode,setDarkMode] = useState(() => {
        const saved = localStorage.getItem('theme')
        return saved ? JSON.parse(saved) : false
    })

    const contexto = createContext()
    const valor = useContext(contexto)
  
    const toggleTheme = () => {
        setDarkMode(prev => !prev)
    }
    return (
    <div>
      <ThemeContext.Provider value= {{
        darkMode,toggleTheme}}>
            {children}
        </ThemeContext.Provider>
    </div>
  )
}

export const useTheme = () => useContext(ThemeContext)
