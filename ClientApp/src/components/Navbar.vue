<template>
  <nav class="main-wrapper">
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
  </nav>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "Navbar",
});
</script>

<style scoped lang="scss">
nav {
  height: 72px;
  .nav-primary {
    margin-right: 400px;
    position: relative;
    top: 50%;
    transform: translateY(-50%);
  }
  .nav-secondary {
    display: inline-block;
    a {
      margin-right: 10px;
    }
    position: relative;
    top: 50%;
    transform: translateY(-50%);
  }
}
</style>