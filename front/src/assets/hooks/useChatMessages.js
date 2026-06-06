import { useState } from "react";

export const useChatMessages = (initialState) => {
  const [formData, setFormData] = useState(initialState);
  const [messages, setMessages] = useState([]);

  const handleChange = (e) => {
    setFormData({ ...formData, message: e.target.value });
  };

  const sendMessage = async (e, apiFunction) => {
    try {
      const response = await apiFunction(formData);
      setMessages((prev) => [
        ...prev,
        { rol: "user", message: formData.message },
        { rol: "bot", message: response.recommendations  },
      ]);

      setFormData({ message: "" });
    } catch (error) {
      console.error("Error al enviar mensaje:", error);
    }
  };

  return {
    formData,
    handleChange,
    sendMessage,
    messages,
  };
};
