import axios from "axios";

const api = axios.create({
    baseURL:"https://localhost:44365"
})

export default api;