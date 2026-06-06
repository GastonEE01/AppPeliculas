import {useNavigate} from 'react-router-dom'
import { registerUser } from "../Services/api";
import "../pages/Login.css";
import { useForm } from "../hooks/useForm";
export const RegisterPage = () => {
  
  const navigate = useNavigate()  // ← Crear la función

  const { formData, handleChange, handleSubmit } = useForm({
    name: "",
    lastName: "",
    email: "",
    imgUrl: "",
    passwordHash: "",
  },
 (response) => {  // ← Callback personalizado
    localStorage.setItem("email", response.email)
    navigate('/login')
  });

  return (
    <div className="login-page">
      <form className="form" onSubmit={(e) => handleSubmit(e, registerUser)}>
        <p id="heading">Register</p>

        <div className="field">
          <svg
            className="input-icon"
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            viewBox="0 0 16 16"
          >
            <path d="M13.106 7.222c0-2.967-2.249-5.032-5.482-5.032-3.35 0-5.646 2.318-5.646 5.702 0 3.493 2.235 5.708 5.762 5.708.862 0 1.689-.123 2.304-.335v-.862c-.43.199-1.354.328-2.29.328-2.926 0-4.813-1.88-4.813-4.798 0-2.844 1.921-4.881 4.594-4.881 2.735 0 4.608 1.688 4.608 4.156 0 1.682-.554 2.769-1.416 2.769-.492 0-.772-.28-.772-.76V5.206H8.923v.834h-.11c-.266-.595-.881-.964-1.6-.964-1.4 0-2.378 1.162-2.378 2.823 0 1.737.957 2.906 2.379 2.906.8 0 1.415-.39 1.709-1.087h.11c.081.67.703 1.148 1.503 1.148 1.572 0 2.57-1.415 2.57-3.643zm-7.177.704c0-1.197.54-1.907 1.456-1.907.93 0 1.524.738 1.524 1.907S8.308 9.84 7.371 9.84c-.895 0-1.442-.725-1.442-1.914z" />
          </svg>

          <input
            autoComplete="off"
            placeholder="Username"
            className="input-field"
            type="text"
            value={formData.name}
            onChange={handleChange}
            name="name"
          />
        </div>

        <div className="field">
          <svg
            className="input-icon"
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            viewBox="0 0 16 16"
          >
            <path d="M8 8a3 3 0 1 0 0-6 3 3 0 0 0 0 6z" />
            <path d="M14 14s-1-4-6-4-6 4-6 4h12z" />
          </svg>

          <input
            autoComplete="off"
            placeholder="Last Name"
            className="input-field"
            type="text"
             value={formData.lastName}
            onChange={handleChange}
            name="lastName"
          />
        </div>

        <div className="field">
          <svg
            className="input-icon"
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            viewBox="0 0 16 16"
          >
            <path d="M0 4a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v8a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V4zm2-.5 6 4 6-4H2z" />
          </svg>
          <input
            autoComplete="off"
            placeholder="Email"
            className="input-field"
            type="email"
            value={formData.email}
            onChange={handleChange}
            name="email"
          />
        </div>

        <div className="field">
          <svg
            className="input-icon"
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            viewBox="0 0 16 16"
          >
            <path d="M4.502 1a1.5 1.5 0 0 0-1.415 1H2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2h-1.087A1.5 1.5 0 0 0 11.498 1h-7z" />
            <path d="M10.648 7.646a.5.5 0 0 1 .704 0l2 2a.5.5 0 0 1-.704.708L11 8.707l-3.146 3.147a.5.5 0 0 1-.708 0L5 9.707 2.354 12.354a.5.5 0 1 1-.708-.708l3-3a.5.5 0 0 1 .708 0L7.5 10.793l3.148-3.147z" />
          </svg>
          <input
            autoComplete="off"
            placeholder="IMG URL"
            className="input-field"
            type="text"
             value={formData.imgUrl}
            onChange={handleChange}
            name="imgUrl"
          />
        </div>

        <div className="field">
          <svg
            className="input-icon"
            xmlns="http://www.w3.org/2000/svg"
            width="16"
            height="16"
            fill="currentColor"
            viewBox="0 0 16 16"
          >
            <path d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2z"></path>
          </svg>

          <input
            placeholder="Password"
            className="input-field"
            type="password"
            value={formData.passwordHash}
            onChange={handleChange}
            name="passwordHash"
          />
        </div>

        <div className="btn">
          <button className="button1" type="submit">
            Register
          </button>

          <button className="button2" type="button" onClick={() => navigate("/login")}>
            Sign Up
          </button>
        </div>

      </form>
    </div>
  );
};
