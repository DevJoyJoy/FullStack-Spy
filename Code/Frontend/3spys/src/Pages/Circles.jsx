import { Header } from "../Components/Header"
import { Footer } from "../Components/Footer"
import { useState } from "react" 
import '../Styles/Circles.css'
import '../Styles/Components.css'

export function Circles() {
    const [createCircleModal, setCreateCircle] = useState(false);
    const [alterCircleModal, setAlterCircle] = useState(false);

    const [nomeCirculo, setNomeCirculo] = useState("");
    const [enderecoTexto, setEnderecoTexto] = useState("");
    const [coordenadas, setCoordenadas] = useState({ lat: null, lng: null });
    const [carregando, setCarregando] = useState(false);

    const handleBuscarCoordenadas = async () => {
        if (!enderecoTexto.trim()) {
            alert("Digite um endereço primeiro para podermos validar!");
            return;
        }

        setCarregando(true);
        try {
            const url = `https://nominatim.openstreetmap.org/search?format=json&q=${encodeURIComponent(enderecoTexto)}&limit=1`;
            const response = await fetch(url, {
                headers: {
                    'Accept-Language': 'pt-BR'
                }
            });
            const data = await response.json();

            if (data && data.length > 0) {
                const resultado = data[0];
                setCoordenadas({
                    lat: parseFloat(resultado.lat),
                    lng: parseFloat(resultado.lon)
                });
                console.log(resultado.lat);
                console.log(resultado.lon);
                setEnderecoTexto(resultado.display_name);
            } else {
                alert("Não encontramos esse endereço. Tente digitar de forma mais simples (Ex: Rua Exemplo, 123, Cidade).");
                setCoordenadas({ lat: null, lng: null });
            }
        } catch (error) {
            console.error("Erro na busca do endereço:", error);
            alert("Erro ao conectar com o serviço de mapas gratuito.");
        } finally {
            setCarregando(false);
        }
    };

    const handleCriarCirculo = async () => {
        if (!nomeCirculo || !coordenadas.lat || !coordenadas.lng) {
            alert("Preencha o nome e valide o endereço clicando no botão 'Validar Endereço' primeiro!");
            return;
        }

        const payload = {
            nome: nomeCirculo,
            endereco: enderecoTexto,
            latitude: coordenadas.lat,
            longitude: coordenadas.lng
        };

        console.log("Pronto para enviar ao Backend:", payload);

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
                <input 
                    className="modalInput" 
                    type="text" 
                    placeholder="Insira aqui o nome do círculo:" 
                    value={nomeCirculo}
                    onChange={(e) => setNomeCirculo(e.target.value)}
                />
                <br />
                <h3>Endereço</h3>
                <div style={{ display: 'flex', gap: '8px', alignItems: 'center' }}>
                    <input 
                        className="modalInput" 
                        type="text" 
                        placeholder="Ex: Av. Paulista, 1000, São Paulo" 
                        value={enderecoTexto}
                        onChange={(e) => {
                            setEnderecoTexto(e.target.value);
                            if(coordenadas.lat) setCoordenadas({ lat: null, lng: null }); // Reseta validação se mudar o texto
                        }}
                        style={{ flex: 1 }}
                    />
                    <button 
                        type="button" 
                        onClick={handleBuscarCoordenadas}
                        disabled={carregando}
                        style={{ padding: '10px', cursor: 'pointer', borderRadius: '5px', border: '1px solid #ccc', backgroundColor: '#e0e0e0' }}
                    >
                        {carregando ? "..." : "Validar"}
                    </button>
                </div>
                <br />
                
                {coordenadas.lat && (
                    <p style={{ color: '#2e7d32', fontSize: '13px', margin: '-10px 0 10px 0' }}>
                        ✓ Localização encontrada com sucesso! (Lat: {coordenadas.lat.toFixed(4)})
                    </p>
                )}

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