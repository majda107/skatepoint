<template>
  <div class="main-wrapper">
    <h2 class="main-title">API Dokumentace</h2>
    <div class="doc">
      <h3 class="doc-header">Jednoduchost</h3>
      <div class="doc-about">Zanecháváme naše API jednodhé a otevřené.</div>
      <pre class="doc-code">
[GET] https://skatepoint.cz/hackathon

-> Hackathon 2020. Tým Nepobírám.</pre
      >
    </div>
    <div class="doc">
      <h3 class="doc-header">Endpointy</h3>
      <div class="doc-about">
        Pro naše API poskytujeme jeden český endpoint.
      </div>
      <pre class="doc-code">
https://skatepoint.cz/
</pre
      >
    </div>
    <div class="doc">
      <h3 class="doc-header">Přihlášení</h3>
      <div class="doc-about">
        Přihlášení probíha přes klasický OAuth2.0 flow a Bearer tokeny.
      </div>
      <pre class="doc-code">
[POST] https://skatepoint.cz/auth/login { username: USERNAME, password PASSWORD}

-> { token: string, username: string }</pre
      >
    </div>

    <div class="doc">
      <h3 class="doc-header">Registrace</h3>
      <div class="doc-about">
        Registrace probíha přes klasický OAuth2.0 flow a Bearer tokeny.
      </div>
      <pre class="doc-code">
[POST] https://skatepoint.cz/auth/register { username: USERNAME, email: EMAIL, password PASSWORD  }

-> { token: string, username: string }</pre
      >
    </div>

    <div class="doc">
      <h3 class="doc-header">Získání bodů</h3>
      <div class="doc-about">
        Všechny aktuální body lze získat jednoduchým GET dotazem.
      </div>
      <pre class="doc-code">
[GET] https://skatepoint.cz/skate/getpoints

-> { 
  id: number, 
  name: string, 
  lat: number, 
  lng: number, 
  description: string, 
  type: string, 
  image: string, 
  liked: string[] 
}</pre
      >
    </div>

    <div class="doc">
      <h3 class="doc-header">Významná místa [OPENDATA]</h3>
      <div class="doc-about">Vyhledávání z kolekce významných míst.</div>
      <pre class="doc-code">
[GET] https://skatepoint.cz/skate/getknownplaces?name=NAME

-> [ 
  {
    id: number, 
    name: string, 
    location: string,
    type: string
  }, ...
]</pre
      >
    </div>

    <hr />

    <div class="doc">
      <h3 class="doc-header">Přidání bodu [Autorizované]</h3>
      <div class="doc-about">
        Přidání bodu do otevřené skatepoint databáze. Pro přidání bodu musíte
        poslat Bearer token vašeho účtu.
      </div>
      <pre class="doc-code">
[POST] https://skatepoint.cz/skate/addpoint 

 - Data { name: string, lat: number, lng: number, description: string, type: string }
 - Headers { Authorization: `Bearer $TOKEN` }


-> [ 
  {
    id: number, 
    name: string, 
    location: string,
    type: string
  }, ...
]</pre
      >
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({});
</script>

<style lang="scss" scoped>
@import "../../styles/main.scss";

.doc {
  margin: 38px 0;
}

hr {
  opacity: 0.4;
  margin: 56px 0;
}
</style>