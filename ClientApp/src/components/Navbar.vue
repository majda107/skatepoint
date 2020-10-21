<template>
  <section class="nav">
    <div class="nav-content main-wrapper">
      <div class="nav-content-title">
        <div class="nav-content-title-logo">
          <router-link to="/">
            <h1>Skate spots</h1>
          </router-link>
        </div>
      </div>
      <div class="nav-content-menu">
        <ul class="nav-content-menu-items">
          <router-link to="/search" class="nav-content-menu-items-item">
            <li class="nav-content-menu-items-item">Mapa</li>
          </router-link>

          <router-link to="/add">
            <li class="nav-content-menu-items-item">Přidat spot</li>
          </router-link>

          <router-link to="/profile">
            <li class="nav-content-menu-items-item">Profil</li>
          </router-link>

          <router-link to="/login">
            <li class="nav-content-menu-items-item btn-s btn-secondary">
              Přihlásit
            </li>
          </router-link>
          <router-link to="/register">
            <li class="nav-content-menu-items-item btn-s btn-primary">
              Registrovat
            </li>
          </router-link>
        </ul>
      </div>
    </div>
  </section>
  <!-- <nav class="main-wrapper">
    <router-link class="nav-primary" to="/">Školu nepobírám</router-link>
    <div class="nav-secondary">
      <router-link to="/search" class="btn-s btn-primary"
        >Hledat školu</router-link
      >
      <router-link to="/hledat" class="btn-s btn-primary">Mapa</router-link>
      <router-link to="/hledat" class="btn-s btn-primary"
        >Aktuální opatření</router-link
      >
      <router-link to="/login" class="btn-s btn-secondary"
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
@import "../../styles/main.scss"; // nav {
//   height: 72px;
//   .nav-primary {
//     margin-right: 400px;
//     position: relative;
//     top: 50%;
//     transform: translateY(-50%);
//   }
//   .nav-secondary {
//     display: inline-block;
//     a{
//       margin-right: 10px;
//     }
//     position: relative;
//     top: 50%;
//     transform: translateY(-50%);
//   }
// }
</style>
