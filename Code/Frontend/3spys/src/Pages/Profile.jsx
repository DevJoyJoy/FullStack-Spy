import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import '../Styles/Profile.css'
import { useState } from "react"

export function Profile() {
    const [alterProfileModal, setAlterProfile] = useState(false)
    const [image, setImage] = useState({
        preview: "",
        file: null,
    });

    return(
        <>
        <div className="pageProfile">
            <Header></Header>
                <div className="profileContainer">
                    <img src="/circle-blank.svg" alt="" />
                    <h1>Nome do farmador</h1>
                </div>
                <div className='optionsContainerProfile'>
                    <h1>Ações para usuário</h1>
                    <br />
                    <button className="optionProfile" onClick={() => setAlterProfile(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Alterar informações</h1>
                        </section>
                    </button>

                    <button className="optionProfile">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Excluir conta</h1>
                        </section>
                    </button>

                    <button className="optionProfile">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Sair da conta</h1>
                        </section>
                    </button>
                </div>
            <Footer></Footer>
        </div>

        {alterProfileModal && (
        <div className="modalOverlay">
          <div className="modalBackdrop" onClick={() => {setAlterProfile(false);}}></div>

            <div className="modalContainer">
                <h2>Alterar perfil</h2>
                <br />
                <label className="uploadLabel">
                {image.preview ? (
                    <img src={image.preview} className="previewImg"/>
                ) : (
                    <span className="">Foto de perfil</span>
                )}
                <input
                    type="file"
                    className="hiddenInput"
                    accept="image/*"
                    onChange={(e) => handleImageChange(e, setImage)}
                />
                </label>
                <br />
                <br />
                <h3>Nome</h3>
                <br />
                <input className="modalInput" type="text" placeholder="Insira aqui o nome do círculo:" />
                <br />
                <button onClick={() => setAlterProfile(false)} className="modalButton">
                    Salvar alterações
                </button>
            </div>
            </div>
        )}
        </>
    )
}