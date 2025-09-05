// vite.config.js
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'   // plugin Tailwind v4

export default defineConfig({
  plugins: [
    react(),
    tailwindcss()           // ← thêm dòng này
  ]
})
