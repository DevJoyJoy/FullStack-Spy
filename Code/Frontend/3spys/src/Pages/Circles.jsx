import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import '../Styles/Circles.css'

export function Circles() {
    return(
        <>
        <div className="page">
            <Header></Header>
                <div className="groupBox">
                    <select defaultValue="default" className="groupTextBox">
                        <option value="default" disabled>Selecionar o grupo</option>
                        <option value="grupo1">Grupo 1</option>
                        <option value="grupo2">Grupo 2</option>
                    </select>
                </div>
                <div className='optionsContainer_'>

                    <div className="option">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Criar círculo</h1>
                        </section>
                    </div>

                    <div className="option">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Visualizar círculo</h1>
                        </section>
                    </div>

                    <div className="option">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Alterar círculo</h1>
                        </section>
                    </div>
                </div>
            <Footer></Footer>
        </div>
        </>
    )
}