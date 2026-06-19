import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import { useState } from "react";
import '../Styles/Group.css'
import '../Styles/Components.css'

export function Group() {
    const [enterGroupModal, setEnterGroup] = useState(false);
    const [createGroupModal, setCreateGroup] = useState(false);

    return(
        <>
        <div className="pageGroup">
            <Header></Header>
                <div className='optionsContainerGroup'>
                    <button className="optionGroup" onClick={() => setCreateGroup(true)}>
                            <img src="/groupFull.png" alt="" />
                            <section>
                                <h1>Criar grupo</h1>
                            </section>
                    </button>

                    <button className="optionGroup" onClick={() => setEnterGroup(true)}>
                        <img src="/groupFull.png" alt="" />
                        <section>
                            <h1>Entrar em grupo</h1>
                        </section>
                    </button>
                </div>
            <Footer></Footer>
        </div>

        {createGroupModal && (
        <div className="modalOverlay">
          <div className="modalBackdrop" onClick={() => {setCreateGroup(false);}}></div>

            <div className="modalContainer">
                <h2>Criar grupo</h2>
                <br />
                <input className="modalInput" type="text" placeholder="Insira aqui o nome do grupo:" />
                <br />
                <button onClick={() => setCreateGroup(false)} className="modalButton">
                    Criar
                </button>
            </div>
            </div>
        )}

        {enterGroupModal && (
        <div className="modalOverlay">
          <div className="modalBackdrop" onClick={() => {setEnterGroup(false);}}></div>

            <div className="modalContainer">
                <h2>Entrar em grupo</h2>
                <br />
                <input className="modalInput" type="text" placeholder="Insira aqui o código do grupo:" />
                <br />
                <button onClick={() => setEnterGroup(false)} className="modalButton">
                    Entrar
                </button>
            </div>
            </div>
        )}
        </>
    )
}