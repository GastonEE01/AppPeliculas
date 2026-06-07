# App de Películas
Aplicación web Fullstack desarrollada con React y .NET que permite a los usuarios gestionar un catálogo de películas, registrarse y administrar su propia lista de películas favoritas en la nube.

## 🔗 Enlaces del Proyecto
DEMO Frontend (Vercel): https://app-peliculas-three.vercel.app/

API Backend (Azure): https://apppeliculas-cqayf8bne0e9fmc2.brazilsouth-01.azurewebsites.net/index.html

## Funcionalidades:
* Autenticación JWT: Registro e inicio de sesión de usuarios para gestionar perfiles individuales.
* Catálogo de Películas: Visualización de películas disponibles y calificar la pelicula.
* Gestión de Favoritos: Agregar y eliminar películas de la lista de favoritos de forma personalizada por usuario, controlando duplicados.
* Persistencia en la Nube:** Toda la información de usuarios, películas y favoritos se persiste de forma segura en la base de datos, reemplazando el uso de `localStorage`.
* Interfaz de Usuario: Navegación fluida con React Router DOM y soporte para Modo Oscuro / Claro (con persistencia local de preferencia de tema).
* ChatBot con IA: Recomendacion de peliculas utilizando integracion con Gemini AI

## Tecnologías Utilizadas

### Frontend
* React (Vite)
* React Router DOM
* JavaScript (ES6+)
* CSS Vanilla

### Backend 
* .NET (ASP.NET Core Web API)
* Entity Framework Core
* JWT Authentication
* Arquitectura por capas / Use Cases

### Base de Dato
* PostgreSQL
* Supabase

### IA 
* Gemini API (Google AI Studio)

### Seguridad
* Protección de endpoints con JWT.
* Variables sensibles gestionadas mediante Environment Variables en Azure.
* Exclusión de secretos mediante .gitignore.

### Deploy
* Vercel (Frontend)
* Azure App Service (Backend)

### Estado del proyecto
* Proyecto personal desarrollado con fines de práctica y aprendizaje Fullstack utilizando React + .NET + Azure.
