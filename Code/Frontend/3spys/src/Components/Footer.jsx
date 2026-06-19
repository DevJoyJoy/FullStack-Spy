import '../Styles/Components.css'
import { useNavigate } from 'react-router-dom'

export function Footer() {
    const navigate = useNavigate()

    return(
        <div className="footer">
            <div className="menuItem">
                <a href="" onClick={() => navigate('/')}>
                    <img src="/compass.png" alt="" />
                    <p>Localização</p>
                </a>
            </div>
            <div className="menuItem">
                <a href="" onClick={() => navigate('/Group')}>
                    <img src="/group.png" alt="" />
                    <p>Grupos</p>
                </a>
            </div>
            <div className="menuItem">
                <a href="" onClick={() => navigate('/Circle')}>
                    <img src="/locator.png" alt="" />
                    <p>Círculos</p>
                </a>
            </div>
            <div className="menuItem">
                <a href="" onClick={() => navigate('/Profile')}>
                    <img src="/person.png" alt="" />
                    <p>Perfil</p>
                </a>
            </div>
        </div>
    )
}