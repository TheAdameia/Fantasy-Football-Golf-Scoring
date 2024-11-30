import React, { useCallback, useEffect, useState } from "react"
import * as signalR from "@microsoft/signalr"
import { useAppContext } from "../contexts/AppContext"

const Chat = () => {
    const [connection, setConnection] = useState(null)
    const [messages, setMessages] = useState([])
    const [message, setMessage] = useState("")
    const { loggedInUser } = useAppContext() //loggedInUser.userName is the username

    useEffect(() => {
        const newConnection = new signalR.HubConnectionBuilder()
          .withUrl("https://localhost:5001/chathub", { withCredentials: true })
          .withAutomaticReconnect()
          .build();
    
        setConnection(newConnection);
    
        return () => {
          if (newConnection) newConnection.stop(); // Cleanup on unmount
        };
      }, []);
    

      useEffect(() => {
        if (connection) {
          connection
            .start()
            .then(() => {
              console.log("Connected!");
    
              // Set up listener for receiving messages
              connection.on("ReceiveMessage", (user, message) => {
                setMessages((prevMessages) => [
                  ...prevMessages,
                  { user, message },
                ]);
              });
            })
            .catch((error) => console.error("Connection failed: ", error));
    
          return () => {
            connection.off("ReceiveMessage"); // Remove listener on cleanup
          };
        }
      }, [connection]);

      
    // Send message handler
    const sendMessage = useCallback(async () => {
        if (!message.trim()) return; // Prevent empty messages

        if (connection) {
        try {
            await connection.invoke("SendMessage", loggedInUser.userName, message);
            setMessage(""); // Clear input after sending
        } catch (error) {
            console.error("Error sending message: ", error);
        }
        }
    }, [connection, message, loggedInUser.userName]);

    return (
        <div style={{ padding: "10px" }}>
          <h2>Chat Room</h2>
    
          {/* I don't plan on using CSS in this fashion, but there are some cool things here that I didn't know existed that I will definitely want for later. */}
          <div
            style={{
              border: "1px solid #ccc",
              padding: "10px",
              height: "300px",
              overflowY: "scroll",
              marginBottom: "10px",
            }}
          >
            {messages.map((m, idx) => (
              <div key={idx}>
                <strong>{m.user}:</strong> {m.message}
              </div>
            ))}
          </div>
    
          {/* Message Input */}
          <div style={{ display: "flex", gap: "10px" }}>
            <input
              type="text"
              value={message}
              onChange={(e) => setMessage(e.target.value)}
              placeholder="Type your message..."
              style={{ flexGrow: 1 }}
            />
            <button onClick={sendMessage} disabled={!message.trim()}>
              Send
            </button>
          </div>
        </div>
    );
};

export default Chat;
