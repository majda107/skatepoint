<template>
  <section class="nav">
    <div class="nav-content main-wrapper">
      <div class="nav-content-title">
        <div class="nav-content-title-logo">
          <a href="#" style="text-decoration: none;"><h1>Školu Nepobírám</h1></a>
        </div>
      </div>
      <div class="nav-content-menu">
        <ul class="nav-content-menu-items">
          <li class="nav-content-menu-items-item">
            <a href="#how-it-works">Hledat školu</a>
          </li>
          <li class="nav-content-menu-items-item">
            <a href="#">Aktuální opatření</a>
          </li>
          <li class="nav-content-menu-items-item btn-s btn-primary">
            Přihlášení školy
          </li>
        </ul>
      </div>
    </div>
  </section>
  <!-- <nav class="main-wrapper">
    <router-link class="nav-primary" to="/">Školu nepobírám</router-link>
    <div class="nav-secondary">
      <router-link to="/hledat" class="btn-s btn-primary"
        >Hledat školu</router-link
      >
      <router-link to="/hledat" class="btn-s btn-primary">Mapa</router-link>
      <router-link to="/hledat" class="btn-s btn-primary"
        >Aktuální opatření</router-link
      >
      <router-link to="/hledat" class="btn-s btn-secondary"
        >Přihlášení školy</router-link
      >
    </div>
  </nav> -->
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "Navbar",
});
</script>

<style scoped lang="scss">
@import "../../styles/main.scss";

</style>
