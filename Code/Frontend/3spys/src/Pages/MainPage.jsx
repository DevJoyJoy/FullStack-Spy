import { Header } from '../Components/Header';
import { Footer } from '../Components/Footer';
import { useEffect, useState } from 'react';
import '../Styles/MainPage.css'
import { MapContainer, TileLayer, Marker, Popup, useMap } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import '../Styles/MainPage.css';

import markerIcon from 'leaflet/dist/images/marker-icon.png';
import markerShadow from 'leaflet/dist/images/marker-shadow.png';
let DefaultIcon = L.icon({
    iconUrl: markerIcon,
    shadowUrl: markerShadow,
    iconSize: [25, 41],
    iconAnchor: [12, 41]
});
L.Marker.prototype.options.icon = DefaultIcon;

const iconePontoVivo = L.divIcon({
  className: 'ponto-gps-container',
  html: `<div class="ponto-gps-pulso"></div><div class="ponto-gps-nucleo"></div>`,
  iconSize: [20, 20],
  iconAnchor: [10, 10]
});

function AutoCentro({ posicao }) {
  const map = useMap();
  useEffect(() => {
    if (posicao) {
      map.setView([posicao.lat, posicao.lng], map.getZoom());
    }
  }, [posicao, map]);
  return null;
}

export function MainPage() {
  const [minhaPosicao, setMinhaPosicao] = useState(null);
  const [gpsCarregado, setGpsCarregado] = useState(false);

  useEffect(() => {
    if (!navigator.geolocation) {
      alert("Seu navegador não suporta geolocalização.");
      return;
    }

    const idRastreador = navigator.geolocation.watchPosition(
      (posicao) => {
        setMinhaPosicao({
          lat: posicao.coords.latitude,
          lng: posicao.coords.longitude
        });
        setGpsCarregado(true);
      },
      (erro) => {
        console.error("Erro ao pegar localização em tempo real:", erro);
      },
      {
        enableHighAccuracy: true, 
        timeout: 10000,
        maximumAge: 0
      }
    );

    return () => navigator.geolocation.clearWatch(idRastreador);
  }, []);

  if (!minhaPosicao) {
    return (
      <div className="page">
        <Header />
        <div className="loadScreen">
          <div className="ponto-gps-nucleo" style={{ position: 'relative', top: 0, left: 0, animation: 'pulsarGps 1.5s infinite' }}></div>
          <p style={{ color: '#666', fontSize: '14px', fontWeight: 'bold' }}>Buscando seu local atual...</p>
        </div>
        <Footer />
      </div>
    );
  }

  return (
    <>
      <div className="page">
        <Header></Header>
          <div className="map">
            <MapContainer 
            center={[minhaPosicao.lat, minhaPosicao.lng]} 
            zoom={15} 
            style={{ width: '100%', height: '100%', zIndex: 1 }}
            zoomControl={false}
          >
            <TileLayer
              attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>'
              url="https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png"
            />

            {gpsCarregado && (
              <Marker position={[minhaPosicao.lat, minhaPosicao.lng]} icon={iconePontoVivo}>
                <Popup>Você está aqui!</Popup>
              </Marker>
            )}

            <AutoCentro posicao={minhaPosicao} />
          </MapContainer>
          </div>
          <div className='usersContainer'>
            <div className="users">
              <img src="/personFull.png" alt="" />
              <section>
                <h1>Você</h1>
                <p>Online agora</p>
              </section>
            </div>

            <div className="users">
              <img src="/personFull.png" alt="" />
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