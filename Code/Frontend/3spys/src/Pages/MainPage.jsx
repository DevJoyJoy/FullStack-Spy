import { Header } from '../Components/Header';
import { Footer } from '../Components/Footer';
import '../Styles/MainPage.css'

export function MainPage() {
  
  return (
    <>
      <div className="page">
        <Header></Header>
          <div className="map"></div>
          <div className='usersContainer'>
            <div className="users">
              <img src="/circle-blank.svg" alt="" />
              <section>
                <h1>Usuário</h1>
                <p>Visto por último: 07:99</p>
              </section>
            </div>

            <div className="users">
              <img src="/circle-blank.svg" alt="" />
              <section>
                <h1>Usuário</h1>
                <p>Visto por último: 07:99</p>
              </section>
            </div>

            <div className="users">
              <img src="/circle-blank.svg" alt="" />
              <section>
                <h1>Usuário</h1>
                <p>Visto por último: 07:99</p>
              </section>
            </div>

            <div className="users">
              <img src="/circle-blank.svg" alt="" />
              <section>
                <h1>Usuário</h1>
                <p>Visto por último: 07:99</p>
              </section>
            </div>

            <div className="users">
              <img src="/circle-blank.svg" alt="" />
              <section>
                <h1>Usuário</h1>
                <p>Visto por último: 07:99</p>
              </section>
            </div>
          </div>
          <Footer></Footer>
      </div>
    </>
  )

}