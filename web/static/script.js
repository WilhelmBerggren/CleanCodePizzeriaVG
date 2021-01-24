import { html, render, useState, useEffect } from 'https://unpkg.com/htm/preact/standalone.module.js'

const api = "http://localhost:5000/stock";

function App() {
  const [stock, setStock] = useState([]);

  useEffect(fetchPosts, []);

  function fetchPosts() {
    fetch(api)
      .then(res => res.json())
      .then(d => setStock(d || []));
  }

  function updateStock(e) {
    e.preventDefault();
    const data = new FormData(e.target);
    const name = data.get('name');
    const stock = data.get('stock');
    fetch(api, {
      method: "POST",
      mode: "cors",
      headers: {"Content-Type": "application/json"},
      body: JSON.stringify({ name, stock })
    })
    .then(fetchPosts);
  }

  function massDelivery() {
    fetch(`${api}/massdelivery`, {
      method: "POST",
      mode: "cors",
    })
    .then(fetchPosts);
  }

  return html`
    <h1>Pizzeria Stock Simulator 2021</h1>
    <button onclick=${massDelivery}>Mass delivery</button>
    <div>
      ${stock.map(item => html`
        <p>
          ${item.name}
          <form onsubmit=${updateStock}>
            <input name="name" type="hidden" value=${item.name} />
            <input name="stock" type="number" value=${item.stock} />
          </form>
        </p>`)}
    </div>`;
}

render(html`<${App} name="World" />`, document.body);