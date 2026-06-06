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
    setDarkMode(prev => {
    const newValue = !prev
    localStorage.setItem('theme', JSON.stringify(newValue))
    return newValue
}) }
    return (
    <div>
      <ThemeContext.Provider value= {{
        darkMode,toggleTheme}}>
            {children}
        </ThemeContext.Provider>
    </div>
  )
}

// otra forma de hacerlo pero es mas robusto
/*export const ThemeProvider = ({children}) => {
  
    const [darkMode,setDarkMode] = useState(() => {
        try {
            const saved = localStorage.getItem('theme')
            return saved ? JSON.parse(saved) : false
        } catch {
            return false
        }
    })
  
    const toggleTheme = () => {
        setDarkMode(prev => {
            const newValue = !prev
            localStorage.setItem('theme', JSON.stringify(newValue))
            return newValue
        })
    }
    
    return (
    <div>
      <ThemeContext.Provider value= {{
        darkMode,toggleTheme}}>
            {children}
        </ThemeContext.Provider>
    </div>
  )
}*/

export const useTheme = () => useContext(ThemeContext)
