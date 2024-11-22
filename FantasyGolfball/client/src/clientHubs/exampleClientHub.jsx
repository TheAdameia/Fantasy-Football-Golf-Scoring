import React, { useEffect, useState } from "react";
import * as signalR from "@microsoft/signalr";

const Chat = () => {
    const [connection, setConnection] = useState(null);
    const [messages, setMessages] = useState([]);
    const [message, setMessage] = useState("");

    useEffect(() => {
        const newConnection = new signalR.HubConnectionBuilder()
            .withUrl("https://your-backend-url/chathub")
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start()
                .then(() => {
                    console.log("Connected!");

                    connection.on("ReceiveMessage", (user, message) => {
                        setMessages((prevMessages) => [...prevMessages, { user, message }]);
                    });
                })
                .catch(error => console.error("Connection failed: ", error));
        }
    }, [connection]);

    const sendMessage = async () => {
        if (connection) {
            await connection.invoke("SendMessage", "ReactUser", message);
            setMessage("");
        }
    };

    return (
        <div>
            <div>
                {messages.map((m, idx) => (
                    <div key={idx}>{m.user}: {m.message}</div>
                ))}
            </div>
            <input
                type="text"
                value={message}
                onChange={(e) => setMessage(e.target.value)}
            />
            <button onClick={sendMessage}>Send</button>
        </div>
    );
};

export default Chat;
