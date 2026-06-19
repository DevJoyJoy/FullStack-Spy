import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import { useState } from "react"
import '../Styles/Circles.css'
import '../Styles/Components.css'

export function Circles() {
    const [createCircleModal, setCreateCircle] = useState(false);
    const [alterCircleModal, setAlterCircle] = useState(false);

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

                    <button className="option" onClick={() => setCreateCircle(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Criar círculo</h1>
                        </section>
                    </button>

                    <button className="option" onClick={() => setAlterCircle(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Visualizar círculo</h1>
                        </section>
                    </button>

                    <button className="option" onClick={() => setAlterCircle(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Alterar círculo</h1>
                        </section>
                    </button>
                </div>
            <Footer></Footer>
        </div>

        {createCircleModal && (
        <div className="modalOverlay">
          <div className="modalBackdrop" onClick={() => {setCreateCircle(false);}}></div>

            <div className="modalContainer">
                <h2>Criar círculo</h2>
                <br />
                <select defaultValue="default" className="groupTextBox">
                    <option value="default" disabled>Selecionar o grupo</option>
                    <option value="grupo1">Grupo 1</option>
                    <option value="grupo2">Grupo 2</option>
                </select>
                <br />
                <h3>Nome</h3>
                <input className="modalInput" type="text" placeholder="Insira aqui o nome do círculo:" />
                <br />
                <h3>Endereço</h3>
                <input className="modalInput" type="text" placeholder="Insira aqui o endereço do círculo:" />
                <br />
                <button onClick={() => setCreateCircle(false)} className="modalButton">
                    Criar
                </button>
            </div>
            </div>
        )}

        {alterCircleModal && (
        <div className="modalOverlay">
          <div className="modalBackdrop" onClick={() => {setAlterCircle(false);}}></div>

            <div className="modalContainer">
                <h2>Alterar círculo</h2>
                <br />
                <select defaultValue="default" className="groupTextBox">
                    <option value="default" disabled>Selecionar círculo</option>
                    <option value="grupo1">Casa</option>
                    <option value="grupo2">Trabalho</option>
                </select>
                <br />
                <h3>Nome</h3>
                <input className="modalInput" type="text" placeholder="Insira aqui o nome do círculo:" />
                <br />
                <h3>Endereço</h3>
                <input className="modalInput" type="text" placeholder="Insira aqui o endereço do círculo:" />
                <br />
                <button onClick={() => setAlterCircle(false)} className="modalButton">
                    Salvar alterações
                </button>
            </div>
            </div>
        )}
        </>
    )
}