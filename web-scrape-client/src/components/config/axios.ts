import axios from 'axios'

const axiosInstance = axios.create({
  baseURL:
    import.meta.env.MODE === 'development' ? 'http://localhost:5185' : '/api',
})

export default axiosInstance
