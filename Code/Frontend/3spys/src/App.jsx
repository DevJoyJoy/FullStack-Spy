
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import './App.css'
import { MainPage } from './Pages/MainPage'
import { Profile } from './Pages/Profile'
import { Circles } from './Pages/Circles'
import { Group } from './Pages/Group'
import { Login } from './Pages/Login'

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<MainPage/>}/>
          <Route path='/Profile' element={<Profile/>}/>
          <Route path='/Circle' element={<Circles/>}/>
          <Route path='/Group' element={<Group/>}/>
          <Route path='/Login' element={<Login/>}/>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
