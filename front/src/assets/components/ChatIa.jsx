import { useState } from "react";
import "../components/ChatIa.css";
import { RiGeminiFill } from "react-icons/ri";
import { useChatMessages  } from "../hooks/useChatMessages";
import { recommendation } from "../Services/api"; 

export const ChatIa = () => {

  
  const { formData, handleChange, sendMessage,messages } = useChatMessages({ message: "" });

  const [isOpen, setIsOpen] = useState(false);
  
  return (
    <div>
      <div className="chat-button" onClick={() => setIsOpen(true)}>
        <RiGeminiFill size={45} color="gray" backgroundColor="black" />
      </div>
      {isOpen && (
        <div className="container">
          <div className="nav-bar">
            <div className="close" onClick={() => setIsOpen(false)}>
              <div className="line one"></div>
              <div className="line two"></div>
            </div>
          </div>
          <div className="messages-area">
            {/* Aquí puedes mapear tus mensajes */}
            {messages.map((msg, index) => (
              <div key= {index} className={msg.rol}>
                {msg.message}
              </div>
            ))}
          </div>
          <div className="sender-area">
            <div className="input-place">
              <input value= {formData.message} onChange={handleChange}
                placeholder="Send a message."
                className="send-input"
                type="text"
                name= "message"
              ></input>
              <div className="send"  onClick = {(e) => sendMessage(e, recommendation)}>
                <svg
                  className="send-icon"
                  version="1.1"
                  id="Capa_1"
                  xmlns="http://www.w3.org/2000/svg"
                  xmlnsXlink="http://www.w3.org/1999/xlink"
                  x="0px"
                  y="0px"
                  viewBox="0 0 512 512"
                  style={{ enableBackground: "new 0 0 512 512" }}
                  xmlSpace="preserve"
                >
                  <g>
                    <g>
                      <path fill="#6B6C7B" d="M481.508,210.336L68.414,38.926c-17.403-7.222-37.064-4.045-51.309,8.287C2.86,59.547-3.098,78.551,1.558,96.808 L38.327,241h180.026c8.284,0,15.001,6.716,15.001,15.001c0,8.284-6.716,15.001-15.001,15.001H38.327L1.558,415.193 c-4.656,18.258,1.301,37.262,15.547,49.595c14.274,12.357,33.937,15.495,51.31,8.287l413.094-171.409 C500.317,293.862,512,276.364,512,256.001C512,235.638,500.317,218.139,481.508,210.336z"></path>
                    </g>
                  </g>
                </svg>
              </div>
            </div>
          </div>
          <div></div>
        </div>
      )}
    </div>
  );
};
