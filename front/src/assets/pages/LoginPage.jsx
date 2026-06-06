import { useNavigate } from "react-router-dom";
import { useState } from "react";
import "../pages/Login.css";
import { useForm } from "../hooks/useForm";
import { loginUser } from "../Services/api";

export const LoginPage = () => {
  const navigate = useNavigate();
  const { formData, handleChange, handleSubmit } = useForm(
    {
      email: "",
      password: "",
    },
    (response) => {
      // ← Callback personalizado
      localStorage.setItem("token", response.token);
      console.log("TOKEN RESPONSE:", response.token);
      navigate("/movies");
    },
  );

  return (
    <div className="login-page">
      <form className="form" onSubmit={(e) => handleSubmit(e, loginUser)}>
        <p id="heading">Login</p>

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
            <path d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2z"></path>
          </svg>

          <input
            placeholder="Password"
            className="input-field"
            type="password"
            value={formData.password}
            onChange={handleChange}
            name="password"
          />
        </div>

        <div className="btn">
          <button className="button1" type="submit">
            Login
          </button>

          <button className="button2" type="button" onClick={() => navigate("/register")}>
            Sign Up
          </button>
        </div>

        
      </form>
    </div>
  );
};
