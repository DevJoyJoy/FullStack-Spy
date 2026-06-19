import { useJsApiLoader } from '@react-google-maps/api'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './App.css'
import { MainPage } from './Pages/MainPage'
import { Profile } from './Pages/Profile'
import { Circles } from './Pages/Circles'
import { Group } from './Pages/Group'
import { Login } from './Pages/Login'

const GOOGLE_LIBRARIES = ['places'];

function App() {
  const { isLoaded, loadError } = useJsApiLoader({
    googleMapsApiKey: "SUA_CHAVE_API_DO_GOOGLE_AQUI",
    libraries: GOOGLE_LIBRARIES,
  });

  if (loadError) {
    return <div>Erro ao carregar o Google Maps. Verifique sua chave de API.</div>;
  }

  if (!isLoaded) {
    return <div className="loading-screen">Carregando serviços de mapa...</div>;
  }

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<MainPage/>}/>
          <Route path='/Profile' element={<Profile/>}/>
          <Route path='/Circle' element={<Circles isLoaded={isLoaded}/>}/>
          <Route path='/Group' element={<Group/>}/>
          <Route path='/Login' element={<Login/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App