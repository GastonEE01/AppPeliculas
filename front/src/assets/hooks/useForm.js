import {useState}  from 'react'

export const useForm = (initialState,onSuccess) => {

    const [formData,setFormData] = useState(initialState);
  
      // Manejo de cambios en los campos del formulario
    const handleChange = (e) => { 
        const {name,value} = e.target;
        setFormData((prev) => ({
            ...prev,
            [name]: value
        }));
    };

    // Reset
    const resetForm = () => {
        setFormData(initialState);
    };

    // Submit reutilizable para login y register
    const handleSubmit = async (e, apiFunction) => {
         e.preventDefault();
         console.log(formData);
         try{
           const response = await apiFunction(formData);
           console.log("RESPONSE:", response);
           console.log("EMAIL RESPONSE:", response.Email);
           onSuccess?.(response) 
           localStorage.setItem("email", response.email); // Guarda el token en localStorage
         }
         catch (error) {
           console.error("Error en el login:", error);
         }
       };

     

    return {
        formData,
        handleChange,
        resetForm,  
        setFormData,
        handleSubmit,
    };
};

