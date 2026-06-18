import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import '../Styles/Profile.css'

export function Profile() {
    return(
        <>
        <div className="page">
            <Header></Header>
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