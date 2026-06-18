import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import '../Styles/Group.css'

export function Group() {
    return(
        <>
        <div className="page">
            <Header></Header>
                <div className='optionsContainer'>
                    <div className="option">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Criar grupo</h1>
                        </section>
                    </div>

                    <div className="option">
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Entrar em grupo</h1>
                        </section>
                    </div>
                </div>
            <Footer></Footer>
        </div>
        </>
    )
}