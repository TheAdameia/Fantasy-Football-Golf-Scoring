import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

export default defineConfig(() => {
return {
    server: {
        open: true,
        proxy: {
            "/api": {
            target: "https://localhost:5001",
            changeOrigin: true,
            secure: false,
            },
        },
    },
    build: {
        outDir: "/var/www/fantasygolfball", // nginx root - do not run build on local!
        emptyOutDir: true, //cleans old build files before creating new ones
    },
    plugins: [react()],
};
});