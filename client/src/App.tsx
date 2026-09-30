import { Route, Routes } from 'react-router-dom'
import './App.css';
import './css/authentication.css';
import './css/navbar.css';
import './css/myprofile.css';
import './css/header.css';

import LandingPage from './pages/LandingPage'
import LoginPage from './pages/authentication/LoginPage'
import CreateAccountPage from './pages/authentication/CreateAccountPage'
import Navbar from './components/Navbar';
import PlayersPage from './pages/PlayersPage';
import ContactPage from './pages/ContactPage';
import MyProfilePage from './pages/MyProfilePage';

function App() {
  
  return (
    <>
      <Navbar />
      <Routes>
        <Route path={"/"} element={<LandingPage />}/>
        <Route path={"/players"} element={<PlayersPage />}/>
        <Route path={"/my-profile"} element={<MyProfilePage />}/>
        <Route path={"/contact"} element={<ContactPage />}/>
        <Route path={"/login"} element={<LoginPage />}/>
        <Route path={"/create-account"} element={<CreateAccountPage />}/>
      </Routes>
    </>
  )
}

export default App
