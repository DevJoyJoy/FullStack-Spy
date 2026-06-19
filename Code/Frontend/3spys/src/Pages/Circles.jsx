import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import { useState, useEffect, useRef } from "react" // MUDANÇA: Importado useEffect e useRef
import '../Styles/Circles.css'
import '../Styles/Components.css'

export function Circles({ isLoaded }) { // MUDANÇA: Recebe a propriedade isLoaded
    const [createCircleModal, setCreateCircle] = useState(false);
    const [alterCircleModal, setAlterCircle] = useState(false);

    // MUDANÇA: Novos estados para controlar os inputs e as coordenadas obtidas
    const [nomeCirculo, setNomeCirculo] = useState("");
    const [enderecoTexto, setEnderecoTexto] = useState("");
    const [coordenadas, setCoordenadas] = useState({ lat: null, lng: null });

    const inputRefCriar = useRef(null);
    const autocompleteRef = useRef(null);

    // MUDANÇA: Efeito para ativar o Autocomplete do Google quando o modal abrir
    useEffect(() => {
        if (!isLoaded || !inputRefCriar.current || !window.google) return;

        autocompleteRef.current = new window.google.maps.places.Autocomplete(inputRefCriar.current, {
            fields: ['geometry', 'formatted_address'],
            types: ['address']
        });

        autocompleteRef.current.addListener('place_changed', () => {
            const place = autocompleteRef.current.getPlace();

            if (place.geometry && place.geometry.location) {
                setCoordenadas({
                    lat: place.geometry.location.lat(),
                    lng: place.geometry.location.lng()
                });
                setEnderecoTexto(place.formatted_address || "");
            } else {
                alert("Por favor, selecione um endereço válido da lista sugerida.");
            }
        });

        return () => {
            if (window.google && autocompleteRef.current) {
                window.google.maps.event.clearInstanceListeners(autocompleteRef.current);
            }
        };
    }, [isLoaded, createCircleModal]);

    // MUDANÇA: Função para disparar os dados montados ao backend
    const handleCriarCirculo = async () => {
        if (!nomeCirculo || !coordenadas.lat || !coordenadas.lng) {
            alert("Preencha o nome e selecione um endereço válido nas sugestões.");
            return;
        }

        const payload = {
            nome: nomeCirculo,
            endereco: enderecoTexto,
            latitude: coordenadas.lat,
            longitude: coordenadas.lng
        };

        console.log("Pronto para enviar ao Backend:", payload);
        // Seu axios.post ou fetch vai aqui...

        alert("Círculo criado com sucesso!");
        setNomeCirculo("");
        setEnderecoTexto("");
        setCoordenadas({ lat: null, lng: null });
        setCreateCircle(false);
    };

    return(
        <>
        <div className="pageCircle">
            <Header></Header>
                <div className="groupBox">
                    <select defaultValue="default" className="groupTextBox">
                        <option value="default" disabled>Selecionar o grupo</option>
                        <option value="grupo1">Grupo 1</option>
                        <option value="grupo2">Grupo 2</option>
                    </select>
                </div>
                <div className='optionsContainerCircle'>

                    <button className="optionCircle" onClick={() => setCreateCircle(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Criar círculo</h1>
                        </section>
                    </button>

                    <button className="optionCircle" onClick={() => setAlterCircle(true)}>
                        <img src="/circle-blank.svg" alt="" />
                        <section>
                            <h1>Visualizar círculo</h1>
                        </section>
                    </button>

                    <button className="optionCircle" onClick={() => setAlterCircle(true)}>
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
                {/* MUDANÇA: Inputs agora controlados pelo estado */}
                <input 
                    className="modalInput" 
                    type="text" 
                    placeholder="Insira aqui o nome do círculo:" 
                    value={nomeCirculo}
                    onChange={(e) => setNomeCirculo(e.target.value)}
                />
                <br />
                <h3>Endereço</h3>
                {/* MUDANÇA: Input recebeu a ref e o value */}
                <input 
                    ref={inputRefCriar}
                    className="modalInput" 
                    type="text" 
                    placeholder="Insira aqui o endereço do círculo:" 
                    value={enderecoTexto}
                    onChange={(e) => setEnderecoTexto(e.target.value)}
                />
                <br />
                
                {/* MUDANÇA: Feedback visual opcional de sucesso */}
                {coordenadas.lat && (
                    <p style={{ color: '#2e7d32', fontSize: '13px', margin: '-10px 0 10px 0' }}>
                        ✓ Localização validada com sucesso!
                    </p>
                )}

                {/* MUDANÇA: Troca do onClick para disparar a função handleCriarCirculo */}
                <button onClick={handleCriarCirculo} className="modalButton">
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