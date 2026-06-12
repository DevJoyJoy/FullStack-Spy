import '../Styles/Components.css'
import { useNavigate } from 'react-router-dom'

export function Footer() {
    const navigate = useNavigate()

    return(
        <div class="footer">
            <div class="menuItem">
                <a href="" onClick={() => navigate('/')}>
                    <img src="../../public/circle-blank.svg" alt="" />
                    <p>Localização</p>
                </a>
            </div>
            <div class="menuItem">
                <a href="" onClick={() => navigate('/Group')}>
                    <img src="../../public/circle-blank.svg" alt="" />
                    <p>Grupos</p>
                </a>
            </div>
            <div class="menuItem">
                <a href="" onClick={() => navigate('/Circle')}>
                    <img src="../../public/circle-blank.svg" alt="" />
                    <p>Círculos</p>
                </a>
            </div>
            <div class="menuItem">
                <a href="" onClick={() => navigate('/Profile')}>
                    <img src="../../public/circle-blank.svg" alt="" />
                    <p>Perfil</p>
                </a>
            </div>
        </div>
    )
}